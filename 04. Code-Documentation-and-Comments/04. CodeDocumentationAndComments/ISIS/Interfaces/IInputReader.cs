namespace ISIS.Interfaces
{
    /// <summary>
    /// An interface for a reader.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Read's some text.
        /// </summary>
        /// <returns>Returns the input text.</returns>
        string ReadLine();
    }
}
