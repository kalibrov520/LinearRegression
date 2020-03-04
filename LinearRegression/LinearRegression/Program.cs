using System;
using LinearRegression.LeastSquaresMethod;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            var leastSquares = new LeastSquares(@"C:\Users\Ilya\Desktop\LinearRegression\LinearRegression\LinearRegression\test.txt");
            leastSquares.TrainModel();
            leastSquares.TestModel();
            Console.ReadLine();
        }
    }
}