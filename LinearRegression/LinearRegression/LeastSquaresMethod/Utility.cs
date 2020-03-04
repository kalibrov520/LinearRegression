using System;
using System.Linq;

namespace LinearRegression.LeastSquaresMethod
{
    public static class Utility
    {
        public static double[][] TransposeMatrix(double[][] m)
        {
            var result = new double[m[0].Length][];
            for (var i = 0; i < m[0].Length; i++)
            {
                result[i] = new double[m.Length];
               
                for (var j = 0; j < m.Length; j++)
                {
                    result[i][j] = m[j][i];
                }
            }
               
            return result;
        }

        public static double[][] MultiplyMatrices (double[][] a, double[][] b)
        {
            var result = new double[a.Length][];

            for (var row = 0; row < result.Length; row++)
            {
                result[row] = new double[b[0].Length];
                for (var column = 0; column < result[row].Length; column++)
                {
                    result[row][column] = MultiplyMatricesCell(a, b, row, column);
                }
            }

            return result;
        }

        private static double MultiplyMatricesCell(double[][] firstMatrix, double[][] secondMatrix, int row, int col) {
            double cell = 0;
            for (var i = 0; i < secondMatrix.Length; i++) {
                cell += firstMatrix[row][i] * secondMatrix[i][col];
            }
            return cell;
        }

        public static double[][] Invert(double[][] a)
        {
            var n = a.Length;
            var x = new double[n][];
            var b = new double[n][];
            var index = new int[n];
            for (var i = 0; i < n; ++i)
            {
                b[i] = new double[n];
                x[i] = new double[n];
                b[i][i] = 1;   
            }

            // Transform the matrix into an upper triangle
            Gaussian(a, index);

            // Update the matrix b[i][j] with the ratios stored
            for (var i = 0; i < n - 1; ++i)
            {
                for (var j = i + 1; j < n; ++j)
                {
                    for (var k = 0; k < n; ++k)
                    {
                        b[index[j]][k] -= a[index[j]][i] * b[index[i]][k];
                    }
                }
            }

            // Perform backward substitutions
            for (var i = 0; i < n; ++i)
            {
                x[n - 1][i] = b[index[n - 1]][i] / a[index[n - 1]][n - 1];
                for (var j = n - 2; j >= 0; --j)
                {
                    x[j][i] = b[index[j]][i];
                    for (var k = j + 1; k < n; ++k)
                    {
                        x[j][i] -= a[index[j]][k] * x[k][i];
                    }

                    x[j][i] /= a[index[j]][j];
                }
            }

            return x;
        }

        private static void Gaussian(double[][] a, int[] index)
        {
            var n = index.Length;
            var c = new double[n];

            // Initialize the index
            for (var i = 0; i < n; ++i)
            {
                index[i] = i;
            }

            // Find the rescaling factors, one from each row
            for (var i = 0; i < n; ++i)
            {
                double c1 = 0;
                for (var j = 0; j < n; ++j)
                {
                    var c0 = Math.Abs(a[i][j]);
                    if (c0 > c1) c1 = c0;
                }

                c[i] = c1;
            }

            // Search the pivoting element from each column
            var k = 0;
            for (var j = 0; j < n - 1; ++j)
            {
                double pi1 = 0;
                for (var i = j; i < n; ++i)
                {
                    var pi0 = Math.Abs(a[index[i]][j]);
                    pi0 /= c[index[i]];
                    if (pi0 > pi1)
                    {
                        pi1 = pi0;
                        k = i;
                    }
                }

                // Interchange rows according to the pivoting order
                var itmp = index[j];
                index[j] = index[k];
                index[k] = itmp;
                for (var i = j + 1; i < n; ++i)
                {
                    var pj = a[index[i]][j] / a[index[j]][j];

                    // Record pivoting ratios below the diagonal
                    a[index[i]][j] = pj;

                    // Modify other elements accordingly
                    for (var l = j + 1; l < n; ++l)
                        a[index[i]][l] -= pj * a[index[j]][l];
                }
            }
        }

        public static double[] MultiplyMatrixOnVector(double[][] matrix, double[] vector)
        {
            var result = new double[matrix.Length];

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    result[i] += matrix[i][j] * vector[j];
                }
            }

            return result;
        }
    }
}