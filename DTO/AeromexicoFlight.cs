using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public class AeromexicoFlight : Flight
    {
        public decimal Clasica
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

        public decimal ClasicaFlex
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[1].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }

        public decimal AMPlus
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[2].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }

        public decimal AMPlusFlex
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[3].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }

        public decimal Premier
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[4].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }
        public decimal PremierFlex
        {
            get
            {
                if (this.Paquetes != null && this.Paquetes.Count > 0)
                {
                    return this.Paquetes[5].Price;
                }
                return 0;
            }
            set { if (this.Paquetes != null && this.Paquetes.Count > 0) this.Paquetes[0].Price = value; }
        }
    }
}
