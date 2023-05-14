using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public class VviaFlight : Flight
    {

        public decimal Ligth
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[0].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }
        public decimal Extra
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[1].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[1].Price = value; }
        }

        public decimal Smart
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[2].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count == 2) this.Paquetes[2].Price = value; }
        }
    }
}
