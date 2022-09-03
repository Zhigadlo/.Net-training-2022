namespace ServerLibrary
{
    /// <summary>
    /// Class with static methods for array parsing
    /// </summary>
    public class Parsing
    {
        /// <summary>
        /// Converts array to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(T[] array)
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
                result += array[i].ToString() + "\t";
            return result;
        }
        /// <summary>
        /// Converts string to double array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double[] StringToDoubleArray(string text)
        {
            string[] values = text.Split('\t');
            double[] result = new double[values.Length - 1];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToDouble(values[i]);

            return result;
        }
        /// <summary>
        /// Converts string to multidemensional double array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double[,] StringToMultidemensionalDoubleArray(string text)
        {
            text = text.Replace("\0", "");
            string[] values = text.Split('\n');
            int rows = values.Length - 1;
            int cols = StringToDoubleArray(values[0]).Length;
            double[,] result = new double[rows, cols];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                double[] array = StringToDoubleArray(values[i]);
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = array[j];
                }
            }
            return result;
        }
        /// <summary>
        /// Converts multidemensional array to string
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string MultidemensionalDoubleArrayToString<T>(T[,] array)
        {
            string result = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result += array[i, j].ToString() + "\t";
                }
                result += "\n";
            }
            return result;
        }
        /// <summary>
        /// Converts string to int array
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
