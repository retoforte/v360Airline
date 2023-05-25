using CheckTrips360.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTrips360.Utils
{
    public class MappingsFlights
    {
        public VviaFlight MapToVviaFlight(Flight flight)
        {
            var vviaFlight = new VviaFlight()
            {
                Id = flight.Id,
                StartDate = flight.StartDate,
                EndDate = flight.EndDate,
                BasePrice = flight.BasePrice,
                HasScale = flight.HasScale,
                AvailableSeats = flight.AvailableSeats,
                TUA = flight.TUA,
                CostoEmision = flight.CostoEmision,
                QuotationId = flight.QuotationId,
                Quotation = flight.Quotation,
                HasConexion = flight.HasConexion,
                ConexionDetail = flight.ConexionDetail == null ? "" : flight.ConexionDetail,
                AlertaAsientoDetalle = flight.AlertaAsientoDetalle == null? "" : flight.AlertaAsientoDetalle,
                ElementClassId = flight.ElementClassId,
                Paquetes = flight.Paquetes,
                Tipo = flight.Tipo,
                NumVuelo = flight.NumVuelo,
                CreatedDate = flight.CreatedDate,
                Horario = flight.Horario
            };

            return vviaFlight;
        }

    }
}
