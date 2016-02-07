using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Exceptions;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Models;
using BigMani.Utilities;

namespace BigMani.Core.Modules
{
    class TestingModule : DatabaseUsingModule, ITestingModule
    {
        public TestingModule(IConditionerData database)
            : base(database)
        {
        }

        public string TestAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = database.GetAirConditioner(manufacturer, model);
            if (airConditioner == null)
            {
                throw new NonExistantEntryException();
            }
            Mark mark = (Mark)airConditioner.Test();
            database.AddReport(new Report(airConditioner.Manufacturer, airConditioner.Model, mark));
            return string.Format(Constants.TEST, model, manufacturer);
        }
    }
}
