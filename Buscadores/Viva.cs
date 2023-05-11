using CheckTrips360.DTO;
using CheckTrips360.Exceptions;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckTrips360.Buscadores
{
    public class Viva : IBusquedaBrowser
    {
        private ConcurrentBag<Flight> _flights;
        private IWebDriver _driver;
        private Quotation _quotation;
        public Quotation Quotation { get  { return this._quotation; } set { this._quotation = value; } }

        public IWebDriver Driver { get { return this._driver; } set { this._driver = value;  } }

        public List<Flight> Flights { get { return this._flights.ToList();  } set { this._flights = new ConcurrentBag<Flight>(value);  } }

        public List<Flight> BuscarVuelos()
        {
            CargarVuelosSalida();
            return Flights;
        }

        public void CargarVuelosSalida()
        {
            this._flights = new ConcurrentBag<Flight>();
            Thread.Sleep(2000);
            IReadOnlyCollection<IWebElement> vuelos = Driver.FindElements(By.TagName("app-flight-option"));
            
            // Cargar info general de los Vuelos 
            vuelos.AsParallel().ForAll(vuelo => {
                Flight flight = new Flight();
                flight.ElementClassId = vuelo.GetAttribute("class");

                BuscarHorarios(flight, vuelo);
                DetectarAlertaAsiento(flight, vuelo);
                BuscarPrecio(flight, vuelo);

                this._flights.Add(flight);
            });
            foreach ((IWebElement vuelo, int index) in vuelos.Select((vuelo, index) => (vuelo, index)))
            {
                // Aquí puedes usar el índice si lo necesitas
                vuelo.Click();
                Flight flight = this._flights.FirstOrDefault(f => f.ElementClassId == vuelo.GetAttribute("class"));

                BuscarTUA(flight, vuelo);
                CargarCostosPaquetes(flight);

                IWebElement btnBack = Driver.FindElement(By.XPath(".//button[@class='viva-btn btn-link edit-flight-btn h-auto']"));
                btnBack.Click();
            }
        }

        public void BuscarHorarios(Flight flight, IWebElement element)
        {
            IWebElement vueloInfo = element.FindElement(By.TagName("app-flight-brief-info"));
            IReadOnlyCollection<IWebElement> horarios = element.FindElements(By.TagName("h4"));

            var datos = horarios.Select(horario => horario.Text.Trim().Replace("AM", "").Replace("PM", "")).ToArray();
            var hora = datos[0].Split(":");
            var newStartTime = new DateTime(this.Quotation.StartDate.Year, this.Quotation.StartDate.Month, this.Quotation.StartDate.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            flight.StartDate = newStartTime;

            hora = datos[1].Split(":");
            newStartTime = new DateTime(this.Quotation.EndDate.Year, this.Quotation.EndDate.Month, this.Quotation.EndDate.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            flight.EndDate = newStartTime;

            DetectarConexion(flight, vueloInfo);
        }
        public void DetectarConexion(Flight flight, IWebElement element)
        {
            IWebElement vueloInfo = element.FindElement(By.TagName("app-flight-brief-graph"));
            IReadOnlyCollection<IWebElement> tieneConexion = vueloInfo.FindElements(By.XPath(".//div[@class='mt-5 text-nowrap ng-star-inserted']/span[position()<=2]"));

            if (tieneConexion != null && tieneConexion.Count > 0)
            {
                flight.HasConexion = 1;
                flight.ConexionDetail = tieneConexion.ElementAt(0).Text + " - " + tieneConexion.ElementAt(1).Text;
            }
        }

        public void DetectarAlertaAsiento(Flight flight, IWebElement element)
        {
            try
            {
                // El punto al inicio del Xpaht le indica buscar en el mismo IWebElement
                IReadOnlyCollection<IWebElement> vueloInfo = element.FindElements(By.XPath(".//label[@class='d-flex']/div[@class='d-xl-block d-none']"));
                if (vueloInfo != null && vueloInfo.Count > 0)
                {
                    flight.AlertaAsientoDetalle = vueloInfo.ElementAt(0).Text;
                }
            }
            catch (NoSuchElementException ex) // No nos interesa el error pues no todos los vuelos tienen alerta de asientos
            {
            }
        }
        public void BuscarPrecio(Flight flight, IWebElement element)
        {
            //IWebElement vueloInfo = element.FindElement(By.TagName("app-price"));
            IWebElement price = element.FindElement(By.XPath(".//app-flight-option-price//app-price//div//div//span[@class='default-price h3']"));
            var x = price.Text;
            flight.BasePrice = Convert.ToDecimal(price.Text);
        }
        public void BuscarTUA(Flight flight, IWebElement element)
        {
            IWebElement booking = element.FindElement(By.XPath(".//button[contains(@class, 'viva-btn')]"));
            Thread.Sleep(1000);
            booking.Click();

            IWebElement bookingDetails = Driver.FindElement(By.TagName("app-booking-details"));
            //UIGenericActions.WaitUntilElementIsVisible(".//app-booking-details//app-price//div//div//span[contains(@class, 'default-price')]", UIGenericActions.searchType.XPATH, Driver);
            IWebElement price = Driver.FindElement(By.XPath("//app-price//span[contains(@class,'default-price h3')]"));
            var rr = price.Text.Trim();
            if (price.Text.Trim() == flight.BasePrice.ToString())
            {
                IWebElement tua = Driver.FindElement(By.CssSelector(".small-title.light.opacity-6"));
                if (!String.IsNullOrEmpty(tua.Text))
                {
                    Regex regex = new Regex(@"\d+");
                    Match match = regex.Match(tua.Text);
                    string numero = match.Value;
                    flight.TUA = Convert.ToDecimal(numero);

                    booking = bookingDetails.FindElement(By.XPath(".//button[contains(@class, 'viva-btn action')]"));
                    booking.Click();
                }
                else
                    throw new UIValidationMessageException("Error de busqueda, imposible determinar el TUA.");
            }
            else
            {
                throw new UIValidationMessageException("Error de busqueda, el precio al seleccionar el viaje no coincide con el Precio al seleccionarlo.");
            }
        }

        public void CargarCostosPaquetes(Flight flight)
        {
            Thread.Sleep(4000);
            UIGenericActions.WaitUntilElementIsVisible(".//app-flight-pack-card", UIGenericActions.searchType.XPATH, Driver);

            IReadOnlyCollection<IWebElement> paquetes = Driver.FindElements(By.XPath(".//app-flight-pack-card"));
            flight.Paquetes = new List<FlightPackage>();
            FlightPackage LIGTH = new FlightPackage() { Name= "LIGTH" };
            FlightPackage EXTRA = new FlightPackage() { Name = "EXTRA" };
            FlightPackage SMART = new FlightPackage() { Name = "SMART" };

            LIGTH.Price = Convert.ToDecimal(paquetes.ElementAt(1).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text );
            EXTRA.Price = Convert.ToDecimal(paquetes.ElementAt(2).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text);
            SMART.Price = Convert.ToDecimal(paquetes.ElementAt(3).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text);

        }
    }
}
