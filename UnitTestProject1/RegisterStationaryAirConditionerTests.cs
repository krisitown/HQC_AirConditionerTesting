using System;
using BigMani.Interfaces.ModuleInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigMani.Core.Modules;
using BigMani.Data_Layer;
using BigMani.Exceptions;
using BigMani.Models;
using BigMani.Models.AirConditioners;
using BigMani.Utilities;

namespace UnitTestProject1
{
    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        //no time for seperate files!!!

        static ConditionerData db = new ConditionerData();
        static RegisterModule registerModule = new RegisterModule(db);
        static SearchingModule searchingModule = new SearchingModule(db);
        static StatusModule statusModule = new StatusModule(db);

        [TestMethod] 
        public void RegisterStationaryAirConditioner_WithValidData_ShouldRegisterUnitSuccesfully()
        {
            Assert.AreEqual("Air Conditioner model MEGA SUPER from Sunrise registered successfully.",
                registerModule.RegisterStationaryAirConditioner("Sunrise", "MEGA SUPER",
                    "A", 50));

            Assert.AreEqual(db.AirConditioners.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_WithInvalidEnergyEfficiencyRating_ShouldThrowArgumentException()
        {

            registerModule.RegisterStationaryAirConditioner("Pesho pi4a", "moskvich",
                "Z", 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_WithInvalidManufacturerName_ShouldThrowArgumentException()
        {
            registerModule.RegisterStationaryAirConditioner("pi4", "moskvich",
                "B", 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_WithInvalidModelName_ShouldThrowArgumentException()
        {

            registerModule.RegisterStationaryAirConditioner("pesho pi4a", "",
                "B", 300);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationaryAirConditioner_WithNegativeNumber_ShouldThrowArgumentException()
        {

            registerModule.RegisterStationaryAirConditioner("pesho pi4a", "",
                "B", -300);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void RegisterStationaryAirConditioner_WithSameManufacturerAndModelName_ShouldThrowDuplicateEntryException()
        {

            registerModule.RegisterStationaryAirConditioner("pesho pi4a", "20ka",
                "A", 300);
            registerModule.RegisterStationaryAirConditioner("pesho pi4a", "20ka",
                "A", 300);
        }

        [TestMethod]
        public void WhenNoReportsExist_Method_Should_Return_None()
        {
            Assert.AreEqual("No reports.",
                searchingModule.FindAllReportsByManufacturer("Pesho"));
        }

        [TestMethod]
        public void WhenReportsExist_Method_Should_Return_None()
        {
            db.AddReport(new Report("Pesho", "Pi4a", Mark.Failed));
            db.AddReport(new Report("Pesho", "Moskvi4a", Mark.Passed));

            Assert.AreEqual("Reports from Pesho:\r\nReport\r\n====================\r\nManufacturer: Pesho\r\nModel: Moskvi4a\r\nMark: Passed" +
            "\r\n====================\r\n" + "Report\r\n====================\r\nManufacturer: Pesho\r\nModel: Pi4a\r\nMark: Failed" +
            "\r\n====================",
                searchingModule.FindAllReportsByManufacturer("Pesho"));
        }

        [TestMethod]
        public void Jobs_Completed_With_No_Jobs_Should_Be_Zero()
        {
            Assert.AreEqual("Jobs complete: 0.00%", statusModule.Status());
        }

        [TestMethod]
        public void Jobs_Completed_With_Two_Out_Of_Three_Jobs_Should_Be_Sixty_six()
        {
            db.AddReport(new Report("Pesho", "Pi4a", Mark.Failed));
            db.AddReport(new Report("Sasho", "Dido", Mark.Passed));
            db.AddReport(new Report("Gosho", "Misho", Mark.Passed));
            Assert.AreEqual("Jobs complete: 66.67%", statusModule.Status());
        }

    }
}
