using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Interfaces.ModuleInterfaces;
using BigMani.Utilities;

namespace BigMani.Core.Modules
{
    class ValidityModule : IValidityModule
    {
        public void ValidateParametersCount(ICommand command, int count)
        {
            if (command.Parameters.Length != count)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND);
            }
        }
    }
}
