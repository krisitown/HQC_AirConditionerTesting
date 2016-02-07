using System.Collections.Generic;

namespace BigMani.Interfaces.DatabaseInterfaces
{
    public interface IReportDatabase
    {
        void AddReport(IReport report);

        void RemoveReport(IReport airConditioner);

        Interfaces.IReport GetReport(string manufacturer, string model);

        List<IReport> GetReportsByManufacturer(string manufacturer);

        int GetReportsCount();
    }
}
