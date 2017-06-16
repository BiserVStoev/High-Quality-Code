namespace Students
{
    using System;

    public class StudentsMain
    {
        public static void Main()
        {
            var peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 17))
            {
                AdditionalInfo = "From Sofia."
            };

            var stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03))
            {
                AdditionalInfo = "From Vidin, gamer, high results."
            };

            Console.WriteLine(
                "{0} older than {1} -> {2}",
                peter.FirstName,
                stella.FirstName,
                peter.IsOlderThan(stella));
        }
    }
}
