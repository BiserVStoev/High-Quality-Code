namespace AirConditionalTesterSystem.Models.AirConditionerModels
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model", "Model cannot be null or empty.");
                }

                if (value.Trim().Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Model", 2));
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Manufacturer", "Manufacturer cannot be null or empty.");
                }

                if (value.Trim().Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException(string.Format(Constants.IncorrectPropertyLength, "Manufacturer", 4));
                }

                this.manufacturer = value;
            }
        }

        public abstract int Test();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "Air Conditioner{0}{1}{0}Manufacturer: {2}{0}Model: {3}{0}",
                Environment.NewLine,
                "====================",
                this.Manufacturer, 
                this.Model);

            return sb.ToString();
        }
    }
}
