namespace ProgramPoints
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class PathStorage
    {
        public static void SavePath(string file, Path path)
        {
            try
            {
                File.WriteAllText(file, path.ToString());
            }
            catch (AccessViolationException avex)
            {
                
                throw avex;
            }
            catch(IOException ioex)
            {
                throw ioex;
            }
            
        }

        public static Path LoadPath(string file)
        {
            Path path = new Path();
            try
            {
                
                string text = File.ReadAllText(file);
                string[] points = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in points)
                {
                    string[] coordinates = item.Split(new string[] {",",", "," "},StringSplitOptions.RemoveEmptyEntries);
                    path.Add(new Point3D(double.Parse(coordinates[0]), double.Parse(coordinates[1]), double.Parse(coordinates[2])));
                }

            }
            catch (FileNotFoundException fnfe)
            {

                Console.WriteLine("####The file is not found");
                throw fnfe;
            }
            catch (IOException ioex)
            {
                throw ioex;
            }
            //Second way of doing it
            //try
            //{
            //    StreamReader reader = new StreamReader(file);
            //    using (reader)
            //    {
            //        string line = reader.ReadLine();
            //        while (line != null)
            //        {
            //            string[] coordinates = line.Split(new string[] {",",", "," "},StringSplitOptions.RemoveEmptyEntries);
            //            path.Add(new Point3D(double.Parse(coordinates[0]), double.Parse(coordinates[1]), double.Parse(coordinates[2])));
            //            line = reader.ReadLine();
            //        }
                    
            //    }
            //}
            //catch (FileNotFoundException fnfe)
            //{
            //    Console.WriteLine("####The file is not found");
            //    throw fnfe;
            //}
            //catch (IOException ioex)
            //{
            //    throw ioex;
            //}
            return path;
        }
    }
}
