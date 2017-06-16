namespace ISIS
{
    using Core;
    using Core.Factory;
    using Interfaces;
    using IO;

    public class ProgramMain
    {
        public static void Main()
        {
            var writer = new ConsoleWriter();
            var reader = new ConsoleReader();
            var factory = new GroupFactory();

            IRunnable engine = new Engine(reader, writer, factory);

            engine.Run();
        }
    }
}
