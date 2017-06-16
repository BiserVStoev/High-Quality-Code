namespace AirConditionalTesterSystem.Interfaces
{
    /// <summary>
    /// An interface intendet for implementation by reports, which hold data and with that data 
    /// it is decided whether the report is a fail or a success.
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Holds the name of the manufacturer of a product.
        /// </summary>
        string Manufacturer { get; }

        /// <summary>
        /// Holds the model name of a given product.
        /// </summary>
        string Model { get; }

        /// <summary>
        /// Holds the makr of the product, which determines wheter it passes or fails.
        /// </summary>
        int Mark { get; }
    }
}
