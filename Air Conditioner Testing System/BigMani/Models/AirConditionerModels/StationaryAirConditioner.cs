namespace AirConditionalTesterSystem.Models.AirConditionerModels
{
    using System;
    using System.Text;

    public class StationaryAirConditioner : AirConditioner
    {
        private int powerUsage;
        private int energyRating;

        public StationaryAirConditioner(string manufacturer, string model, string energyRating, int powerUsage) : base(manufacturer, model)
        {
            this.PowerUsage = powerUsage;
            this.DeclareEnergyRating(energyRating);
        }

        public int PowerUsage
        {
            get
            {
                return this.powerUsage;
            }

            private set
            {
                this.powerUsage = value;
            }
        }

        public int EnergyRating
        {
            get
            {
                return this.energyRating;
            }

            set
            {
                this.energyRating = value;
            }
        }

        public override int Test()
        {
            if (this.powerUsage / 100 <= this.energyRating)
            {
                return 1;
            }

            return 0;
        }
       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());

            string energy = "A";
            switch (this.energyRating)
            {
                case 12:
                    energy = "B";
                    break;
                case 15:
                    energy = "C";
                    break;
                case 20:
                    energy = "D";
                    break;
                case 90:
                    energy = "E";
                    break;
            }

            sb.AppendFormat(
                "Required energy efficiency rating: {0}{1}Power Usage(KW / h) {2}{1}",
                energy, 
                Environment.NewLine,
                this.PowerUsage)
            .Append("====================");

            return sb.ToString();
        }

        private void DeclareEnergyRating(string ennergyEfficiencyRating)
        {
            switch (ennergyEfficiencyRating)
            {
                case "A":
                    this.energyRating = 10;
                    break;
                case "B":
                    this.energyRating = 12;
                    break;
                case "C":
                    this.energyRating = 15;
                    break;
                case "D":
                    this.energyRating = 20;
                    break;
                case "E":
                    this.energyRating = 90;
                    break;
            }
        }
    }
}
