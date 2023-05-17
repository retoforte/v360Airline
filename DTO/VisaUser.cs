using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DTO
{
    public class VisaUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string FullName { get; set; }
        public string Estado { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int TotalChecks { get; set; }
        public DateTime Reschedule1 { get; set; }
        public DateTime Reschedule2 { get; set; }
        public DateTime Reschedule3 { get; set; }
        public DateTime Reschedule4 { get; set; }
    }
}
