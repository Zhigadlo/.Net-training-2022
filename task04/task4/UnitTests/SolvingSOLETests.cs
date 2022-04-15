using Xunit;
using SolvingSOLE;

namespace UnitTests
{
    public class SolvingSOLETests
    {
        [Fact]
        public void GaussTest()
        {
            double[,] matrix = new double[,] { { 3, -3, 2, 2 }, { 4, -5, 2, 1 }, { 5, -6, 4, 3} };
            double[] answers = { 1, 1, 1 };
            Gauss gauss = new Gauss();
            double[] actualAnswers = gauss.Solve(matrix);

            for(int i = 0; i < answers.Length; i++)
                Assert.Equal(answers[i], actualAnswers[i]);
        }
    }
}
