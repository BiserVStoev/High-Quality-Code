namespace Huy_Phuong.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Exceptions;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        private IPerformanceDatabase database;
        private IAppender appender;
        private IReader reader;

        public CommandManager(IPerformanceDatabase database, IAppender appender, IReader reader)
        {
            this.Database = database;
            this.Appender = appender;
            this.Reader = reader;
        }

        public IPerformanceDatabase Database
        {
            get
            {
                return this.database;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("database", "Database cannot be null.");
                }

                this.database = value;
            }
        }

        public IAppender Appender
        {
            get
            {
                return this.appender;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("appender", "Appender cannot be null.");
                }

                this.appender = value;
            }
        }

        public IReader Reader
        {
            get
            {
                return this.reader;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("reader", "Reader cannot be null.");
                }

                this.reader = value;
            }
        }

        public void Run()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            string command = this.Reader.ReadLine();

            while (true)
            {
                if (command == null || command.Trim() == string.Empty)
                {
                    return;
                }
                else
                {
                    var result = this.ProcessCommand(command);
                    this.appender.Write(result);
                }

                command = this.Reader.ReadLine();
            }
        }

        private string ProcessCommand(string command)
        {
            string[] commandArgs = command.Split(new[] {'(', ',', ')'}, StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            commandArgs = commandArgs.Select(p => p.Trim()).ToArray();
            string result;
            switch (commandName)
            {
                case "AddTheatre":
                {
                    result = this.ExecuteAddTheatreCommand(commandArgs);
                    break;
                }

                case "PrintAllTheatres":
                {
                    result = this.ExecutePrintAllTheatresCommand();
                    break;
                }

                case "AddPerformance":
                {
                    result = this.ExecuteAddPerformanceCommand(commandArgs);
                    break;
                }

                case "PrintAllPerformances":
                {
                    result = this.ExecutePrintAllPerformancesCommand();
                    break;
                }

                case "PrintPerformances":
                {
                    result = this.ExecutePrintPerformancesCommand(commandArgs);
                    break;
                }

                default:
                {
                    result = "Invalid Command";
                    break;
                }
            }

            return result;
        }

        private string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[1];
            try
            {
                this.database.AddTheatre(theatreName);
                return "Theatre added";
            }
            catch (DuplicateTheatreException ex)
            {
                return ex.Message;
            }
        }

        private string ExecutePrintAllTheatresCommand()
        {
            var theatresCount = this.Database.ListTheatres()
                .Count();

            if (theatresCount > 0)
            {
                var resultTheatres = new LinkedList<string>();
                for (int i = 0; i < theatresCount; i++)
                {
                    this.Database
                        .ListTheatres()
                        .Skip(i)
                        .ToList()
                        .ForEach(t => resultTheatres.AddLast(t));
                    foreach (var t in this.Database.ListTheatres().Skip(i + 1))
                    {
                        resultTheatres.Remove(t);
                    }
                }

                return string.Join(", ", resultTheatres);
            }

            return "No theatres";
        }

        private string ExecutePrintAllPerformancesCommand()
        {
            var allPerformances = this.Database.ListAllPerformances().ToList();
            allPerformances = allPerformances
                .OrderBy(performance => performance.Theater)
                .ThenBy(performance => performance.Date)
                .ToList();

            if (allPerformances.Any())
            {
                var result = new StringBuilder();

                for (int i = 0; i < allPerformances.Count; i++)
                {
                    result.AppendFormat(
                        "({0}, {1}, {2}), ",
                        allPerformances[i].Name,
                        allPerformances[i].Theater,
                        allPerformances[i].Date.ToString("dd.MM.yyyy HH:mm")
                        );
                }

                result.Remove(result.Length - 2, 2);

                return result.ToString();
            }

            return "No performances";
        }

        private string ExecutePrintPerformancesCommand(string[] commandArgs)
        {
            var theatre = commandArgs[1];
            try
            {
                var allPerformances = this.database.ListPerformances(theatre);
                allPerformances = allPerformances.OrderBy(performance => performance.Date);
                if (allPerformances.Count() == 0)
                {
                    return "No performances";
                }

                return string.Join(", ", allPerformances);
            }
            catch (TheatreNotFoundException ex)
            {
                return ex.Message;
            }
        }

        private string ExecuteAddPerformanceCommand(string[] commandArgs)
        {
            string theatreName = commandArgs[1];
            string performanceName = commandArgs[2];
            DateTime date = DateTime.ParseExact(commandArgs[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(commandArgs[4]);
            decimal price = decimal.Parse(commandArgs[5]);
            try
            {
                this.database.AddPerformance(theatreName, performanceName, date, duration, price);
                return "Performance added";
            }
            catch (TheatreNotFoundException ex)
            {
                return ex.Message;
            }
            catch (TimeDurationOverlapException ex)
            {
                return ex.Message;
            }
        }
    }
}
