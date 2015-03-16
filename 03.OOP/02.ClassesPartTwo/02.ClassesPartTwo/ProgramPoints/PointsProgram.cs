namespace ProgramPoints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class PointsProgram
    {
        static void Main(string[] args)
        {
            //Add some points
            Point3D p1 = new Point3D(1, 1, 1);
            Point3D p2 = new Point3D(2, 2, 2);
            Point3D p3 = new Point3D(3, 3, 3);
            Point3D p4 = new Point3D(4, 4, 4);

            //Add the center point (static property)
            Point3D center = Point3D.CenterPoint;
            
            //Create path
            Path path = new Path();
            //Add some points to the path
            path.AddMultiple(center, p1, p2, p3, p4);


            Console.WriteLine("The path lenght is: {0}",path.PathLength);
            Console.WriteLine("\nThe path is:\n{0}",path.ToString());

            //Change point at position [0]
            path[0] = new Point3D(3, 12, 4);
            //Remove center point
            path.Remove(p2);
            //Add point 
            path.Add(new Point3D(3,1,3.3));
            path.RemoveAt(1);
            Console.WriteLine("\nThe path after changing is:\n{0}",path.ToString());

            double dist = Calculator.CalculateDistance(p1, center);
            Console.WriteLine("\nThe distance between p1({0}) and center({1}) = {2}",p1.ToString(), center.ToString(), dist);

            string fileToSave = @"../../PATHS/file.txt";
            PathStorage.SavePath(fileToSave, path);


            string fileToLoad = @"../../PATHS/fileToLoad.txt";
            Path pathFromFile = PathStorage.LoadPath(fileToLoad);


            Console.WriteLine("\nThe loaded path is:\n{0}",pathFromFile.ToString());

            


            


        }
    }
}
