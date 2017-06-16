namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class CoursesExamples
    {
        public static void Main()
        {
            Course localCourse =
                new LocalCourse("Databases", "Svetlin Nakov", new List<string>() { "Peter", "Maria" }, "Enterprise");
            Console.WriteLine(localCourse);
            
            localCourse.AddStudent("Milena");
            localCourse.AddStudent("Todor");
            Console.WriteLine(localCourse);

            Course offsiteCourse = 
                new OffsiteCourse(
                    "PHP and WordPress Development",
                    "Mario Peshev",
                    new List<string>() { "Thomas", "Ani", "Steve" },
                    "Sofia");
            Console.WriteLine(offsiteCourse);
        }
    }
}
