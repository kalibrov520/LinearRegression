using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinearRegression.LeastSquaresMethod
{
    public class LeastSquares
    {
        public int N { get; set; }

        public int NumberOfTrainingRows { get; set; }

        public int NumberOfTestingRows { get; set; }

        public double[][] Matrix { get; set; }

        public List<List<double>> TrainingRows { get; set; } = new List<List<double>>();

        public List<List<double>> TestingRows { get; set; } = new List<List<double>>();

        public LeastSquares(string fileName)
        {
            using (var file = new StreamReader(fileName))
            {
                var n = int.Parse(file.ReadLine() ?? throw new FileLoadException("File is empty!"));
                var numberOfTrainingRows = int.Parse(file.ReadLine() ?? throw new FileLoadException("File is empty!"));

                var currentLine = new List<double>();
                //Matrix = new double[n, numberOfTrainingRows];
                Matrix = new double[numberOfTrainingRows][];

                for (var i = 0; i < numberOfTrainingRows; i++)
                {
                    currentLine = file.ReadLine().Split(' ').Select(double.Parse).ToList();
                    
                    TrainingRows.Add(currentLine);

                    Matrix[i] = currentLine.ToArray();
                }

                var testingN = int.Parse(file.ReadLine());
                var numberOfTestingRows = int.Parse(file.ReadLine());

                for (var i = 0; i < numberOfTestingRows; i++)
                {
                    
                }
            }
        } 
    }
}