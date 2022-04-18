using SolvingSOLE.Elements;

namespace SolvingSOLE
{
    public class DistributedGauss : Gauss
    {
        public override double[] Solve(Matrix matrix)
        {
            return base.Solve(matrix);
        }

        public override double[] Solve(double[,] matrix)
        {
            return base.Solve(new Matrix(matrix));
        }


        protected override void DirectMove(Matrix matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                matrix[i] = matrix[i] / matrix[i][i];

                Parallel.For(i + 1, n, (int j) =>
                {
                    double koof = matrix[j][i] / matrix[i][i];
                    matrix[j] = matrix[j] - matrix[i] * koof;
                });
            }

        }

        protected override void ReverseMove(Matrix matrix)
        {
            int n = matrix.GetLength(0);

            for (int i = n - 1; i >= 0; i--)
            {
                matrix[i] = matrix[i] / matrix[i][i];

                Parallel.For(0, i, (int j) =>
                {
                    double koof = matrix[j][i] / matrix[i][i];
                    matrix[j] = matrix[j] - matrix[i] * koof;
                });
            }
        }
    }
}
