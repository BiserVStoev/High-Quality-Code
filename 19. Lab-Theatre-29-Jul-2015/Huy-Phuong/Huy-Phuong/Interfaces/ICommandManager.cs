namespace Huy_Phuong.Interfaces
{
    public interface ICommandManager
    {
        IPerformanceDatabase Database { get; }

        IAppender Appender { get; }

        IReader Reader { get; }

        void Run();
    }
}
