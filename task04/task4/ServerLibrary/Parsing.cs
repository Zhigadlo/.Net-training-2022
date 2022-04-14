namespace ServerLibrary
{
    public class Parsing
    {
        public static string DoubleArrayToString(double[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].ToString() + "\t";
            return result;
        }

        public static double[] StringToDoubleArray(string text)
        {
            string[] values = text.Split('\t');
            double[] result = new double[values.Length - 1];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToDouble(values[i]);

            return result;
        }
    }
}
