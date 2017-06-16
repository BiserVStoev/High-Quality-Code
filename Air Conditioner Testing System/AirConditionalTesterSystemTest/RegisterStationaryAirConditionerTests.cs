namespace AirConditionalTesterSystemTest
{
    using AirConditionalTesterSystem.Core;
    using AirConditionalTesterSystem.Interfaces;
    using AirConditionalTesterSystem.Models;
    using AirConditionalTesterSystem.Models.AirConditionerModels;
    using AirConditionalTesterSystem.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryAirConditionerTests
    {
        private IOutputWriter writer;
        private IInputReader reader;
        private AirConditionalTesterSystemEngine airConditionalTesterSystemEngine;
        private CommandExecutioner commandExecutioner;
        private IAirConditionerDatabase database;

        [TestInitialize]
        public void Initialize()
        {
            this.writer = new ConsoleWriter();
            this.reader = new ConsoleReader();
            this.database = new AirConditionerDatabase();
            this.airConditionalTesterSystemEngine = new AirConditionalTesterSystemEngine(this.reader, this.writer, this.database);
            this.commandExecutioner = new CommandExecutioner(this.airConditionalTesterSystemEngine);
        }
        
        [TestMethod]
        public void Test_RegisterAirConditioner_ShouldSendSuccessMessage()
        {
            AirConditioner airConditioner = new StationaryAirConditioner("Dell", "EX1000", "B", 1000);
            var command = new Command("RegisterStationaryAirConditioner (Toshiba,EX1000,B,1000)");
            this.airConditionalTesterSystemEngine.Command = command;
        }
    }
}
