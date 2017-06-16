namespace AirConditionalTesterSystem.Interfaces
{
    public interface IAirConditioner
    {
        string Model { get; }

        string Manufacturer { get; }

        int Test();
    }
}
