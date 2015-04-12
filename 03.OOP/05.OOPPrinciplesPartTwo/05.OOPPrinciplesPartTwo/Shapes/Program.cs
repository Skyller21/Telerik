using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<Shape> shapes = new List<Shape>()
            {
                new Rectangle(5,5),
                new Rectangle(5.5,7),
                new Square(5),
                new Triangle(1,5),
                new Square(3)
            };

            foreach (var s in shapes)
            {
                Console.WriteLine(s);
            }

        }
    }
}
