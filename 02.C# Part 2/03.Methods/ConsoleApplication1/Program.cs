using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static void Main(string[] args)
        {

            Circle circle = new Circle();
            Square square = new Square();

            DrawEverything(circle);
            DrawEverything(square);

            DrawSquare(circle);
            // COMPILE TIME ERROR: DrawSquare(circle); !!!!!!!!!!


            DrawCircle(circle);
            // COMPILE TIME ERROR: DrawCircle(square); !!!!!!!!!!
        }

        private static void DrawCircle(Circle c)
        {
            c.Draw(12, 19);
        }

        private static void DrawSquare(IDrawable b)
        {
            b.Draw(4, 15);
        }

        private static void DrawEverything(IDrawable something)
        {
            something.Draw(4, 2);
        }

    }

    class Circle : IDrawable
    {

        public int Radius { get; set; }

        public void Draw(int x, int y)
        {
            Console.WriteLine("Circle drawed at {0} {1}", x, y);
        }
    }

    class Square : IDrawable
    {

        public void Draw(int x, int y)
        {
            Console.WriteLine("Square drawed at {0} {1}", x, y);
        }
    }

    interface IDrawable
    {
        void Draw(int x, int y);
    }
}
