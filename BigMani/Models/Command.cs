using System;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Utilities;

namespace BigMani.Models
{
    public class Command : ICommand
    {
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line.Substring(line.IndexOf('('))
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
