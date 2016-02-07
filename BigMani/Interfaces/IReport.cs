using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Utilities;

namespace BigMani.Interfaces
{
    /// <summary>
    /// Classes that implement this interface will hold
    /// the Manufacturer, the Model of the device and its Mark,
    /// which could be Passed or Failed, depending on its testing
    /// </summary>
    public interface IReport
    {
        string Manufacturer { get; }

        string Model { get; }

        Mark Mark { get; }
    }
}
