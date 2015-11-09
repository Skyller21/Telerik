using System;

namespace _02.TraverseDir
{
    using System.IO;
    using System.Threading;

    class Program
    {
        const string StartPath = @"C:\WINDOWS";
        const string Mask = @"*.exe";

        static void Main(string[] args)
        {
            Console.Write("It's starting after...");
            for (int i = 5; i > 0; i--)
            {
                Console.Write("{0} ", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            Traverse(StartPath, Mask);
        }

        private static void Traverse(string path, string mask)
        {

            var files = Directory.GetFiles(path, mask);
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }

            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                try
                {
                    Directory.GetFiles(dir, mask);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
                Traverse(dir, mask);
            }
        }



    }
}
