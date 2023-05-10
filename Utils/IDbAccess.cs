using System.Collections.Generic;
using CheckTrips360.DTO;

namespace CheckTrips360.DbClasses
{
    public interface IDbAccess
    {
        // Métodos para la tabla AirlineCatalog
        List<AirlineCatalog> GetAirlineCatalogs();
        AirlineCatalog GetAirlineCatalogById(int id);
        void AddAirlineCatalog(AirlineCatalog airlineCatalog);
        void UpdateAirlineCatalog(AirlineCatalog airlineCatalog);
        void DeleteAirlineCatalog(int id);

        // Métodos para la tabla Quotation
        List<Quotation> GetQuotations();
        Quotation GetQuotationById(int id);
        void AddQuotation(Quotation quotation);
        void UpdateQuotation(Quotation quotation);
        void DeleteQuotation(int id);

        // Métodos para la tabla Flight
        List<Flight> GetFlights();
        Flight GetFlightById(int id);
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(int id);

        // Métodos para la tabla FlightPackage
        List<FlightPackage> GetFlightPackages();
        FlightPackage GetFlightPackageById(int id);
        void AddFlightPackage(FlightPackage flightPackage);
        void UpdateFlightPackage(FlightPackage flightPackage);
        void DeleteFlightPackage(int id);
    }
}
