namespace Numbers
{
    using System;

    public static class NumberManipulations
    {
        /// <summary>
        /// Converts a digit to it's name.
        /// </summary>
        /// <param name="number">The number to be converted.</param>
        /// <returns>The number as a word.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the number is not in the range 0...9</exception>
        public static string DigitToWord(int number)
        {
            const int MinDigit = 0;
            const int MaxDigit = 9;

            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException(nameof(number), $"Digit must be in range {MinDigit}...{MaxDigit}");
            }
        }

        /// <summary>
        /// Finds the biggest integer in an array of elements.
        /// </summary>
        /// <param name="elements">An array of integers.</param>
        /// <returns>The biggest integer.</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException(nameof(elements), "The elements cannot be empty.");
            }

            int maxInt = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxInt)
                {
                    maxInt = elements[i];
                }
            }

            return maxInt;
        }

        /// <summary>
        /// Prints a given number in a specific format.
        /// </summary>
        /// <param name="number">The number to be printed in a specific format.</param>
        /// <param name="format">The format in which the number will be printed.</param>
        public static void PrintNumberInFormat(object number, string format)
        {
            if (!IsANumber(number))
            {
                throw new ArgumentException("The object is not a numeric value.", nameof(number));
            }
           
            if (format == "f")  
            {
                Console.WriteLine("{0:f2}", number); // Prints the number with 2 digits after the decimal point.
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number); // Prints the number as a percentage.
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number); // Prints number formatted with 8 whitespaces behind it.
            }
			else
            {
                throw new ArgumentException("The specified format was not recognized.", nameof(format));
            }
        }

        /// <summary>
        /// Checks whether the given object is a number.
        /// </summary>
        /// <param name="number">The object which needs to be checked whether it's a number or not.</param>
        /// <returns>True if the object is a number and false if not.</returns>
        private static bool IsANumber(object number)
        {
            if (number is sbyte ||
                number is byte ||
                number is short ||
                number is ushort ||
                number is int ||
                number is uint ||
                number is float ||
                number is double ||
                number is decimal)
            {
                return true;
            }

            return false;
        }
    }
}
