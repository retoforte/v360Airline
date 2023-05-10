using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalTravelers { get; set; }
        public int TravelersUnderage { get; set; }
        public bool IsRoundTrip { get; set; }
        public bool IsInternational { get; set; }
        public int AirlineCatalogId { get; set; }
        public AirlineCatalog AirlineCatalog { get; set; }

        public bool IncludeConexions { get; set; }
    }
}
