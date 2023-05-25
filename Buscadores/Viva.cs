using CheckTrips360.DTO;
using CheckTrips360.Exceptions;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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

        public void IniciarProceso(IWebDriver driver, string tipo, string origen, string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            driver.Navigate().GoToUrl("https://www.vivaaerobus.com/");
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); // Maximum wait time of 10 seconds
            Thread.Sleep(2000);
            try
            {
                IReadOnlyCollection<IWebElement> btnCookies = driver.FindElements(By.CssSelector(".viva-btn.quick-add"));
                if (btnCookies.Count() > 0)
                    btnCookies.ElementAt(0).Click();
            }
            catch (Exception ex) { }

            UIGenericActions.WaitUntilElementIsVisible("//app-booker-search//app-flight-select//label[@for='type_1']//span[1]", UIGenericActions.searchType.XPATH, driver, null, false);

            IWebElement rdbViajeSencillo = driver.FindElement(By.XPath(PageElements.RdbViajeSencillo));
            IWebElement txtViajeOrigen = driver.FindElement(By.XPath(PageElements.TxtViajeOrigen));
            IWebElement txtViajeDestino = driver.FindElement(By.XPath(PageElements.TxtViajeDestino));
            IWebElement divViajeOrigen = driver.FindElement(By.XPath(PageElements.DivActivaCamposViaje));

            IWebElement divResultadoOrigen = null;

            rdbViajeSencillo.Click();
            divViajeOrigen.Click();

            txtViajeOrigen.SendKeys(tipo == "Salida" ? origen : destino);
            Thread.Sleep(2000);
            // Del dropdown buscar el primer elemento y seleccionarlo
            UIGenericActions.WaitUntilElementIsVisible("//app-station-results", UIGenericActions.searchType.XPATH, driver, null);
            //divResultadoOrigen = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));
            IReadOnlyCollection<IWebElement> stationSavedItems = driver.FindElements(By.XPath("//app-station-item//div[contains(@class, 'main-container')]"));

            if (stationSavedItems.Count == 0)
            {
                driver.Quit();
                throw new UIValidationMessageException("La Ciudad Origen Proporcionada no fue encontrada!");
            }
            else
            {
                // Seleccionar el viaje Origen
                IWebElement firstStationSavedItem = stationSavedItems.First();
                firstStationSavedItem.Click();

                txtViajeDestino.SendKeys(tipo == "Salida" ? destino : origen);
                // Del dropdown buscar el primer elemento y seleccionarlo
                // Buscando el Destino
                Thread.Sleep(500);
                stationSavedItems = driver.FindElements(By.XPath("//app-station-destination-item//div[contains(@class, 'main-container')]"));

                if (stationSavedItems.Count == 0)
                {
                    driver.Quit();
                    throw new UIValidationMessageException("La Ciudad Destino Proporcionada no fue encontrada!");
                }
                else
                {
                    // Seleccionar el viaje Origen
                    firstStationSavedItem = stationSavedItems.First();
                    firstStationSavedItem.Click();
                }
                Thread.Sleep(2000);
                UIGenericActions.SelectFechaSalida(driver, tipo == "Salida" ? fechaInicio : fechaFin);
                IWebElement btnBuscar = driver.FindElement(By.CssSelector("button.viva-btn.action"));
                btnBuscar.Click();
            }
        }

        public List<Flight> BuscarVuelos(string tipo)
        {
            CargarVuelosSalida(tipo);
            return Flights;
        }

        public void CargarVuelosSalida(string tipo)
        {
            this._flights = new ConcurrentBag<Flight>();
            Thread.Sleep(1000);

            IReadOnlyCollection<IWebElement> vuelos = Driver.FindElements(By.TagName("app-flight-option"));
            int totalVuelos = vuelos.Count();
            Actions actions = new Actions(Driver);

            Thread.Sleep(400);
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            // Cargar info general de los Vuelos 
            for (int  vueloPos = 0; vueloPos < totalVuelos; vueloPos++)
            {
                UIGenericActions.WaitUntilElementIsVisible("app-carousel-item", UIGenericActions.searchType.TAG, Driver, null, true);

                IWebElement vuelo = Driver.FindElements(By.TagName("app-flight-option"))[vueloPos];           
                
                Flight flight = new Flight();
                flight.Tipo = tipo;
                flight.Order = vueloPos;
                if (DetectarConexion(flight, vuelo) && !Quotation.IncludeConexions)
                    continue;
                IWebElement bookingDetailsBody = vuelo.FindElement(By.TagName("app-flight-option-details"));
                // Scroll to the booking element
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", vuelo);
             /*   if (vueloPos >= 2)
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("window.scrollBy(0, "+ (50 * vueloPos + (vueloPos / 3) * 200)  + ");");
                    Thread.Sleep(2000);
                }*/

                wait.Until(ExpectedConditions.ElementToBeClickable(vuelo));


                flight.ElementClassId = vuelo.GetAttribute("class");
                BuscarHorarios(flight, vuelo);
                DetectarAlertaAsiento(flight, vuelo);
                BuscarPrecio(flight, vuelo);

                vuelo.Click();                
                BuscarTUA(flight, vuelo);
                CargarCostosPaquetes(flight);

                IWebElement btnBack = Driver.FindElement(By.XPath(".//button[@class='viva-btn btn-link edit-flight-btn h-auto']"));
                btnBack.Click();

                flight.Quotation = this.Quotation;
                this._flights.Add(flight);

                if (this.Quotation.MaxResults > 0 && this._flights.Count() == this.Quotation.MaxResults)
                    break;
            }
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver;
            if (!this.Quotation.IsRoundTrip)
            {
                // Send the JavaScript code to the element.
                js2.ExecuteScript("alert('Busqueda Terminada, regresa a la aplicación!')");
            } else if (tipo == "Regreso")
            {
                js2.ExecuteScript("alert('Busqueda Terminada, regresa a la aplicación!')");
            }
        }

        public void BuscarHorarios(Flight flight, IWebElement element)
        {
            IWebElement vueloInfo = element.FindElement(By.TagName("app-flight-brief-info"));
            IReadOnlyCollection<IWebElement> horarios = element.FindElements(By.TagName("h4"));
            flight.Horario = Regex.Replace(horarios.ElementAt(0).Text, @"^\s*(.{7})\s*$", "0$1") + " - " + Regex.Replace(horarios.ElementAt(1).Text, @"^\s*(.{7})\s*$", "0$1");

            var datos = horarios.Select(horario => horario.Text.Trim().Replace("AM", "").Replace("PM", "")).ToArray();
            var hora = datos[0].Split(":");
            var newStartTime = new DateTime(this.Quotation.StartDate.Year, this.Quotation.StartDate.Month, this.Quotation.StartDate.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            flight.StartDate = newStartTime;

            hora = datos[1].Split(":");
            newStartTime = new DateTime(this.Quotation.EndDate.Year, this.Quotation.EndDate.Month, this.Quotation.EndDate.Day, int.Parse(hora[0]), int.Parse(hora[1]), 0);
            flight.EndDate = newStartTime;

            //DetectarConexion(flight, vueloInfo);
        }
        public bool DetectarConexion(Flight flight, IWebElement element)
        {
            IWebElement vueloInfo = element.FindElement(By.TagName("app-flight-brief-graph"));
            IReadOnlyCollection<IWebElement> tieneConexion = vueloInfo.FindElements(By.XPath(".//div[@class='mt-5 text-nowrap ng-star-inserted']/span[position()<=2]"));

            if (tieneConexion != null && tieneConexion.Count > 0)
            {
                flight.HasConexion = 1;
                flight.ConexionDetail = tieneConexion.ElementAt(0).Text + " - " + tieneConexion.ElementAt(1).Text;
                return true;
            }
            return false;
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
            IWebElement booking = UIGenericActions.WaitUntilElementIsVisible(".//button[contains(@class, 'viva-btn')]", UIGenericActions.searchType.XPATH, Driver, element);

           // IWebElement booking = element.FindElement(By.XPath(".//button[contains(@class, 'viva-btn')]"));
            UIGenericActions.WaitUntilElementIsVisible(".//button[contains(@class, 'viva-btn')]", UIGenericActions.searchType.XPATH, Driver, null);
            
            IWebElement bookingDetailsBody = element.FindElement(By.TagName("app-flight-option-details"));
            // Scroll to the booking element
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", bookingDetailsBody);

            Thread.Sleep(500);
            // Obtener los Numeros de Vuelo, Maximo 2 
            IList<IWebElement> segmentDetails = bookingDetailsBody.FindElements(By.XPath(".//app-flight-segment-details"));
            foreach (var segment in segmentDetails)
            {
                var vuelo = segment.FindElements(By.XPath(".//span[@class='small-title opacity-5']"));
                if (vuelo.Count > 0)
                {
                    var www = vuelo[0].Text;
                    flight.NumVuelo = (flight.NumVuelo != null && flight.NumVuelo.Length > 0) ? flight.NumVuelo + "/" + www.Trim() : www.Trim();
                }
            }
            booking.Click();

            IWebElement bookingDetails = Driver.FindElement(By.TagName("app-booking-details"));
            //UIGenericActions.WaitUntilElementIsVisible(".//app-booking-details//app-price//div//div//span[contains(@class, 'default-price')]", UIGenericActions.searchType.XPATH, Driver);
            IWebElement price = Driver.FindElement(By.XPath("//app-price//span[contains(@class,'default-price h3')]"));
            var rr = price.Text.Trim();
            if (price.Text.Replace(",","").Trim() == flight.BasePrice.ToString())
            {
                IList<IWebElement> tuas = Driver.FindElements(By.CssSelector(".small-title.light.opacity-6"));
                if (tuas.Count  >0 && !String.IsNullOrEmpty(tuas.ElementAt(0).Text))
                {
                    Regex regex = new Regex(@"\d+");
                    Match match = regex.Match(tuas.ElementAt(0).Text);
                    string numero = match.Value;
                    flight.TUA = Convert.ToDecimal(numero);

                    booking = UIGenericActions.WaitUntilElementIsVisible(".//button[contains(@class, 'viva-btn action')]", UIGenericActions.searchType.XPATH, Driver, bookingDetails, false, "Continuar");
                    Thread.Sleep(500);
                    //bookingDetails.FindElement(By.XPath(".//button[contains(@class, 'viva-btn action')]"));
                    booking.Click();
                }
            }
            else
            {
                throw new UIValidationMessageException("Error de busqueda, el precio al seleccionar el viaje no coincide con el Precio al seleccionarlo.");
            }
        }

        public void CargarCostosPaquetes(Flight flight)
        {
            //Thread.Sleep(3000);
            UIGenericActions.WaitUntilElementIsVisible(".//app-flight-pack-card", UIGenericActions.searchType.XPATH, Driver, null, true);

            IReadOnlyCollection<IWebElement> paquetes = Driver.FindElements(By.XPath(".//app-flight-pack-card"));
            flight.Paquetes = new List<FlightPackage>();
            FlightPackage LIGTH = new FlightPackage() { Name= "LIGTH" };
            FlightPackage EXTRA = new FlightPackage() { Name = "EXTRA" };
            FlightPackage SMART = new FlightPackage() { Name = "SMART" };
            Thread.Sleep(1000);
            LIGTH.Price = Convert.ToDecimal(paquetes.ElementAt(1).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text );
            EXTRA.Price = Convert.ToDecimal(paquetes.ElementAt(2).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text);
            SMART.Price = Convert.ToDecimal(paquetes.ElementAt(3).FindElement(By.XPath("(.//span[@class='default-price h3'])[2]")).Text);
            flight.Paquetes.Add(LIGTH);
            flight.Paquetes.Add(EXTRA);
            flight.Paquetes.Add(SMART);

        }
    }
}
