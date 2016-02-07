using System.Collections.Generic;
using System.Linq;
using BigMani.Exceptions;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Models;
using BigMani.Models.AirConditioners;
using BigMani.Utilities;

namespace BigMani.Data_Layer
{
    public class ConditionerData : IConditionerData
    {
        public ConditionerData()
        {
            AirConditioners = new List<IAirConditioner>();
            Reports = new List<IReport>();
        }

        public List<IAirConditioner> AirConditioners { get;  set; }

        public List<IReport> Reports { get;  set; }

        public void AddAirConditioner(IAirConditioner airConditioner)
        {
            if (GetAirConditioner(airConditioner.Manufacturer, airConditioner.Model) != null)
            {
                throw new DuplicateEntryException(Constants.DUPLICATE);
            }

            AirConditioners.Add(airConditioner);
        }

        public void RemoveAirConditioner(IAirConditioner airConditioner)
        {
            AirConditioners.Remove(airConditioner);
        }

        public IAirConditioner GetAirConditioner(string manufacturer, string model)
        {
            return AirConditioners.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetAirConditionersCount()
        {
            return AirConditioners.Count;
        }

        public void AddReport(IReport report)
        {
            if (GetReport(report.Manufacturer, report.Model) != null)
            {
                throw new DuplicateEntryException(Constants.DUPLICATE);
            }
            Reports.Add(report);
        }

        public void RemoveReport(IReport report)
        {
            Reports.Remove(report);
        }

        public IReport GetReport(string manufacturer, string model)
        {
            return Reports.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public int GetReportsCount()
        {
            return Reports.Count;
        }

        public List<IReport> GetReportsByManufacturer(string manufacturer)
        {
            return Reports.Where(x => x.Manufacturer == manufacturer).ToList();
        }
    }
}
