namespace AirConditionalTesterSystem.Models
{
    using System.Text;
    using Interfaces;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public int Mark { get; private set; }

        public override string ToString()
        {
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();
            if (this.Mark == 0)
            {
                result = "Failed";
            }
            else if (this.Mark == 1)
            {
                result = "Passed";
            }

            sb.AppendLine("Report")
                .AppendLine("====================")
                .Append("Manufacturer: ")
                .AppendLine(this.Manufacturer)
                .Append("Model: ")
                .AppendLine(this.Model)
                .Append("Mark: ")
                .AppendLine(result)
                .Append("====================");

            return sb.ToString();
        }
    }
}
