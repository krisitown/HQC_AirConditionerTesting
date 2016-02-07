using System;
using BigMani.Interfaces;
using BigMani.Utilities;

namespace BigMani.Models
{
    using System.Text;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, Mark mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public Mark Mark { get; set; }

        public override string ToString()
        {
            string result = "";

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + Manufacturer + "\r\n" +
                      "Model: " + Model + "\r\n" + "Mark: " + Mark + "\r\n" + "====================";

            return result;
        }
    }
}
