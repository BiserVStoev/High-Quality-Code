namespace Huy_Phuong.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// An interface that should be implemented by performances databases.
    /// </summary>
    public interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to a databasae
        /// </summary>
        /// <param name="theatreName">The name of the theatre that will be added.</param>
        void AddTheatre(string theatreName);

        /// <summary>
        /// Creates a collection of all theatres in the database and returns them.
        /// </summary>
        /// <returns>Returns an IEnumerable collection.<string> with the names of all theatres in the database.</string></returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Creates an instance of the Performance class and adds it to a theatre in the database.
        /// </summary>
        /// <param name="theatreName">The name of the theatre to which the performance will be added.</param>
        /// <param name="performanceTitle">The name of the performance.</param>
        /// <param name="startDateTime">The starting date of the performance.</param>
        /// <param name="duration">The duration of the performance.</param>
        /// <param name="price">The price of the tickets of the performance.</param>
        /// <see cref="Performance"/>
        void AddPerformance(string theatreName, string performanceTitle, DateTime startDateTime, TimeSpan duration, decimal price);

        /// <summary>
        /// Creates a collection of all performances and returns it.
        /// </summary>
        /// <returns>Returns an IEnumerable<Performance> with all performances in the database.</Performance></returns>
        /// <see cref="Performance"/>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Creates a collection with all performances in a theater specified by the theatre name.
        /// </summary>
        /// <param name="theatreName">The name of the theatre which performances should be returned.</param>
        /// <returns>Returns an IEnumerable<Performance> with all performances in the specified theater.</Performance></returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}
