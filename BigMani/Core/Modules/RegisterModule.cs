using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Interfaces.ModuleInterfaces;
using BigMani.Models.AirConditioners;
using BigMani.Utilities;

namespace BigMani.Core.Modules
{
    public class RegisterModule : DatabaseUsingModule, IRegisterModule
    {
        public RegisterModule(IConditionerData database) : base(database)
        {
        }

        public string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating, int powerUsage)
        {
            AirConditioner airConditioner = new StationaryAirConditioner(manufacturer, model, energyEfficiencyRating, powerUsage);
            database.AddAirConditioner(airConditioner);
            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        public string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage)
        {
            AirConditioner airConditioner = new CarAirConditioner(manufacturer, model, volumeCoverage);
            database.AddAirConditioner(airConditioner);
            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }

        /// <summary>
        /// This method is used to create and put a Plane Air Conditioner,
        /// in the specified database
        /// </summary>
        /// <param name="manufacturer">The name of the manufacturer of the Air Conditioner</param>
        /// <param name="model">The Model of the conditioner</param>
        /// <param name="volumeCoverage">The volume that the conditioner covers</param>
        /// <param name="electricityUsed">The amout of electricity used by the device</param>
        /// <returns>Returns a string with a message of wheather the action was completed successfully or not</returns>
        public string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed)
        {
            AirConditioner airConditioner = new PlaneAirConditioner(manufacturer, model, volumeCoverage, int.Parse(electricityUsed));
            database.AddAirConditioner(airConditioner);
            return string.Format(Constants.REGISTER, airConditioner.Model, airConditioner.Manufacturer);
        }
    }
}
