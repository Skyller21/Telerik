namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class MatrixProgram
    {
        static void Main(string[] args)
        {

            Matrix<double> matr = new Matrix<double>(2, 3);
            Matrix<double> matr2 = new Matrix<double>(3, 2);
            matr[0, 0] = 1;
            matr[0, 1] = 2;
            matr[0, 2] = 3;
            matr[1, 0] = 4;
            matr[1, 1] = 5;
            matr[1, 2] = 6;

            matr2[0, 0] = 7;
            matr2[0, 1] = 8;
            matr2[1, 0] = 9;
            matr2[1, 1] = 10;
            matr2[2, 0] = 11;
            matr2[2, 1] = 12;

            
            //Matrix<double> m = matr + matr2;
            Matrix<double> m2 = new Matrix<double>();
            m2 = matr * matr2;

            if (m2)
            {
                Console.WriteLine(true);
            }

            //Console.WriteLine(m[0,0]);
            //Console.WriteLine(m2[0,0]);
            Console.WriteLine(m2.ToString());
        }
    }
}
