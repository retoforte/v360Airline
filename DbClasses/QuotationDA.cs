using CheckTrips360.DTO;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace CheckTrips360.DbClasses
{
    public class QuotationDA
    {
        public List<QuotationDTO> GetQuotations()
        {
            List<QuotationDTO> quotations = new List<QuotationDTO>();

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
                        QuotationDTO quotation = new QuotationDTO();

                        quotation.Id = reader.GetInt32(0);
                        quotation.Origin = reader.GetString(1);
                        quotation.Destination = reader.GetString(2);
                        quotation.StartDate = reader.GetDateTime(3);
                        quotation.EndDate = reader.GetDateTime(4);
                        quotation.TotalTravelers = reader.GetInt32(5);
                        quotation.TravelersUnderAge = reader.GetInt32(6);
                        quotation.IsRoundTrip = reader.GetBoolean(7);
                        quotation.AirlineName = reader.GetString(8);
                        quotation.IsInternational = reader.GetBoolean(9);

                        quotations.Add(quotation);
                    }

                    reader.Close();
                }
            }

            return quotations;
        }
    }
}
