namespace AirConditionalTesterSystem.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using Models.AirConditionerModels;

    public class AirConditionerDatabase : IAirConditionerDatabase
    {
        public AirConditionerDatabase()
        {
            this.AirConditioners = new HashSet<AirConditioner>();
            this.Reports = new HashSet<Report>();
        }

        public HashSet<AirConditioner> AirConditioners { get;  private set; }

        public HashSet<Report> Reports { get; private set; }

        public void AddAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Add(airConditioner);
        }

        public void RemoveAirConditioner(AirConditioner airConditioner)
        {
            this.AirConditioners.Remove(airConditioner);
        }

        public AirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return this.AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetAirConditionersCount()
        {
            return this.AirConditioners.Count;
        }

        public void AddReport(Report report)
        {
            this.Reports.Add(report);
        }

        public void RemoveReport(Report report)
        {
            this.Reports.Remove(report);
        }

        public Report GetReport(string manufacturer, string model)
        {
            // Possible bottleneck because it called first or default after checking before
            return this.Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetReportsCount()
        {
            return this.Reports.Count;
        }

        public IEnumerable<Report> GetReportsByManufacturer(string manufacturer)
        {
            return this.Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
