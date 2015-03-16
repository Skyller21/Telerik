namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix<T> where T : IConvertible
    {
        private T[,] myMatrix;
        private int rows;
        private int cols;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }


        public T[,] MyMatrix
        {
            get { return myMatrix; }
            set { myMatrix = value; }
        }

        public Matrix()
        {
            
        }
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.MyMatrix = new T[rows, cols];
        }

        public T this[int row, int col]
        {
            get
            {
                return this.MyMatrix[row, col];
            }
            set
            {
                this.MyMatrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> mat1, Matrix<T> mat2)
        {

            if (mat1.Rows != mat2.Rows || mat1.Cols != mat2.Cols)
                throw new ArgumentOutOfRangeException("The matrices are not the same size!");

            Matrix<T> matrixResult = new Matrix<T>(mat1.Rows, mat1.Cols);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Cols; j++)
                {
                    //With dynamic
                    matrixResult[i, j] = (dynamic)mat1[i, j] + mat2[i, j];

                    //With cast and IConvertible
                    //matrixResult[i, j] = (T)(object)(Convert.ToDouble(mat1[i, j]) + Convert.ToDouble(mat2[i, j]));
                }
            }
            return matrixResult; ;
        }

        public static Matrix<T> operator -(Matrix<T> mat1, Matrix<T> mat2)
        {

            if (mat1.Rows != mat2.Rows || mat1.Cols != mat2.Cols)
                throw new ArgumentOutOfRangeException("The matrices are not the same size!");

            Matrix<T> matrixResult = new Matrix<T>(mat1.Rows, mat1.Cols);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Cols; j++)
                {
                    //With dynamic
                    matrixResult[i, j] = (dynamic)mat1[i, j] - mat2[i, j];

                    //With cast and IConvertible
                    //matrixResult[i, j] = (T)(object)(Convert.ToDouble(mat1[i, j]) - Convert.ToDouble(mat2[i, j]));
                }
            }
            return matrixResult;
        }

        public static Matrix<T> operator *(Matrix<T> mat1, Matrix<T> mat2)
        {

            if (mat1.Rows != mat2.Cols || mat1.Cols != mat2.Rows)
                throw new ArgumentOutOfRangeException("The with these sizes cannot be multiplied rows1!=cols2 or cols1!=rows2");

            Matrix<T> matrixResult = new Matrix<T>(mat1.Rows, mat2.Cols);

            for (int row = 0; row < mat1.Rows; row++)
            {
                for (int col = 0; col < mat2.Cols; col++)
                {
                    for (int k = 0; k < mat1.Cols; k++)
                    {
                        //With dynamic
                        matrixResult[row, col] += (dynamic)mat1[row, k] * mat2[k, col];
                    }
                }
            }
            return matrixResult;
        }

        public static bool operator true(Matrix<T> mat1)
        {
            for (int row = 0; row < mat1.Rows; row++)
            {
                for (int col = 0; col < mat1.Cols; col++)
                {
                    if ((dynamic)mat1[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator false(Matrix<T> mat1)
        {
            for (int row = 0; row < mat1.Rows; row++)
            {
                for (int col = 0; col < mat1.Cols; col++)
                {
                    if ((dynamic)mat1[row, col] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public override string ToString()
        {
            string str = "";
            string[] str1 = new string[this.Cols];
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    str += (this.MyMatrix[i,j]+(j!=this.Cols-1?",":"")).PadLeft(4,' ');
                }
                str += Environment.NewLine;
            }
            return str;

        }
    }
}
