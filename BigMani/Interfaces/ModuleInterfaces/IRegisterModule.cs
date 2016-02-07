using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigMani.Interfaces.ModuleInterfaces
{
    public interface IRegisterModule
    {
        string RegisterStationaryAirConditioner(string manufacturer, string model, string energyEfficiencyRating,
            int powerUsage);

        string RegisterCarAirConditioner(string manufacturer, string model, int volumeCoverage);

        string RegisterPlaneAirConditioner(string manufacturer, string model, int volumeCoverage, string electricityUsed);


    }
}
