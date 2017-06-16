namespace AirConditionalTesterSystem.Interfaces
{
    using System.Collections.Generic;
    using Models;
    using Models.AirConditionerModels;

    public interface IAirConditionerDatabase
    {
        HashSet<AirConditioner> AirConditioners { get; }

        HashSet<Report> Reports { get; }

        void AddAirConditioner(AirConditioner airConditioner);

        void RemoveAirConditioner(AirConditioner airConditioner);

        AirConditioner GetAirConditioner(string manufacturer, string model);

        int GetAirConditionersCount();

        void AddReport(Report report);

        void RemoveReport(Report report);

        Report GetReport(string manufacturer, string model);

        int GetReportsCount();

        IEnumerable<Report> GetReportsByManufacturer(string manufacturer);
    }
}