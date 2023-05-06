using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360
{
    public  static  class PageElements
    {
        public const string RdbViajeSencillo = "/html/body/app-root/div/div[1]/app-home-page/div/div[1]/app-booker-search/div/div[2]/div/div/div/div/div/app-flight-search/div/div/div[1]/div/div[1]/app-flight-select/div/label[2]/span[2]";
        public const string TxtViajeOrigen = ".//*[@id='flight-search-origin']";
        public const string TxtViajeDestino = ".//*[@id='flight-search-destination']";
        public const string DivActivaCamposViaje = "html/body/app-root/div/div[1]/app-home-page/div/div[1]/app-booker-search/div/div[2]/div/div/div/div/div/app-flight-search/div/div/div[2]/div/div[1]/app-flight-input/form/div/div[1]";
        public const string TagFullCalendarios = "bs-daterangepicker-container";
        public const string TagCalendario = "bs-days-calendar-view";
        public const string ClassCalendarioFechas = "current";

        public const string CssBtnCalendarioFechas = "button.current > span";
    }
}
