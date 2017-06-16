namespace Huy_Phuong
{
    using Models;

    public class TheatreManager
    {
        protected static void Main()
        {
            var appender = new ConsoleAppender();
            var reader = new ConsoleReader();
            var database = new PerformanceDatabase();

            var commandManager = new CommandManager(database, appender, reader);
            commandManager.Run();
        }
    }
}