namespace Geometry
{
    using System;

    public static class GeometryMethods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("All sides of the triangle should be positive!");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentException("The sides do not form a triangle. The sum of 2 sides must be greated than the 3rd.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;

            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }

        public static bool IsHorizontalLine(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;

            return isHorizontal;
        }

        public static bool IsVerticalLine(double x1, double x2)
        {
            bool isVertical = x1 == x2;

            return isVertical;
        }
    }
}
