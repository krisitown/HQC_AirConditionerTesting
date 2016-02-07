using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BigMani.Core.Modules;
using BigMani.Exceptions;
using BigMani.Interfaces;
using BigMani.Interfaces.AirConditionerInterfaces;
using BigMani.Interfaces.DatabaseInterfaces;
using BigMani.Interfaces.ModuleInterfaces;
using BigMani.Models;
using BigMani.Models.AirConditioners;
using BigMani.Utilities;

namespace BigMani.Core
{
    public class Controller : IController
    {
        public ICommand command;
        private IConditionerData database;
        private IRegisterModule registerModule;
        private ITestingModule testingModule;
        private ISearchingModule searchingModule;
        private IValidityModule validityModule;
        private IStatusModule statusModule;
        public IUserInterface ui;

        public Controller(IUserInterface ui, IConditionerData database, IRegisterModule registerModule, ITestingModule testingModule, 
            ISearchingModule searchingModule, IValidityModule validityModule, IStatusModule statusModule)
        {
            this.ui = ui;
            this.database = database;
            this.registerModule = registerModule;
            this.testingModule = testingModule;
            this.searchingModule = searchingModule;
            this.validityModule = validityModule;
            this.statusModule = statusModule;
        }

        public void ExecuteCommand(ICommand command)
        {
            this.command = command;

            try
            {
                switch (command.Name)
                {
                    case "RegisterStationaryAirConditioner":
                        validityModule.ValidateParametersCount(command, 4);
                        ui.WriteLine(registerModule.RegisterStationaryAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            command.Parameters[2],
                            int.Parse(command.Parameters[3])));
                        break;
                    case "RegisterCarAirConditioner":
                        validityModule.ValidateParametersCount(command, 3);
                        ui.WriteLine(registerModule.RegisterCarAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2])));
                        break;
                    case "RegisterPlaneAirConditioner":
                        validityModule.ValidateParametersCount(command, 4);
                        ui.WriteLine(registerModule.RegisterPlaneAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1],
                            int.Parse(command.Parameters[2]),
                            command.Parameters[3]));
                        break;
                    case "TestAirConditioner":
                        validityModule.ValidateParametersCount(command, 2);
                        ui.WriteLine(testingModule.TestAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]));
                        break;
                    case "FindAirConditioner":
                        validityModule.ValidateParametersCount(command, 2);
                        ui.WriteLine(searchingModule.FindAirConditioner(
                            command.Parameters[0],
                            command.Parameters[1]));
                        break;
                    case "FindReport":
                        validityModule.ValidateParametersCount(command, 2);
                        ui.WriteLine(searchingModule.FindReport(
                            command.Parameters[0],
                            command.Parameters[1]));
                        break;
                    case "Status":
                        validityModule.ValidateParametersCount(command, 0);
                        ui.WriteLine(statusModule.Status());
                        break;
                    case "FindAllReportsByManufacturer":
                        validityModule.ValidateParametersCount(command, 1);
                        ui.WriteLine(searchingModule.FindAllReportsByManufacturer(command.Parameters[0]));
                        break;
                    default:
                        throw new IndexOutOfRangeException(Constants.INVALIDCOMMAND);
                }
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND, ex.InnerException);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new InvalidOperationException(Constants.INVALIDCOMMAND, ex.InnerException);
            }
            catch (NonExistantEntryException)
            {
                throw new InvalidOperationException(Constants.NONEXIST);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            catch (DuplicateEntryException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
