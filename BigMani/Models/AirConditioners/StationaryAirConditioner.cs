using System;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Utilities;

namespace BigMani.Models.AirConditioners
{
    public class StationaryAirConditioner : AirConditioner, IStationaryAirConditioner
    {
        private int powerUsage;
        private string energyRating;

        public StationaryAirConditioner(string manufacturer, string model,
            string energyRating, int powerUsage) : base(manufacturer, model)
        {
            this.PowerUsage = powerUsage;
            this.EnergyRating = energyRating;
        }

        public override Mark Test()
        {
            int energyEfficiencyRating = 0;
            switch (energyRating)
            {
                case "A":
                    energyEfficiencyRating = 10;
                    break;
                case "B":
                    energyEfficiencyRating = 12;
                    break;
                case "C":
                    energyEfficiencyRating = 15;
                    break;
                case "D":
                    energyEfficiencyRating = 20;
                    break;
                case "E":
                    energyEfficiencyRating = 90;
                    break;
            }
            if (this.PowerUsage / 100 <= energyEfficiencyRating) //possible bug
            {
                return Mark.Passed;
            }
            return Mark.Failed;
        }

        public int PowerUsage
        {
            get { return this.powerUsage; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Power Usage must be a positive integer.");
                }
                this.powerUsage = value;
            }
        }

        public string EnergyRating
        {
            get { return this.energyRating; }
            set
            {
                if (Char.Parse(value) < 'A' || Char.Parse(value) > 'E')
                {
                    throw new ArgumentException("Energy efficiency rating must be between \"A\" and \"E\".");
                }
                this.energyRating = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Required energy efficiency rating: " + this.EnergyRating + "\r\n" +
                "Power Usage(KW / h): " + this.PowerUsage + "\r\n" + "====================";
        }
    }
}
