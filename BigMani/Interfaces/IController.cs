using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.AirConditionerInterfaces;

namespace BigMani.Interfaces
{
    public interface IController
    {
        void ExecuteCommand(ICommand command);
    }
}
