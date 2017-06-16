namespace ISIS.Interfaces
{
    /// <summary>
    /// An interface for a group of people.
    /// </summary>
    public interface IGroup
    {
        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the initial health of the group.
        /// </summary>
        int InitialHealth { get; }

        /// <summary>
        /// Gets the current health of the group.
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Gets the current damage of the group.
        /// </summary>
        int Damage { get; set; }

        /// <summary>
        /// Checks whether the group is alive.
        /// </summary>
        bool IsAlive { get; set; }
    }
}
