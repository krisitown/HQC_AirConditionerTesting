using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Exceptions;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Interfaces.ModuleInterfaces;
using BigMani.Utilities;

namespace BigMani.Core.Modules
{
    public class SearchingModule : DatabaseUsingModule, ISearchingModule
    {


        public SearchingModule(IConditionerData database)
            : base(database)
        {
        }

        /// <summary>
        /// A method used to search through the database in order to find
        /// an air conditioner by manufacturer and model
        /// </summary>
        /// <param name="manufacturer">The manufacturer you would be searching for</param>
        /// <param name="model"> The model that you would be searching for</param>
        /// <returns>returns a string with the specifications of the found device</returns>
        public string FindAirConditioner(string manufacturer, string model)
        {
            IAirConditioner airConditioner = database.GetAirConditioner(manufacturer, model);
            if (airConditioner == null)
            {
                throw new NonExistantEntryException();
            }
            return airConditioner.ToString();
        }

        public string FindReport(string manufacturer, string model)
        {
            IReport report = database.GetReport(manufacturer, model);
            if (report == null)
            {
                throw new NonExistantEntryException();
            }
            return report.ToString();
        }

        public string FindAllReportsByManufacturer(string manufacturer)
        {
            List<IReport> reports = database.GetReportsByManufacturer(manufacturer);
            if (reports.Count == 0)
            {
                return Constants.NOREPORTS;
            }

            reports = reports.OrderBy(x => x.Mark).ToList();
            StringBuilder reportsPrint = new StringBuilder();
            reportsPrint.AppendLine(string.Format("Reports from {0}:", manufacturer));
            reportsPrint.Append(string.Join(Environment.NewLine, reports));
            return reportsPrint.ToString();
        }

    }
}
