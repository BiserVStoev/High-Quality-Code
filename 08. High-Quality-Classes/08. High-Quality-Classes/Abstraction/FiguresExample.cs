namespace Abstraction
{
    using System;
    using Models;
    
    public class FiguresExample
    {
        public static void Main()
        {
            Figure circle = new Circle(5);
            Console.WriteLine(circle);

            Figure rectangle = new Rectangle(2, 3);
            Console.WriteLine(rectangle);
        }
    }
}
