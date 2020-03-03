using System;
using LinearRegression.LeastSquaresMethod;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            var leastSquares = new LeastSquares("C:\\Users\\Ilya\\Desktop\\LinearRegression\\LinearRegression\\LinearRegression\\file.txt");
            var leastSquares2 = new LeastSquares(@"C:\Users\Ilya\Desktop\LinearRegression\LinearRegression\LinearRegression\2.txt");
            Console.ReadLine();
        }
    }
}