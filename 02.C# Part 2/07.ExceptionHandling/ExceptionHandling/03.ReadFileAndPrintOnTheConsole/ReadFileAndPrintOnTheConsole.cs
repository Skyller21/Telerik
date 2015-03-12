using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReadFileAndPrintOnTheConsole
{
    static void Main()
    {
        try
        {
            ReadFile();
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("There is no path given.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The path is zero lenght, contains only spaces or one or more unsopported characters.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have permision to get to this file");
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("The system is out of memory");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The path of the file is too long");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The directory is not found or doesn't exist.");
        }
        catch (DriveNotFoundException)
        {
            Console.WriteLine("The drive is not found or doesn't exist");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file is not found.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The path is invalid.");
        }
        catch (IOException ioex)
        {
            Console.WriteLine(ioex.Message);
        }
    }

    static void ReadFile()
    {
        Console.WriteLine("Enter the file path");
        string path = Console.ReadLine();
        StreamReader file = new StreamReader(path, Encoding.Unicode);

        using (file)
        {
            Console.WriteLine();
            string text = file.ReadToEnd();
            Console.WriteLine(text);
            Console.WriteLine();
        }
    }
}

