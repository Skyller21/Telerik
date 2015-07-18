namespace CohesionAndCoupling
{
    using System;
    
    public class FileUtils
    {
        public static string GetFileExtension(string fullFileName)
        {
            int indexOfLastDot = fullFileName.LastIndexOf(".");
            if (indexOfLastDot < 0)
            {
                throw new ArgumentOutOfRangeException("The file has not extension.");
            }

            string extension = fullFileName.Substring(indexOfLastDot + 1, fullFileName.Length - indexOfLastDot - 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fullFileName)
        {
            int indexOfLastDot = fullFileName.LastIndexOf(".");
            if (indexOfLastDot < 0)
            {
                return fullFileName;
            }

            string fileName = fullFileName.Substring(0, indexOfLastDot);
            return fileName;
        }
    }
}
