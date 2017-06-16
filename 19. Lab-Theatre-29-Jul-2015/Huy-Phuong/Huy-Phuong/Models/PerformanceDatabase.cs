namespace Huy_Phuong.Models
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;

    public class PerformanceDatabase: IPerformanceDatabase
    {
        private readonly Dictionary<string, HashSet<Performance>> theatres =
        new Dictionary<string, HashSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            if (this.theatres.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theatres[theatreName] = new HashSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theaters = this.theatres.Keys;

            return theaters;
        }

        public void AddPerformance(
            string theatreName,
            string performanceTitle,
            DateTime startDateTime,
            TimeSpan duration,
            decimal price)
        {
            if (!this.theatres.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var currentTheatre = this.theatres[theatreName];
            var endTime = startDateTime + duration;
            if (TheatreIsFreeOnGivenTime(currentTheatre, startDateTime, endTime))
            {
                throw new TimeDurationOverlapException("Error: Time/duration overlap");
            }

            var performanceToAdd = new Performance(performanceTitle, theatreName, startDateTime, duration, price);
            currentTheatre.Add(performanceToAdd);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.theatres.Keys;
            var allPerformances = new List<Performance>();
            foreach (var theater in theatres)
            {
                var performances = this.theatres[theater];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theatres.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.theatres[theatreName];

            return performances;
        }

        protected internal static bool TheatreIsFreeOnGivenTime(
            IEnumerable<Performance> performances,
            DateTime performanceToAddStartDate,
            DateTime performanceToAddEndDate)
        {
            foreach (var performance in performances)
            {
                var performanceStartDate = performance.Date;

                var performanceEndDate = performance.Date + performance.Duration;
                var overlaps = (performanceStartDate <= performanceToAddStartDate && performanceToAddStartDate <= performanceEndDate)
                    || (performanceStartDate <= performanceToAddEndDate && performanceToAddEndDate <= performanceEndDate)
                    || (performanceToAddStartDate <= performanceStartDate && performanceStartDate <= performanceToAddEndDate)
                    || (performanceToAddStartDate <= performanceEndDate && performanceEndDate <= performanceToAddEndDate);
                if (overlaps)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
