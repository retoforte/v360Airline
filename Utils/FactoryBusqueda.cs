using CheckTrips360.Buscadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CheckTrips360.Utils.Enumerados;

namespace CheckTrips360.Utils
{
    public  class FactoryBusqueda
    {
        private Aerolinea _aerolinea;
        public FactoryBusqueda(Aerolinea aerolinea) {
            this._aerolinea = aerolinea;
        }
        public IBusquedaBrowser GetBuscador()
        {
            if (this._aerolinea == Aerolinea.VIVA)
                return new Viva();
            else if (this._aerolinea == Aerolinea.AEROMEXICO)
                return new AeroMexico();

            return null;
        }
    }
}
