using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.DbClasses
{
    public  class DBManager
    {
        string connectionString = ConfigurationManager.ConnectionStrings["viajes360db"].ConnectionString;

        public int CountQuotation()
        {
            QuotationDA da = new QuotationDA();
            var list = da.GetQuotations();
            return list != null ? list.Count() : 0;
        }
    }
}
