namespace Geometry
{
    using System;

    public class GeometryMain
    {
        public static void Main()
        {
            Console.Write("Triangle area: ");
            Console.WriteLine(GeometryMethods.CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine("Distance: ");
            Console.WriteLine(GeometryMethods.CalculateDistance(3, -1, 3, 2.5));

            bool isHorizontalLine = GeometryMethods.IsHorizontalLine(-1, 2.5);
            Console.WriteLine("Horizontal? " + isHorizontalLine);
            bool isVerticalLine = GeometryMethods.IsVerticalLine(3, 3);
            Console.WriteLine("Vertical? " + isVerticalLine);
        }
    }
}
