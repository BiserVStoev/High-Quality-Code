namespace AirConditionalTesterSystem.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        string[] Parameters { get; }
    }
}
