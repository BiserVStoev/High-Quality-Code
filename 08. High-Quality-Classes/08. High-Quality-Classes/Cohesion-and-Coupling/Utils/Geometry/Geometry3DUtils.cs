namespace CohesionAndCoupling.Utils.Geometry
{
    using System;

    public static class Geometry3DUtils
    {
        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));

            return distance;
        }

        public static double CalculateDiagonalXY(Point3D point3D)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(0, 0, point3D.Width, point3D.Height);
            return distance;
        }

        public static double CalculateDiagonalXZ(Point3D point3D)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(0, 0, point3D.Width, point3D.Depth);
            return distance;
        }

        public static double CalculateDiagonalYZ(Point3D point3D)
        {
            double distance = Geometry2DUtils.CalculateDistance2D(0, 0, point3D.Height, point3D.Depth);

            return distance;
        }

        public static double CalculateDiagonalXYZ(Point3D point3D)
        {
            double distance = CalculateDistance3D(0, 0, 0, point3D.Width, point3D.Height, point3D.Depth);

            return distance;
        }

        public static double CalcVolume(Point3D point3D)
        {
            double volume = point3D.Width * point3D.Height * point3D.Depth;

            return volume;
        }
    }
}
