using System;
using System.IO;
using System.Net;

class DownloadFile
{
    static void Main(string[] args)
    {
        try
        {
            DownloadFileFromNet();
        }
        catch (WebException)
        {
            Console.WriteLine("The URL adress is invalid.");
        }
    }

    static void DownloadFileFromNet()
    {
        var currentDir = Directory.GetCurrentDirectory();
        using (WebClient file = new WebClient())
            file.DownloadFile("http://telerikacademy.com/Content/Images/news-img01.png", "Ninja.jpg");
        Console.WriteLine("You can find the downloaded file in:\n\r{0}", currentDir);
    }
}

