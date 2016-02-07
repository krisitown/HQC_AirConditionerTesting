using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.AirConditionerInterfaces;

namespace BigMani.Interfaces.ModuleInterfaces
{
    public interface IValidityModule
    {
        void ValidateParametersCount(ICommand command, int count);
    }
}
