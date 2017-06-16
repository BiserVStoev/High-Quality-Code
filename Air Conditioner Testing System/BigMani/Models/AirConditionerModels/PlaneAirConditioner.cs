namespace AirConditionalTesterSystem.Models.AirConditionerModels
{
    using System;
    using System.Text;

    public class PlaneAirConditioner : AirConditioner
    {
        private int volumeCovered;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed) : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCoverage;
            this.ElectricityUsed = int.Parse(electricityUsed);
        }

        public int VolumeCovered
        {
            get
            {
                return this.volumeCovered;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NotPossitiveMessage, "Volume Covered"));
                }

                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get
            {
                return this.electricityUsed;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Constants.NotPossitiveMessage, "Electricity Used"));
                }

                this.electricityUsed = value;
            }
        }

        public override int Test()
        {
            double sqrtVolume = Math.Sqrt(this.volumeCovered);
            if (this.ElectricityUsed / sqrtVolume < Constants.MinPlaneElectricity)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString())
                .AppendFormat(
                    "Volume Covered: {0}{1}Electricity Used: {2}{1}",
                    this.VolumeCovered,
                    Environment.NewLine,
                    this.ElectricityUsed)
                .Append("====================");
            
            return sb.ToString();
        }
    }
}
