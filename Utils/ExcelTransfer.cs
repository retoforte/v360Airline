using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using IronXL;
using CheckTrips360.DTO;

namespace CheckTrips360.Utils
{
    public class ExcelTransfer
    {
        /// <summary>
        /// Copia el cotizador al folder destino para manipularlo y regresa el nombre y ruta del archivo.
        /// Param "ruta" es la concatenacion de Origen-Destino
        /// </summary>
        /// <returns></returns>
        public string CopyCotizador(string ruta)
        {
            // Get the path to the Resources folder
            string resourcesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

            // Get the path to the file to copy
            string sourceFile = Path.Combine(resourcesPath, "CotizacionsV1.1.6.xlsm");

            // Get the path to the destination folder
            // Get the path to the destination folder
            string destinationPath = @"C:\temp";

            // Create the destination folder if it does not exist
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            // Get the current date and time
            DateTime dateTime = DateTime.Now;

            // Create the new file name
            string newFileName = $"Cotizacion{ruta}-{dateTime.ToString("ddMMyyyyHHmmss")}.xlsm";

            // Copy the file
            File.Copy(sourceFile, Path.Combine(destinationPath, newFileName));
            return destinationPath + "\newFileName";
        }

        public void StartProcesingSpreadSheet(string filePath, List<VviaFlight> flights)
        {
            string excelFilePath = @"C:\temp\CotizacionGUADALAJARA-VILLAHERMOSA-14052023170027.xlsm";

            WorkBook workBook = WorkBook.Load(excelFilePath);
            var workSheetw = workBook.WorkSheets;
            var workSheet = workBook.WorkSheets[1];
            int position = 3;
            string[] letters = { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N" };
            foreach (var flight in flights)
            {
                foreach (var letter in letters)
                {
                    string value = "";
                    switch (letter)
                    {
                        case "B": value = flight.Tipo; break;
                        case "C": value = flight.NumVuelo; break;
                        case "D": value = flight.FechaSalida; break;
                        case "E": value = flight.Origin; break;
                        case "F": value = flight.Destination; break;
                        case "G": value = flight.Horario; break;
                        case "H": value = flight.TUA.ToString().Replace("$",""); break;
                        case "I": value = flight.Emision.ToString().Replace("$", ""); ; break;
                        case "J": value = flight.BasePrice.ToString().Replace("$", ""); ; break;
                        case "K": value = flight.Ligth.ToString().Replace("$", ""); break;
                        case "L": value = flight.Extra.ToString().Replace("$", ""); break;
                        case "M": value = flight.Smart.ToString().Replace("$", ""); break;
                    }
                    workSheet[letter+position].Value = value;
                }
                position++;
            }
            workBook.Save();

        }
    }
}
