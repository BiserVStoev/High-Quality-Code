namespace AirConditionalTesterSystem
{
    using Core;
    using UI;

    public class AirCondiditonerMain
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var database = new AirConditionerDatabase();

            var engine = new AirConditionalTesterSystemEngine(reader, writer, database);
            engine.Run();
        }
    }
}
