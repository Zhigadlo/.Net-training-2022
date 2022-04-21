using SolvingSOLE;
using System;
using System.Diagnostics;
using Xunit;

namespace UnitTests
{
    public class SolvingSOLETests
    {
        [Fact]
        public void GaussTest()
        {
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3 } };
            double[] answers = { 1, 1, 1 };
            Gauss gauss = new Gauss();
            double[] actualAnswers = gauss.Solve(matrix);

            for (int i = 0; i < answers.Length; i++)
                Assert.Equal(answers[i], actualAnswers[i]);
        }

        [Fact]
        public void DistributedGauss()
        {
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3 } };
            double[] answers = { 1, 1, 1 };
            DistributedGauss gauss = new DistributedGauss();
            double[] actualAnswers = gauss.Solve(matrix);

            for (int i = 0; i < answers.Length; i++)
                Assert.Equal(answers[i], actualAnswers[i]);
        }

        [Fact]
        public void SpeedTest()
        {
            Random rnd = new Random();
            double[,] matrix = new double[200, 201];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next() * 20;
                }
            }
            Stopwatch sw = new Stopwatch();
            Gauss gauss = new Gauss();

            sw.Start();

            double[] answers = gauss.Solve(matrix);

            sw.Stop();

            long time1 = sw.ElapsedTicks;

            DistributedGauss distributedGauss = new DistributedGauss();
            sw.Restart();

            answers = distributedGauss.Solve(matrix);

            sw.Stop();

            long time2 = sw.ElapsedTicks;

            Assert.True(time1 > time2);
        }
    }
}
