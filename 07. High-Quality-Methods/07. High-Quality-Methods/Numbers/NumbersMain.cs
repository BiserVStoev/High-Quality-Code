namespace Numbers
{
    using System;

    public class NumbersMain
    {
        public static void Main()
        {
            Console.WriteLine(NumberManipulations.DigitToWord(5));

            int maxNum = NumberManipulations.FindMax(5, -1, 3, 2, 14, 2, 3);
            Console.WriteLine(maxNum);

            NumberManipulations.PrintNumberInFormat(1.3, "f");
            NumberManipulations.PrintNumberInFormat(0.75, "%");
            NumberManipulations.PrintNumberInFormat(2.30, "r");
        }
    }
}
