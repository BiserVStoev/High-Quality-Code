namespace AirConditionalTesterSystem.UI
{
    using System;
    using Interfaces;

    public class ConsoleReader : IInputReader
    {
        public string ReadLine()
        {
            string message = Console.ReadLine();

            return message;
        }
    }
}
