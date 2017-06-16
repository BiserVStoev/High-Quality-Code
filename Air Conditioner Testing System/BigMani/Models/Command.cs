namespace AirConditionalTesterSystem.Models
{
    using System;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string line)
        {
            this.ValidateCommandAction(line);
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }

        private void ValidateCommandAction(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line.Substring(line.IndexOf(' ') + 1)
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommandMessage, ex);
            }
        }
    }
}
