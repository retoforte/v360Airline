using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckTrips360.DTO;
using OpenQA.Selenium;

namespace CheckTrips360.Utils
{
    public interface IBusquedaBrowser
    {
        Quotation Quotation { get; set; }
        IWebDriver Driver { get; set; }
        List<Flight> Flights { get; set; }
  
        List<Flight> BuscarVuelos();

        void CargarVuelosSalida();
        void BuscarHorarios(Flight flight, IWebElement element);

        bool DetectarConexion(Flight flight, IWebElement element);
        void DetectarAlertaAsiento(Flight flight, IWebElement element);
        void BuscarPrecio(Flight flight, IWebElement element);

        void BuscarTUA(Flight flight, IWebElement element);
        void CargarCostosPaquetes(Flight flight);
    }
}
