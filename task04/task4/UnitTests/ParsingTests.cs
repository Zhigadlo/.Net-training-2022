using Xunit;
using ServerLibrary;

namespace UnitTests
{
    public class ParsingTests
    {
        [Fact]
        public void StringToDoubleTest()
        {
            double[] values = new double[] { 3.1, 1.1, 0.3, -4.4 };

            string line = Parsing.DoubleArrayToString(values);

            double[] actualValues = Parsing.StringToDoubleArray(line);

            Assert.Equal(values, actualValues);

        }
    }
}
