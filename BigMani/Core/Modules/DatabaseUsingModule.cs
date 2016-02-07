using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigMani.Interfaces.DatabaseInterfaces;

namespace BigMani.Core.Modules
{
    public abstract class DatabaseUsingModule
    {
        protected IConditionerData database;

        protected DatabaseUsingModule(IConditionerData database)
        {
            this.database = database;
        }
    }
}
