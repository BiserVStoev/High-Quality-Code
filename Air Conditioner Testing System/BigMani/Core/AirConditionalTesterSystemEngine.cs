namespace AirConditionalTesterSystem.Core
{
    using System;
    using Interfaces;
    using Models;

    public class AirConditionalTesterSystemEngine : IAirConditionalTesterSystemEngine
    {
        private readonly CommandExecutioner commandExecutioner;

        public AirConditionalTesterSystemEngine(IInputReader inputReader, IOutputWriter outputWriter, IAirConditionerDatabase database)
        {
            this.Reader = inputReader;
            this.Writer = outputWriter;
            this.commandExecutioner = new CommandExecutioner(this);
            this.Database = database;
        }

        public IInputReader Reader { get; private set; }

        public IOutputWriter Writer { get; private set; }

        public Command Command { get; set; }

        public IAirConditionerDatabase Database { get; private set; }

        public virtual void Run()
        {
            while (true)
            {
                string line = this.Reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                line = line.Trim();
                try
                {
                    this.Command = new Command(line);
                    this.commandExecutioner.Execute();
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
