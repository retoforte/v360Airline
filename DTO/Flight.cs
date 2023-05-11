using CheckTrips360.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public  class Flight
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal BasePrice { get; set; }
        public bool HasScale { get; set; }
        public int AvailableSeats { get; set; }
        public decimal TUA { get; set; }
        public decimal CostoEmision { get; set; }
        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; }


        public int HasConexion { get; set; }
        public string ConexionDetail { get; set; }
        public string AlertaAsientoDetalle { get; set; }

        public string ElementClassId { get; set; } // For internal use only to identify the row

        public List<FlightPackage> Paquetes { get; set; }
    }
}
