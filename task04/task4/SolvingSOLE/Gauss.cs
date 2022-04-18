using SolvingSOLE.Elements;

namespace SolvingSOLE
{
    public class Gauss : ISolving
    {
        public virtual double[] Solve(double[,] matrix)
        {
            IsMatrixSuitableSize(matrix);

            Matrix resultMatrix = new Matrix(matrix);

            return Solve(resultMatrix);
        }

        public virtual double[] Solve(Matrix matrix)
        {
            DirectMove(matrix);
            ReverseMove(matrix);

            double[] results = new double[matrix.GetLength(0)];
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = matrix[i][matrix.GetLength(1) - 1];
            }

            return results;
        }

        protected virtual void DirectMove(Matrix matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                matrix[i] = matrix[i] / matrix[i][i];

                for (int j = i + 1; j < n; j++)
                {
                    double koof = matrix[j][i] / matrix[i][i];
                    matrix[j] = matrix[j] - matrix[i] * koof;
                }
            }
        }

        protected virtual void ReverseMove(Matrix matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = n - 1; i >= 0; i--)
            {
                matrix[i] = matrix[i] / matrix[i][i];

                for (int j = i - 1; j >= 0; j--)
                {
                    double koof = matrix[j][i] / matrix[i][i];
                    matrix[j] = matrix[j] - matrix[i] * koof;
                }
            }
        }

        protected void IsMatrixSuitableSize(double[,] matrix)
        {
            if (matrix.GetLength(0) + 1 != matrix.GetLength(1))
                throw new Exception("The matrix is not of a suitable size," +
                                    " make sure that the number of rows is 1 less than the number of columns");
        }
    }
}