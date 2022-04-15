namespace ServerLibrary
{
    public class Parsing
    {
        public static string ArrayToString<T>(T[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].ToString() + "\t";
            return result;
        }

        public static string ArrayToString<T>(T[][] array)
        {
            string result = "";
            for(int i = 0; i < array.Length; i++)
                result += ArrayToString(array[i]) + "\n";

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

        public static double[][] StringToTwoDemensionalDoubleArray(string text)
        {
            string[] values = text.Split('\n');
            double[][] result = new double[values.Length - 1][];
            for(int i = 0; i < result.Length; i++)
                result[i] = StringToDoubleArray(values[i]);

            return result;
        }

        public static int[] StringToIntArray(string text)
        {
            string[] values = text.Split('\t');
            int[] result = new int[values.Length - 1];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToInt32(values[i]);

            return result;
        }
    }
}
