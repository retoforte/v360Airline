using CheckTrips360.DTO;
using CheckTrips360.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.Buscadores
{
    public class AeroMexico : IBusquedaBrowser
    {
        public Quotation Quotation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWebDriver Driver { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Flight> Flights { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void IniciarProceso(IWebDriver driver, string tipo, string origen, string destino, DateTime fechaInicio, DateTime fechaFin)
        {
            throw new NotImplementedException();
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
