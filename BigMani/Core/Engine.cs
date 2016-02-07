using System;
using BigMani.Data_Layer;
using BigMani.Interfaces;
using BigMani.Models;
using BigMani.Utilities;

namespace BigMani.Core
{
    public class Engine
    {
        public IController controller;

        public IUserInterface ui;

        public Command command;

        public Engine(IUserInterface userInterface, IController controller)
        {
            this.controller = controller;
            this.ui = userInterface;
        }


        public void Run()
        {
            while (true)
            {
                string line = this.ui.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    command = new Command(line);
                    this.controller.ExecuteCommand(command);
                }
                catch (InvalidOperationException ex)
                {
                    this.ui.WriteLine(ex.Message); //PERFORMANCE: Throwing and catching exceptions instead of returning strings in order to write on the output
                }
            }
        }
    }
}
