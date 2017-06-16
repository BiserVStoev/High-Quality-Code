namespace AirConditionalTesterSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Exceptions;
    using Interfaces;
    using Models;
    using Models.AirConditionerModels;

    public class CommandExecutioner
    {
        private readonly AirConditionalTesterSystemEngine airConditionalTesterSystemEngine;

        public CommandExecutioner(AirConditionalTesterSystemEngine airConditionalTesterSystemEngine)
        {
            this.airConditionalTesterSystemEngine = airConditionalTesterSystemEngine;
        }

        public virtual void Execute()
        {
            var command = this.airConditionalTesterSystemEngine.Command;
            string output = string.Empty;
            switch (command.Name)
            {
                case "RegisterStationaryAirConditioner":
                    this.ValidateParametersCount(command, 4);
                    output = this.RegisterStationaryAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        command.Parameters[2],
                        int.Parse(command.Parameters[3]));
                    break;
                case "RegisterCarAirConditioner":
                    this.ValidateParametersCount(command, 3);
                    output = this.RegisterCarAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]));
                    break;
                case "RegisterPlaneAirConditioner":
                    this.ValidateParametersCount(command, 4);
                    output = this.RegisterPlaneAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1],
                        int.Parse(command.Parameters[2]),
                        command.Parameters[3]);
                    break;
                case "TestAirConditioner":
                    this.ValidateParametersCount(command, 2);
                    output = this.TestAirConditioner(
                        command.Parameters[0],
                        command.Parameters[1]);
                    break;
                case "FindAirConditioner":
                    this.ValidateParametersCount(command, 2);
                    output = this.FindAirConditioner(
                        command.Parameters[1],
                        command.Parameters[0]);
                    break;
                case "FindReport":
                    this.ValidateParametersCount(command, 2);
                    output = this.FindReport(
                        command.Parameters[0],
                        command.Parameters[1]);
                    break;
                case "Status":
                    this.ValidateParametersCount(command, 0);
                    output = this.Status();
                    break;
                case "FindAllReportsByManufacturer":
                    this.ValidateParametersCount(command, 1);
                    output = this.FindAllReportsByManufacturer(command.Parameters[0]);
                    break;
                default:
                    throw new ArgumentException(Constants.InvalidCommandMessage);
            }

            this.airConditionalTesterSystemEngine.Writer.WriteLine(output);
        }

        /// <summary>
        /// Gives information about the status of the system (percentage of air conditioners tested). 
        /// </summary>
        /// <returns>The percentage status of the system.</returns>
        public string Status()
        {
            int reports = this.airConditionalTesterSystemEngine.Database.GetReportsCount();
            double airConditioners = this.airConditionalTesterSystemEngine.Database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.StatusMessage, percent);
        }

        public void ValidateParametersCount(Command command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.InvalidCommandMessage);
            }
        }

        private string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);

            foreach (var airCondit in this.airConditionalTesterSystemEngine.Database.AirConditioners)
            {
                if (airCondit.Model == model)
                {
                    throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
                }
            }

            this.airConditionalTesterSystemEngine.Database.AirConditioners.Add(airConditioner);

            var successMessage = string.Format(Constants.SuccessfullRegistrationMessage, airConditioner.Model, airConditioner.Manufacturer);

            return successMessage;
        }

        private string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);

            foreach (var airCondit in this.airConditionalTesterSystemEngine.Database.AirConditioners)
            {
                if (airCondit.Model == model)
                {
                    throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
                }
            }

            this.airConditionalTesterSystemEngine.Database.AirConditioners.Add(airConditioner);

            var successMessage = string.Format(Constants.SuccessfullRegistrationMessage, airConditioner.Model, airConditioner.Manufacturer);

            return successMessage;
        }

        /// <summary>
        /// Registers a new Plane air Conditioner in the database, or sends an error if something goes wrong.
        /// </summary>
        /// <param name="manufacturer">The manufacturer name of the air conditioner</param>
        /// <param name="model">The model name of the air conditioner</param>
        /// <param name="volumeCoverage">The volume coverage of the air conditioner</param>
        /// <param name="electricityUsed">The electricity used by the air conditioner</param>
        /// <returns>A succes message if everyting goes alring, otherwise throws an exception</returns>
        /// <exception cref="">BigMani.Exceptions.DuplicateEntryException</exception>
        private string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, electricityUsed);

            foreach (var airCondit in this.airConditionalTesterSystemEngine.Database.AirConditioners)
            {
                if (airCondit.Model == model)
                {
                    throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
                }
            }

            this.airConditionalTesterSystemEngine.Database.AirConditioners.Add(airConditioner);

            var successMessage = string.Format(Constants.SuccessfullRegistrationMessage, airConditioner.Model, airConditioner.Manufacturer);

            return successMessage;
        }

        private string TestAirConditioner(string manufacturer, string model)
        {
            AirConditioner airConditioner = this.airConditionalTesterSystemEngine.Database.GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistingEntryMessage);
            }

            // airConditioner.EnergyRating += 5;
            var mark = airConditioner.Test();

            foreach (var report in this.airConditionalTesterSystemEngine.Database.Reports)
            {
                if (report.Model == airConditioner.Model)
                {
                    throw new DuplicateEntryException(Constants.DuplicateEntryMessage);
                }
            }

            this.airConditionalTesterSystemEngine.Database.Reports.Add(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));

            var successMessage = string.Format(Constants.SuccessfullTestMessage, model, manufacturer);

            return successMessage;
        }

        /// <summary>
        /// Searches for an air conditioner by model and manufacturer.
        /// </summary>
        /// <param name="model">The model of the searched air conditioner.</param>
        /// <param name="manufacturer">The manufacturer name of the searched air conditioner.</param>
        /// <returns>Returns information about the found air conditioner, otherwise throws an exception.</returns>
        /// <exception cref="NonExistantEntryException"></exception>
        private string FindAirConditioner(string model, string manufacturer)
        {
            AirConditioner airConditioner = this.airConditionalTesterSystemEngine.Database.GetAirConditioner(manufacturer, model);

            if (airConditioner == null)
            {
                throw new NonExistantEntryException(Constants.NonExistingEntryMessage);
            }

            string message = airConditioner.ToString();

            return message;
        }

        private string FindReport(string manufacturer, string model)
        {
            IReport report = this.airConditionalTesterSystemEngine.Database.GetReport(manufacturer, model);

            if (report == null)
            {
                throw new NonExistantEntryException(Constants.NonExistingEntryMessage);
            }

            return report.ToString();
        }

        private string FindAllReportsByManufacturer(string manufacturer)
        {
            IList<Report> reports = this.airConditionalTesterSystemEngine.Database.GetReportsByManufacturer(manufacturer).ToList();
            if (reports.Count == 0)
            {
                return Constants.NoReportsMessage;
            }

            reports = reports.OrderBy(r => r.Model).ToList();

            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));

            return reportsPrint.ToString();
        }
    }
}
