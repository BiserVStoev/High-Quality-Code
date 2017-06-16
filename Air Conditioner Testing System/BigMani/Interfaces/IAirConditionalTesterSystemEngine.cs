namespace AirConditionalTesterSystem.Interfaces
{
    using Models;

    public interface IAirConditionalTesterSystemEngine
    {
        IInputReader Reader { get; }

        IOutputWriter Writer { get; }

        Command Command { get; }

        IAirConditionerDatabase Database { get; }
    }
}
