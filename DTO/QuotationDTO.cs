using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public class QuotationDTO
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalTravelers { get; set; }
        public int TravelersUnderAge { get; set; }
        public bool IsRoundTrip { get; set; }
        public string AirlineName { get; set; }
        public bool IsInternational { get; set; }
    }
}
