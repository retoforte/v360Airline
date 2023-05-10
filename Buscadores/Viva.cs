using CheckTrips360.DTO;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CheckTrips360.Buscadores
{
    public class Viva : IBusquedaBrowser
    {
        private List<Flight> _flights;
        private IWebDriver _driver;
        private Quotation _quotation;
        public Quotation Quotation { get  { return this._quotation; } set { this._quotation = value; } }

        public IWebDriver Driver { get { return this._driver; } set { this._driver = value;  } }

        public List<Flight> Flights { get { return this._flights;  } set { this._flights = value;  } }

        public List<Flight> BuscarVuelos()
        {
            CargarVuelosSalida();
            return Flights;
        }

        public void CargarVuelosSalida()
        {
            this._flights = new List<Flight>();
            Thread.Sleep(2000);
            IReadOnlyCollection<IWebElement> vuelos = Driver.FindElements(By.TagName("app-flight-option"));
    
            foreach (IWebElement vuelo in vuelos)
            {
                Flight flight = new Flight();
                BuscarHorarios(flight, vuelo);
                DetectarAlertaAsiento(flight, vuelo);
                BuscarPrecio(flight, vuelo);

                this._flights.Add(flight);
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

    }
}
