using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Exceptions;
using BigMani.Interfaces.AirConditionerInterfaces;

namespace BigMani.Interfaces.ModuleInterfaces
{
    public interface ISearchingModule
    {
        string FindAirConditioner(string manufacturer, string model);

        string FindReport(string manufacturer, string model);

        string FindAllReportsByManufacturer(string manufacturer);


    }
}
