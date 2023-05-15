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
            table.Columns.Add("Tipo");
            table.Columns.Add("NumVuelo");
            table.Columns.Add("FechaSalida");
            table.Columns.Add("Origin");
            table.Columns.Add("Destination");
            table.Columns.Add("Horario");
            table.Columns.Add("TUA");
            table.Columns.Add("Emision");
            table.Columns.Add("BasePrice");
            table.Columns.Add("Ligth");
            table.Columns.Add("Extra");
            table.Columns.Add("Smart");
            
            table.Columns.Add("ConexionDetail");
            table.Columns.Add("AlertaAsientoDetalle");
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (table.Columns.Contains(prop.Name))
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        if (prop.Name == "TUA" || prop.Name == "Ligth" || prop.Name == "Extra" || prop.Name == "Smart" || prop.Name == "BasePrice" || prop.Name == "Emision")
                        {
                            row[prop.Name] = "$" + string.Format("{0:C}", row[prop.Name]);
                        }
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
