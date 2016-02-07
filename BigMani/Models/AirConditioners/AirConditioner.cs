using System;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Utilities;

namespace BigMani.Models.AirConditioners
{
    public abstract class AirConditioner : IAirConditioner
    {
        private string manufacturer;
        private string model;

        protected AirConditioner(string manufacturer, string model)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value.Length < Constants.ManufacturerMinLength)
                {
                    throw new ArgumentException("Manufacturer's name must be at least "+ Constants.ManufacturerMinLength + " symbols long.");
                }
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value.Length < Constants.ModelMinLength)
                {
                    throw new ArgumentException("Model's name must be at least "+ Constants.ModelMinLength +" symbols long.");
                }
                this.model = value;
            }
        }

        public abstract Mark Test();

        public override string ToString()
        {
            return
                string.Format("Air Conditioner" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " +
                              this.Manufacturer + "\r\n" + "Model: " + this.Model + "\r\n");
        }
    }
}
