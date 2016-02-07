using System;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Utilities;

namespace BigMani.Models.AirConditioners
{
    class CarAirConditioner : AirConditioner, ICarAirConditioner
    {
        private int volumeCovered;

        public CarAirConditioner(string manufacturer, string model,
            int volumeCovered) : base(manufacturer, model)
        {
            this.VolumeCovered = volumeCovered;
        }

        public override Mark Test()
        {
            double sqrtVolume = Math.Sqrt(volumeCovered);
            if (sqrtVolume < 3)
            {
                return Mark.Failed;
            }
            return Mark.Passed;
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

        public override string ToString()
        {
            return base.ToString() + "Volume Covered: " + VolumeCovered + "\r\n" + "====================";
        }
    }
}
