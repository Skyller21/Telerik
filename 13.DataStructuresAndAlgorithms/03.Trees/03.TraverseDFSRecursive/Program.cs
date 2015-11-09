using System;

namespace _03.TraverseDFSRecursive
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var start = @"C:\windows";
            var folder = new Folder(start);

            Console.WriteLine(@"Please be patient if you traverse ""c:\windows"" :)");

            // Build the tree
            folder = RecursiveDFS(folder);

            // Print the tree
            Print(folder, 0);

            // Select a folder to find it's size. It is implemented with folder name. It could be done with absolute path.
            var folderToFindSize = "windows";
            var size = Find(folder, 0, folderToFindSize, false);

            var sizeInMb = size / 1024.0 / 1024.0;
            var sizeInGb = sizeInMb / 1024.0;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSize of the folder \\{0}: {1} bytes = {2:F2} MB = {3:F2} GB", folderToFindSize, size, sizeInMb, sizeInGb);
        }

        public static Folder RecursiveDFS(Folder folder)
        {
            folder.IsUsed = true;
            try
            {
                var dirs = Directory.GetDirectories(folder.FolderPath);

                var files = Directory.GetFiles(folder.FolderPath);
                foreach (var file in files)
                {
                    var info = new FileInfo(file);
                    var fileToAdd = new File(Path.GetFileName(file), info.Length);
                    folder.Files.Add(fileToAdd);
                }

                foreach (var dir in dirs)
                {
                    var folderToAdd = new Folder(dir);
                    folder.SubFolders.Add(folderToAdd);
                    if (!folderToAdd.IsUsed)
                    {
                        RecursiveDFS(folderToAdd);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            return folder;
        }

        private static void Print(Folder folder, int level)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (level == 0)
            {
                Console.WriteLine("{0}{1}", new string(' ', level + 2), folder.FolderPath);
                level += 4;
            }
            else
            {
                Console.WriteLine("{0}{1}{2}", new string(' ', level + 2), @"\", folder.Name);
                level += 4;
            }

            Console.ForegroundColor = ConsoleColor.White;
            foreach (var file in folder.Files)
            {

                Console.WriteLine(new string(' ', level + 2) + file.Name);
            }

            foreach (var subFolder in folder.SubFolders)
            {
                Print(subFolder, level);
            }
        }

        private static long Find(Folder folder, long size, string folderTo, bool found)
        {
            // This one is used to check if the folder you search is the root directory :)
            if (folder.Name == folderTo)
            {
                found = true;
            }

            if (found)
            {
                foreach (var file in folder.Files)
                {
                    size += file.Size;
                }
            }

            foreach (var subFolder in folder.SubFolders)
            {
                found = Switch(folderTo, subFolder, found);

                size = Find(subFolder, size, folderTo, found);

                if (subFolder.Name == folderTo)
                {
                    return size;
                }
            }

            return size;
        }

        private static bool Switch(string folderTo, Folder subFolder, bool found)
        {
            if (subFolder.Name.ToLower() == folderTo.ToLower())
            {
                found = !found;
            }
            return found;
        }
    }
}
