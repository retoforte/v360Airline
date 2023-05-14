using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360
{
    public static class ExtensionUtilities
    {
        public static DataTable ToDataTableViva<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            table.Columns.Add("Id");
            table.Columns.Add("Airline");
            table.Columns.Add("Origin");
            table.Columns.Add("Destination");
            table.Columns.Add("StartDate");
            table.Columns.Add("EndDate");
            table.Columns.Add("BasePrice");
            table.Columns.Add("TUA");
            table.Columns.Add("Ligth");
            table.Columns.Add("Extra");
            table.Columns.Add("Smart");

            table.Columns.Add("CostoEmision");
            table.Columns.Add("AvailableSeats");
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (table.Columns.Contains(prop.Name))
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
