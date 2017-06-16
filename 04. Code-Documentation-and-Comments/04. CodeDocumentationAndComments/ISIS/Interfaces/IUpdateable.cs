namespace ISIS.Interfaces
{
    /// <summary>
    /// An intefcace that updates an implemented behaviour.
    /// </summary>
    public interface IUpdateable
    {
        /// <summary>
        /// Checks whether the implemented logic has been updated.
        /// </summary>
        bool HasUpdated { get; set; }

        /// <summary>
        /// Updates the implemented logic.
        /// </summary>
        void Update();
    }
}