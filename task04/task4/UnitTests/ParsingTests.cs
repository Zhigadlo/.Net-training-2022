using ServerLibrary;
using Xunit;

namespace UnitTests
{
    public class ParsingTests
    {
        [Theory]
        [InlineData(new double[] { 3.1, 1.1, 0.3, -4.4 })]
        [InlineData(new double[] { 2.1, 0.1, -10.3, 4.8 })]
        public void StringToDoubleArrayTest(double[] values)
        {
            string line = Parsing.ArrayToString(values);

            double[] actualValues = Parsing.StringToDoubleArray(line);

            Assert.Equal(values, actualValues);
        }

        [Theory]
        [InlineData(new int[] { 3, 1, 3, -4 })]
        [InlineData(new int[] { 2, 0, -10, 8 })]
        public void StringToIntArrayTest(int[] values)
        {
            string line = Parsing.ArrayToString(values);

            int[] actualValues = Parsing.StringToIntArray(line);

            Assert.Equal(values, actualValues);
        }
    }
}
