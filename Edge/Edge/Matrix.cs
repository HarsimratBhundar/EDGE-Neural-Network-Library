using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    /// <summary>
    /// Class Matrix; Defines the structure of a matrix of a key defined type
    /// </summary>
    /// <typeparam name="T">The argument defined key type of the Matrix</typeparam>
    public class Matrix<T> where T : struct
    {
        ///The custome exceptions used in this class
        #region Exceptions
        /// <summary>
        /// Exception is thrown when arithmetic operations are used for non-numeric Matrix contents
        /// </summary>
        private static InvalidOperationException ArithmeticOperationException = new InvalidOperationException("Arithmetic operations are only used for type 'int' and 'double'");

        /// <summary>
        /// Exception is thrown when the dimesnions of two matrices in a mathematical operation are not equal or inverse of each other
        /// </summary>
        private static InvalidOperationException InAdequateMatrixMathException = new InvalidOperationException("The state of the matrices is not adequate for this mathematical operation.");

        /// <summary>
        /// Exception is thrown when the length of the rows and the columns of the matrix are not equal to each other while initalising a matrix diagonally
        /// </summary>
        private InvalidOperationException UnParallelRowAndColumnException = new InvalidOperationException("The Matrix's rows and columns must be of the same length for this operation.");
        #endregion

        /// <summary>
        /// Sotres the contents of the Matrix
        /// </summary>
        private T[][] Cache;

        /// <summary>
        /// Default Constructor; Creates an instance of type matrix with no size 0 dimensions
        /// </summary>
        public Matrix()
        {
            Cache = null;
        }

        /// <summary>
        /// Constructor; Creates an instance of type Matrix with argument defined dimensions
        /// </summary>
        /// <param name="RowSize">The argument defined row size</param>
        /// <param name="ColumnSize">The argument defined column size</param>
        public Matrix(int RowSize, int ColumnSize)
        {
            Cache = new T[RowSize][];

            for (int RowNumber = 0; RowNumber < Rows; RowNumber++)
            {
                Cache[RowNumber] = new T[ColumnSize];
            }
        }

        /// <summary>
        /// Constructor; creates a row matrix using an argument defined arrray
        /// </summary>
        /// <param name="ArgumentArray">Argument defined array</param>
        public Matrix(T[] ArgumentArray)
        {
            Cache = new T[1][];
            Cache[0] = ArgumentArray;
        }

        /// <summary>
        /// Constructor; creates a row matrix using an argument defined two dimensional arrray
        /// </summary>
        /// <param name="ArgumentArray"></param>
        public Matrix(T[][] ArgumentArray)
        {
            Cache = ArgumentArray;
        }

        /// <summary>
        /// Returns the sum of two matrices
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix<T> operator+(Matrix<T> A, Matrix<T> B)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(T))
            {
                if (A.Rows == B.Rows && A.Columns == B.Columns)
                {
                    Matrix<T> C = new Matrix<T>(A.Rows, B.Columns);
                    for (int RowNumber = 0; RowNumber < C.Rows; RowNumber++)
                    {
                        for (int ColumnNumber = 0; ColumnNumber < C.Columns; ColumnNumber++)
                        {
                            C[RowNumber, ColumnNumber] = (dynamic)A[RowNumber, ColumnNumber] + (dynamic)B[RowNumber, ColumnNumber];
                        }
                    }
                    return C;
                }
                throw InAdequateMatrixMathException;
            }
            throw ArithmeticOperationException;
        }

        /// <summary>
        /// Retrurns a matrix subtracted by another matrix
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix<T> operator-(Matrix<T> A, Matrix<T> B)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(T))
            {
                if (A.Rows == B.Rows && A.Columns == B.Columns)
                {
                    Matrix<T> C = new Matrix<T>(A.Rows, B.Columns);
                    for (int RowNumber = 0; RowNumber < C.Rows; RowNumber++)
                    {
                        for (int ColumnNumber = 0; ColumnNumber < C.Columns; ColumnNumber++)
                        {
                            C[RowNumber, ColumnNumber] = (dynamic)A[RowNumber, ColumnNumber] - (dynamic)B[RowNumber, ColumnNumber];
                        }
                    }
                    return C;
                }
                throw InAdequateMatrixMathException;
            }
            throw ArithmeticOperationException;
        }

        /// <summary>
        /// Returns the product of a matrix multiplied by a scalar
        /// </summary>
        /// <param name="A">Argument defined matrix</param>
        /// <param name="B">Argument defined scalar</param>
        /// <returns></returns>
        public static Matrix<T> operator*(Matrix<T> A, T B)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(T))
            {
                Matrix<T> C = new Matrix<T>(A.Rows, A.Columns);
                for (int RowNumber = 0; RowNumber < C.Rows; RowNumber++)
                {
                    for (int ColumnNumber = 0; ColumnNumber < C.Columns; ColumnNumber++)
                    {
                        C[RowNumber, ColumnNumber] = (dynamic)A[RowNumber, ColumnNumber] * (dynamic)B;
                    }
                }
                return C;
            }
            throw ArithmeticOperationException;
        }

        /// <summary>
        /// Returns the dot product of two matrices
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Matrix<T> operator*(Matrix<T> A, Matrix<T> B)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(T))
            {
                if (A.Rows > B.Rows)
                {
                    Matrix<T> Swap = A;
                    A = B;
                    B = Swap;
                }

                if ((A.Rows == B.Rows && A.Columns == B.Columns) || (A.Rows == B.Columns && A.Columns == B.Rows))
                {
                    Matrix<T> C = new Matrix<T>(A.Rows, B.Columns);

                    for (int RowNumber = 0; RowNumber < C.Rows; RowNumber++)
                    {
                        for (int ColumnNumber = 0; ColumnNumber < C.Columns; ColumnNumber++)
                        {
                            double TemporaryValue = 0;
                            for (int Iterator = 0; Iterator < A.Columns; Iterator++)
                            {
                                TemporaryValue += (dynamic)A[RowNumber, Iterator] * (dynamic)B[Iterator, RowNumber];
                            }
                            C[RowNumber, ColumnNumber] = (dynamic)TemporaryValue;
                        }
                    }
                    return C;
                }
                throw InAdequateMatrixMathException;
            }
            throw ArithmeticOperationException;
        }

        /// <summary>
        /// Returns the product of a matrix divided by a scalar
        /// </summary>
        /// <param name="A">Argument defined matrix</param>
        /// <param name="B">Argument defined scalar</param>
        /// <returns></returns>
        public static Matrix<T> operator/(Matrix<T> A, T B)
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(T))
            {
                Matrix<T> C = new Matrix<T>(A.Rows, A.Columns);
                for (int RowNumber = 0; RowNumber < C.Rows; RowNumber++)
                {
                    for (int ColumnNumber = 0; ColumnNumber < C.Columns; ColumnNumber++)
                    {
                        C[RowNumber, ColumnNumber] = (dynamic)A[RowNumber, ColumnNumber] / (dynamic)B;
                    }
                }

                return C;
            }
            throw ArithmeticOperationException;
        }

        /// <summary>
        /// Returns the transposed instance of the matrix
        /// </summary>
        /// <returns></returns>
        public Matrix<T> Transpose()
        {
            Matrix<T> A = new Matrix<T>(Columns, Rows);

            for(int RowNumber = 0; RowNumber < Rows; RowNumber++)
            {
                for(int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                {
                    A[ColumnNumber, RowNumber] = this[RowNumber, ColumnNumber];
                }
            }
            return A;
        }

        /// <summary>
        /// Initalises the matrix with an argument defined value
        /// </summary>
        /// <param name="Value">The argument defined value</param>
        public void Initialize(T Value)
        {
            for(int RowNumber = 0; RowNumber < Rows; RowNumber++)
            {
                for(int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                {
                    this[RowNumber, ColumnNumber] = Value;
                }
            }
        }

        /// <summary>
        /// Initialises the matrix with random numbers within an argument defined range
        /// </summary>
        /// <param name="Min">The argument defined min range</param>
        /// <param name="Max">The argument defined max range</param>
        public void InitializeRandom(T Min, T Max)
        {
            Random Randomizer = new Random();
            if (typeof(T) == typeof(int))
            {
                for (int RowNumber = 0; RowNumber < Rows; RowNumber++)
                {
                    for (int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                    {
                        this[RowNumber, ColumnNumber] = (dynamic)Randomizer.Next((dynamic)Min, (dynamic)Max);
                    }
                }
            }

            else if (typeof(T) == typeof(double))
            {
                for (int RowNumber = 0; RowNumber < Rows; RowNumber++)
                {
                    for (int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                    {
                        this[RowNumber, ColumnNumber] = (dynamic)Randomizer.NextDouble();
                    }
                }
            }


            else if(typeof(T) == typeof(bool))
            {
                for (int RowNumber = 0; RowNumber < Rows; RowNumber++)
                {
                    for (int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                    {
                        if(Randomizer.Next(0, 1) == 0)
                        {
                            this[RowNumber, ColumnNumber] = (dynamic)true;
                        }
                        else
                        {
                            this[RowNumber, ColumnNumber] = (dynamic)false;
                        }
                    }
                }
            }
            else
            {
                InvalidOperationException NonRandomizableTypeException = new InvalidOperationException("Random initalization is only used for numeric ('int' and 'double') and bool variables.");
                throw NonRandomizableTypeException;
            }
        }

        /// <summary>
        /// Initalises the matrix diagonally with an argument defined value 
        /// </summary>
        /// <param name="Value">The argument defined value</param>
        public void InitalizeDiagonal(T Value)
        {
            if(Rows != Columns)
            {
                throw UnParallelRowAndColumnException;
            }
            for(int IndexNumber = 0; IndexNumber < Rows; IndexNumber++)
            {
                this[IndexNumber, IndexNumber] = Value;
            }
        }

        /// <summary>
        /// Initalises the matrix diagonally with an argument defined array of value 
        /// </summary>
        /// <param name="Values">The argument defined array of value</param>
        public void InitalizeDiagonal(T[] Values)
        {
            if(Rows != Columns)
            {
                throw UnParallelRowAndColumnException;
            }
            if(Rows != Values.Length)
            {
                InvalidOperationException InequalArgumentAndMatrixLengthException = new InvalidOperationException("The length of the argument array needs to be equal to the Rows and Columns of the Matrix");
            }
            for(int IndexNumber = 0; IndexNumber < Rows; IndexNumber++)
            {
                this[IndexNumber, IndexNumber] = Values[IndexNumber];
            }
        }

        /// <summary>
        /// Returns a one dimensional array of the contents of the matrix
        /// </summary>
        /// <returns></returns>
        public T[] ToVector()
        {
            T[] A = new T[Rows * Columns];
            int IndexNumber = 0;
            for(int RowNumber = 0; RowNumber < Rows; RowNumber++)
            {
                for(int ColumnNumber = 0; ColumnNumber < Columns; ColumnNumber++)
                {
                    A[IndexNumber] = this[RowNumber, ColumnNumber];
                }
            }
            return A;
        }

        /// <summary>
        /// Gets or Sets a specific argument defined Row for the Matrix
        /// </summary>
        /// <param name="Row">Argument defined row</param>
        /// <returns></returns>
        public T[] this[int Row]
        {
            get
            {
                return Cache[Row];
            }

            set
            {
                Cache[Row] = value;
            }
        }

        /// <summary>
        /// Gets or Sets a specific argument defined Cell for the Matrix
        /// </summary>
        /// <param name="Row">Argument defined row</param>
        /// <param name="Column">Argument defined column</param>
        /// <returns></returns>
        public T this[int Row, int Column]
        {
            get
            {
                return Cache[Row][Column];
            }

            set
            {
                Cache[Row][Column] = value;
            }
        }



        /// <summary>
        /// The Number of Rows in the Matrix
        /// </summary>
        public int Rows
        {
            get
            {
                return Cache.Length;
            }
        }

        /// <summary>
        /// The Number of Columns in the Matrix
        /// </summary>
        public int Columns
        {
            get
            {
                return Cache[0].Length;
            }
        }
    }
}
