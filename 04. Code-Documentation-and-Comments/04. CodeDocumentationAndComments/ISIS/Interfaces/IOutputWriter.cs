namespace ISIS.Interfaces
{
    /// <summary>
    /// An interface for a writer.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Prints something.
        /// </summary>
        /// <param name="message">The message to be printed.</param>
        void Print(string message);
    }
}
