using System;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Utilities;

namespace BigMani.Models.AirConditioners
{
    class PlaneAirConditioner : AirConditioner, IPlaneAirConditioner
    {
        private int volumeCovered;
        private int electricityUsed;

        public PlaneAirConditioner(string manufacturer, string model, int volumeCovered,
            int electricityUsed) : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
            this.ElectricityUsed = electricityUsed;
        }

        public override Mark Test()
        {
            double sqrtVolume = Math.Sqrt((double)volumeCovered);
            if (this.ElectricityUsed/sqrtVolume < 150)
            {
                return Mark.Passed;
            }
            return Mark.Failed;
        }

        public int VolumeCovered
        {
            get { return this.volumeCovered; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Volume Covered must be a positive integer.");
                }
                this.volumeCovered = value;
            }
        }

        public int ElectricityUsed
        {
            get { return this.electricityUsed; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Electricity Used must be a positive integer.");
                }
                this.electricityUsed = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Volume Covered: " + VolumeCovered + "\r\n" + "Electricity Used: " + ElectricityUsed + "\r\n" +
                "====================";
        }
    }
}
