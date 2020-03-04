using System;
using LinearRegression.LeastSquaresMethod;

namespace LinearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            var leastSquares = new LeastSquares(@"C:\Users\ikalibrov\Desktop\Linear\LinearRegression\LinearRegression\test.txt");
            leastSquares.TrainModel();
            leastSquares.TestModel();
            Console.ReadLine();
        }
    }
}