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
        public string Tipo { get; set; }
        public string NumVuelo { get; set; }
        public string Origin
        {
            get
            {
                if (Quotation != null)
                    return Quotation.Origin;
                return "";
            }
            set { if (Quotation != null)  Quotation.Origin = value; }
        }
        public string Destination
        {
            get
            {
                if (Quotation != null)
                    return Quotation.Destination;
                return "x";
            }
            set { if (Quotation != null) Quotation.Destination = value; }
        }

        public string Airline
        {
            get
            {
                if (Quotation !=null && Quotation.AirlineCatalogId > 0)
                    return (Airlines.VIVA.ToString().ToUpper());
                return "y";
            }
            set { if (Quotation != null) Quotation.AirlineCatalogId = 1;  }
        }

        public string Emision
        {
            get
            {
                if (Quotation != null)
                    return Quotation.Emision;
                return "z";
            }
            set { if (Quotation != null) Quotation.Emision = value; }
        }

        public string FechaSalida
        {
            get
            {
                if (Quotation != null)
                    return Quotation.StartDate.ToString("dd/MM/yyyy");
                return "z";
            }
            set { if (Quotation != null) Quotation.StartDate = Convert.ToDateTime(value); }
        }
        public string FechaRegreso
        {
            get
            {
                if (Quotation != null)
                    return Quotation.EndDate.ToString("dd/MM/yyyy");
                return "z";
            }
            set { if (Quotation != null) Quotation.EndDate = Convert.ToDateTime(value); }
        }

        public string Horario
        {
            get
            {
                  return StartDate.ToString("HH:mm") +"-"+ EndDate.ToString("HH:mm");
            }
            set { if (Quotation != null) Quotation.EndDate = Convert.ToDateTime(value); }
        }
    }
}
