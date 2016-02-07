using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Interfaces.ModuleInterfaces;
using BigMani.Utilities;

namespace BigMani.Core.Modules
{
    public class StatusModule : DatabaseUsingModule, IStatusModule
    {
        public StatusModule(IConditionerData database)
            : base(database)
        {
        }
        
        /// <summary>
        /// Used to show a percentage of the jobs that were completed
        /// </summary>
        /// <returns>Returns a string value which shows a percentage
        /// of the passed tests for a manufacturer</returns>
        public string Status()
        {
            int reports = database.GetReportsCount();
            double airConditioners = database.GetAirConditionersCount();

            double percent = reports / airConditioners;
            percent = percent * 100;
            return string.Format(Constants.STATUS, percent);
        }
    }
}
