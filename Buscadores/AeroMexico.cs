using CheckTrips360.DTO;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CheckTrips360.Buscadores
{
    public class AeroMexico : IBusquedaBrowser
    {
        private ConcurrentBag<Flight> _flights;
        private IWebDriver _driver;
        private Quotation _quotation;
        public Quotation Quotation { get { return this._quotation; } set { this._quotation = value; } }
        public IWebDriver Driver { get { return this._driver; } set { this._driver = value; } }
        public List<Flight> Flights { get { return this._flights.ToList(); } set { this._flights = new ConcurrentBag<Flight>(value); } }

        public void IniciarProceso(IWebDriver driver, string tipo, string origen, string destino, DateTime fechaInicio, DateTime fechaFin)
        {   
            driver.Navigate().GoToUrl("https://aeromexico.com/es-mx");
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30)); // Maximum wait time of 10 seconds
            Thread.Sleep(2000);
            try
            {
                IReadOnlyCollection<IWebElement> btnCookies = driver.FindElements(By.CssSelector("[aria-label='Acepto']"));
                if (btnCookies.Count() > 0)
                    btnCookies.ElementAt(0).Click();
            }
            catch (Exception ex) { }

            IReadOnlyCollection<IWebElement> tiposDeViajes = driver.FindElements(By.ClassName("BookerTripToggle-button"));
            if (tipo == "Salida")
                tiposDeViajes.ElementAt(1).Click();

            IWebElement txtViajeOrigen = driver.FindElement(By.Name("origin"));
            txtViajeOrigen.Click();
            txtViajeOrigen.SendKeys(origen);
            Thread.Sleep(1500);
            txtViajeOrigen.SendKeys(Keys.Tab);           

            IWebElement txtViajeDestino = driver.FindElement(By.Name("destination"));
            txtViajeDestino.Click();
            txtViajeDestino.SendKeys("");
            Thread.Sleep(500);
            txtViajeDestino.SendKeys(destino.Trim());
            Thread.Sleep(500);
            txtViajeDestino.SendKeys(Keys.Tab);
            Thread.Sleep(200);
            txtViajeDestino.SendKeys(Keys.Tab);

            UIGenericActions.SelecFechaSalidaAeroMexico(driver, fechaInicio);
        }

        public void BuscarHorarios(Flight flight, IWebElement element)
        {
            throw new NotImplementedException();
        }

        public void BuscarPrecio(Flight flight, IWebElement element)
        {
            throw new NotImplementedException();
        }

        public void BuscarTUA(Flight flight, IWebElement element)
        {
            throw new NotImplementedException();
        }

        public List<Flight> BuscarVuelos(string tipo)
        {
            throw new NotImplementedException();
        }

        public void CargarCostosPaquetes(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void CargarVuelosSalida(string tipo)
        {
            throw new NotImplementedException();
        }

        public void DetectarAlertaAsiento(Flight flight, IWebElement element)
        {
            throw new NotImplementedException();
        }

        public bool DetectarConexion(Flight flight, IWebElement element)
        {
            throw new NotImplementedException();
        }
    }
}
