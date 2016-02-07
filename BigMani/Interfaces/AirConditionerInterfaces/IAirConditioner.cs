using System.Security.Cryptography.X509Certificates;
using BigMani.Utilities;

namespace BigMani.Interfaces.AirConditionerInterfaces
{
    public interface IAirConditioner
    {
        string Manufacturer { get; set; }

        string Model { get; set; }

        Mark Test();
    }
}
