using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinearRegression.LeastSquaresMethod
{
    public class LeastSquares
    {
        public int TrainingN { get; set; }

        public int TestingN { get; set; }

        public int NumberOfTrainingRows { get; set; }

        public int NumberOfTestingRows { get; set; }

        public double[] YTraining { get; set; }

        public double[] YTesting { get; set; }

        public double[][] TrainingMatrix { get; set; }

        public double[][] TestingMatrix { get; set; }

        public List<List<double>> TrainingRows { get; set; } = new List<List<double>>();

        public List<List<double>> TestingRows { get; set; } = new List<List<double>>();

        public LeastSquares(string fileName)
        {
            using (var file = new StreamReader(fileName))
            {
                TrainingN = int.Parse(file.ReadLine() ?? throw new FileLoadException("File is empty!"));
                var numberOfTrainingRows = int.Parse(file.ReadLine() ?? throw new FileLoadException("File is empty!"));

                List<double> currentLine;
                TrainingMatrix = new double[numberOfTrainingRows][];
                YTraining = new double[numberOfTrainingRows];

                for (var i = 0; i < numberOfTrainingRows; i++)
                {
                    currentLine = file.ReadLine().Split(' ').Select(double.Parse).ToList();

                    YTraining[i] = currentLine.Last();
                    
                    //TrainingRows.Add(currentLine.Take(TrainingN).ToList());

                    TrainingMatrix[i] = currentLine.Take(TrainingN).ToArray();
                }

                TestingN = TrainingN;
                var numberOfTestingRows = int.Parse(file.ReadLine());
                
                YTesting = new double[numberOfTestingRows];
                TestingMatrix = new double[numberOfTestingRows][];

                for (var i = 0; i < numberOfTestingRows; i++)
                {
                    currentLine = file.ReadLine().Split(' ').Select(double.Parse).ToList();

                    YTesting[i] = currentLine.Last();
                    
                    //TestingRows.Add(currentLine);

                    TestingMatrix[i] = currentLine.Take(TestingN - 1).ToArray();
                }
            }
        } 
        
        
    }
}