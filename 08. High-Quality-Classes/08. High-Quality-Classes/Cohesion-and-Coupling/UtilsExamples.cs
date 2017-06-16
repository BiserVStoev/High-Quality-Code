namespace CohesionAndCoupling
{
    using System;
    using Utils.Files;
    using Utils.Geometry;

    public class UtilsExamples
    {
        public static void Main()
        {
            try
            {
                Console.WriteLine(FileUtils.GetFileExtension("example"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine();

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                Geometry2DUtils.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                Geometry3DUtils.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            var point3D = new Point3D(3, 4, 5);

            Console.WriteLine("Volume = {0:f2}", Geometry3DUtils.CalcVolume(point3D));
            Console.WriteLine("Diagonal XYZ = {0:f2}", Geometry3DUtils.CalculateDiagonalXYZ(point3D));
            Console.WriteLine("Diagonal XY = {0:f2}", Geometry3DUtils.CalculateDiagonalXY(point3D));
            Console.WriteLine("Diagonal XZ = {0:f2}", Geometry3DUtils.CalculateDiagonalXZ(point3D));
            Console.WriteLine("Diagonal YZ = {0:f2}", Geometry3DUtils.CalculateDiagonalYZ(point3D));
        }
    }
}
