using CheckTrips360.DTO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace CheckTrips360.DbClasses
{
    public class QuotationDA
    {
        public List<Quotation> GetQuotations()
        {
            List<Quotation> quotations = new List<Quotation>();

            string connectionString = ConfigurationManager.ConnectionStrings["viajes360db"].ConnectionString;
            string sql = "SELECT * FROM Quotation";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    connection.Open();

                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Quotation quotation = new Quotation();

                        quotation.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                        quotation.Origin = reader.GetString(reader.GetOrdinal("Origin"));
                        quotation.Destination = reader.GetString(reader.GetOrdinal("Destination"));
                        quotation.StartDate = reader.GetDateTime(reader.GetOrdinal("StartDate"));
                        quotation.EndDate = reader.GetDateTime(reader.GetOrdinal("EndDate"));
                        quotation.TotalTravelers = reader.GetInt32(reader.GetOrdinal("TotalTravelers"));
                        quotation.TravelersUnderage = reader.GetInt32(reader.GetOrdinal("TravelersUnderage"));
                        quotation.IsRoundTrip = reader.GetBoolean(reader.GetOrdinal("IsRoundTrip"));
                        quotation.AirlineCatalogId = reader.GetInt32(reader.GetOrdinal("AirlineCatalogId"));
                        quotation.IsInternational = reader.GetBoolean(reader.GetOrdinal("IsInternational"));

                        quotations.Add(quotation);
                    }

                    reader.Close();
                }
            }

            return quotations;
        }
    }
}
