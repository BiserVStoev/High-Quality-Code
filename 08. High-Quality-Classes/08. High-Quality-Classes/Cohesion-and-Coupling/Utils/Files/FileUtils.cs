namespace CohesionAndCoupling.Utils.Files
{
    using System;

    public static class FileUtils
    {
        public static string GetFileExtension(string fileName)
        {
            CheckIfNullOrEmpty(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Extension not found.", nameof(fileName));
            }

            string extension = fileName.Substring(indexOfLastDot + 1);

            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            CheckIfNullOrEmpty(fileName);

            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string fileNameWithoutExtension = fileName.Substring(0, indexOfLastDot);

            return fileNameWithoutExtension;
        }

        private static void CheckIfNullOrEmpty(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName), "FileUtils name cannot be null or empty.");
            }
        }
    }
}
