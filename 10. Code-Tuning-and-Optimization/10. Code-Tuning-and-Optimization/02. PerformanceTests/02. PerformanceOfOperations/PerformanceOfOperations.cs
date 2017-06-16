namespace _02.PerformanceOfOperations
{
    using System;
    using System.Diagnostics;

    public class PerformanceOfOperations
    {
        private const int Operations = 1000;

        private const int FirstIntNumber = 1;
        private const int SecondIntNumber = 5;

        private const long FirstLongNumber = 1L;
        private const long SecondLongNumber = 5;

        private const float FirstFloatNumber = 1.1f;
        private const float SecondFloatNumber = 3.14f;

        private const double FirstDoubleNumber = 1.1;
        private const double SecondDoubleNumber = 3.14;

        private const decimal FirstDecimalNumber = 1.1m;
        private const decimal SecondDecimalNumber = 3.14m;

        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();
            
            // Test int aggregation
            stopwatch.Start();
            IntegerAggregation();
            stopwatch.Stop();
            Console.WriteLine("Integer aggregation: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test long aggregation
            stopwatch.Start();
            LongAggregation();
            stopwatch.Stop();
            Console.WriteLine("Long aggregation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test float aggregation
            stopwatch.Start();
            FloatAggregation();
            stopwatch.Stop();
            Console.WriteLine("Float aggregation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test double aggregation
            stopwatch.Start();
            DoubleAggregation();
            stopwatch.Stop();
            Console.WriteLine("Double aggregation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test decimal aggregation
            stopwatch.Start();
            DecimalAggregation();
            stopwatch.Stop();
            Console.WriteLine("Decimal aggregation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();

            // Test int subtraction
            stopwatch.Start();
            IntegerSubtraction();
            stopwatch.Stop();
            Console.WriteLine("Integer subtraction: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test long subtraction
            stopwatch.Start();
            LongSubtraction();
            stopwatch.Stop();
            Console.WriteLine("Long subtraction: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test float subtraction
            stopwatch.Start();
            FloatSubtraction();
            stopwatch.Stop();
            Console.WriteLine("Float subtraction: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test double subtraction
            stopwatch.Start();
            DoubleSubtraction();
            stopwatch.Stop();
            Console.WriteLine("Double subtraction: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test decimal subtraction
            stopwatch.Start();
            DecimalSubtraction();
            stopwatch.Stop();
            Console.WriteLine("Decimal subtraction: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();

            // Test int incremention
            stopwatch.Start();
            IntegerIncrementation();
            stopwatch.Stop();
            Console.WriteLine("Integer incrementation: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test long incremention
            stopwatch.Start();
            LongIncrementation();
            stopwatch.Stop();
            Console.WriteLine("Long incrementation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test float incremention
            stopwatch.Start();
            FloatIncrementation();
            stopwatch.Stop();
            Console.WriteLine("Float incrementation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test double incremention
            stopwatch.Start();
            DoubleIncrementation();
            stopwatch.Stop();
            Console.WriteLine("Double incrementation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test decimal incremention
            stopwatch.Start();
            DecimalIncrementation();
            stopwatch.Stop();
            Console.WriteLine("Decimal incrementation: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();

            // Test int multiplication
            stopwatch.Start();
            IntegerMultiplication();
            stopwatch.Stop();
            Console.WriteLine("Integer multiplication: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test long multiplication
            stopwatch.Start();
            LongMultiplication();
            stopwatch.Stop();
            Console.WriteLine("Long multiplication: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test float multiplication
            stopwatch.Start();
            FloatMultiplication();
            stopwatch.Stop();
            Console.WriteLine("Float multiplication: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test double multiplication
            stopwatch.Start();
            DoubleMultiplication();
            stopwatch.Stop();
            Console.WriteLine("Double multiplication: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test decimal multiplication
            stopwatch.Start();
            DecimalMultiplication();
            stopwatch.Stop();
            Console.WriteLine("Decimal multiplication: " + stopwatch.Elapsed);

            stopwatch.Reset();

            Console.WriteLine();

            // Test int division
            stopwatch.Start();
            IntegerDivision();
            stopwatch.Stop();
            Console.WriteLine("Integer division: {0}", stopwatch.Elapsed);

            stopwatch.Reset();

            // Test long division
            stopwatch.Start();
            LongDivision();
            stopwatch.Stop();
            Console.WriteLine("Long division: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test float division
            stopwatch.Start();
            FloatDivision();
            stopwatch.Stop();
            Console.WriteLine("Float division: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test double division
            stopwatch.Start();
            DoubleDivision();
            stopwatch.Stop();
            Console.WriteLine("Double division: " + stopwatch.Elapsed);

            stopwatch.Reset();

            // Test decimal division
            stopwatch.Start();
            DecimalDivision();
            stopwatch.Stop();
            Console.WriteLine("Decimal division: " + stopwatch.Elapsed);

            stopwatch.Reset();
        }

        private static void IntegerAggregation()
        {
            int result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstIntNumber + SecondIntNumber;
            }
        }

        private static void LongAggregation()
        {
            long result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstLongNumber + SecondLongNumber;
            }
        }

        private static void FloatAggregation()
        {
            float result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstFloatNumber + SecondFloatNumber;
            }
        }

        private static void DoubleAggregation()
        {
            double result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDoubleNumber + SecondDoubleNumber;
            }
        }

        private static void DecimalAggregation()
        {
            decimal result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDecimalNumber + SecondDecimalNumber;
            }
        }

        private static void IntegerSubtraction()
        {
            int result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstIntNumber - SecondIntNumber;
            }
        }

        private static void LongSubtraction()
        {
            long result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstLongNumber - SecondLongNumber;
            }
        }

        private static void FloatSubtraction()
        {
            float result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstFloatNumber - SecondFloatNumber;
            }
        }

        private static void DoubleSubtraction()
        {
            double result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDoubleNumber - SecondDoubleNumber;
            }
        }

        private static void DecimalSubtraction()
        {
            decimal result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDecimalNumber - SecondDecimalNumber;
            }
        }

        private static void IntegerIncrementation()
        {
            int result = 0;

            for (int i = 0; i < Operations; i++)
            {
                result++;
            }
        }

        private static void LongIncrementation()
        {
            long result = 0L;

            for (int i = 0; i < Operations; i++)
            {
                result++;
            }
        }

        private static void FloatIncrementation()
        {
            float result = 0.1f;

            for (int i = 0; i < Operations; i++)
            {
                result++;
            }
        }

        private static void DoubleIncrementation()
        {
            double result = 0.1;

            for (int i = 0; i < Operations; i++)
            {
                result++;
            }
        }

        private static void DecimalIncrementation()
        {
            decimal result = 0.1m;

            for (int i = 0; i < Operations; i++)
            {
                result++;
            }
        }

        private static void IntegerMultiplication()
        {
            int result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstIntNumber * SecondIntNumber;
            }
        }

        private static void LongMultiplication()
        {
            long result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstLongNumber * SecondLongNumber;
            }
        }

        private static void FloatMultiplication()
        {
            float result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstFloatNumber * SecondFloatNumber;
            }
        }

        private static void DoubleMultiplication()
        {
            double result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDoubleNumber * SecondDoubleNumber;
            }
        }

        private static void DecimalMultiplication()
        {
            decimal result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDecimalNumber * SecondDecimalNumber;
            }
        }

        private static void IntegerDivision()
        {
            int result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstIntNumber / SecondIntNumber;
            }
        }

        private static void LongDivision()
        {
            long result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstLongNumber / SecondLongNumber;
            }
        }

        private static void FloatDivision()
        {
            float result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstFloatNumber / SecondFloatNumber;
            }
        }

        private static void DoubleDivision()
        {
            double result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDoubleNumber / SecondDoubleNumber;
            }
        }

        private static void DecimalDivision()
        {
            decimal result;

            for (int i = 0; i < Operations; i++)
            {
                result = FirstDecimalNumber / SecondDecimalNumber;
            }
        }
    }
}
