using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MatrixClass
{

    public class Matrix
    {
        public int Rows
        {
            get { return MyMatrix.GetLength(0); }
        }
        public int Cols
        {
            get { return MyMatrix.GetLength(1); }
        }
        private int[,] myMatrix;

        public int[,] MyMatrix
        {
            get { return myMatrix; }
            set { myMatrix = value; }
        }

        public Matrix()
        {

        }
        public Matrix(int[,] matrix)
        {
            this.MyMatrix = matrix;
        }

        public static Matrix Add(Matrix m, Matrix n)
        {

            Matrix p = new Matrix(new int[m.Rows,m.Cols]);
            try
            {
                if (m.Rows != n.Rows || m.Cols != n.Cols)
                {
                    throw new ArgumentOutOfRangeException();
                }
                for (int row = 0; row < m.Rows; row++)
                {
                    for (int col = 0; col < m.Cols; col++)
                    {
                        p.MyMatrix[row, col] = m.MyMatrix[row, col] + n.MyMatrix[row, col];
                    }
                }
                return p;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("The matrices are not of the same size");
                Console.WriteLine(aore.Message);
                throw;
            }
        }

        public static Matrix Subtract(Matrix m, Matrix n)
        {

            Matrix p = new Matrix(new int[m.Rows, m.Cols]);
            try
            {
                if (m.Rows != n.Rows || m.Cols != n.Cols)
                {
                    throw new ArgumentOutOfRangeException();
                }
                for (int row = 0; row < m.Rows; row++)
                {
                    for (int col = 0; col < m.Cols; col++)
                    {
                        p.MyMatrix[row, col] = m.MyMatrix[row, col] - n.MyMatrix[row, col];
                    }
                }
                return p;
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("The matrices are not of the same size");
                Console.WriteLine(aore.Message);
                throw;
            }
        }


        public void PrintMatrix()
        {
            Matrix mat = new Matrix(MyMatrix);
            for (int i = 0; i < mat.Rows; i++)
            {
                for (int j = 0; j < mat.Cols; j++)
                {
                    Console.Write((mat.MyMatrix[i, j].ToString().PadLeft(4, ' ') + " "));
                }
                Console.WriteLine();
            }
        }
    }
  
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = { { 0, 1, 2 }, 
                              { 9, 8, 7 } };

            int[,] matrixOne = { { 6, 5, 4 }, 
                                 { 3, 4, 5 } };

            Matrix m = new Matrix(matrix);
            Matrix n = new Matrix(matrixOne);

            Matrix p = new Matrix();
            p = Matrix.Add(m, n);

            Matrix q = new Matrix();

            q = Matrix.Subtract(m, n);

            Console.WriteLine("Matrix A + Matrix B");
            p.PrintMatrix();
            Console.WriteLine("\nMatrix A - Matrix B");
            q.PrintMatrix();
        }
    }
}
