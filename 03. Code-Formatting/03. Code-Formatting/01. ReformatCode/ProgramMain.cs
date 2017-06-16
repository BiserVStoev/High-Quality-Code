namespace _01.ReformatCode
{
    using System;

    public class ProgramMain
    {
        public static void Main()
        {
            while (CommandManager.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.GetMessage);
        }
    }
}
