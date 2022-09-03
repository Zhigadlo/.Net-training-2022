namespace SolvingSOLE.Elements
{
    public class MatrixRow
    {
        private double[] _row;

        public int Length => _row.Length;
        public MatrixRow(double[] row)
        {
            _row = row;
        }

        public double this[int index]
        {
            get
            {
                return _row[index];
            }
            set
            {
                _row[index] = value;
            }
        }

        /// <summary>
        /// division all row element by value
        /// </summary>
        /// <param name="row">row for division</param>
        /// <param name="a">value</param>
        /// <returns></returns>
        public static MatrixRow operator /(MatrixRow row, double a)
        {
            var newRow = new MatrixRow(new double[row.Length]);
            for (int i = 0; i < row.Length; i++)
            {
                newRow[i] = row[i] / a;
            }

            return newRow;
        }
        /// <summary>
        /// multiply all row element by value
        /// </summary>
        /// <param name="row">row for division</param>
        /// <param name="a">value</param>
        /// <returns></returns>
        public static MatrixRow operator *(MatrixRow row, double a)
        {
            var newRow = new MatrixRow(new double[row.Length]);
            for (int i = 0; i < row.Length; i++)
            {
                newRow[i] = row[i] * a;
            }

            return newRow;
        }
        /// <summary>
        /// subtracting one row from another
        /// </summary>
        /// <param name="rowA">first row</param>
        /// <param name="rowB">second row</param>
        /// <returns></returns>
        public static MatrixRow operator -(MatrixRow rowA, MatrixRow rowB)
        {
            var newRow = new MatrixRow(new double[rowA.Length]);
            for (int i = 0; i < rowA.Length; i++)
            {
                newRow[i] = rowA[i] - rowB[i];
            }

            return newRow;
        }
        /// <summary>
        /// adding two rows
        /// </summary>
        /// <param name="rowA">first row</param>
        /// <param name="rowB">second row</param>
        /// <returns></returns>
        public static MatrixRow operator +(MatrixRow rowA, MatrixRow rowB)
        {
            var newRow = new MatrixRow(new double[rowA.Length]);
            for (int i = 0; i < rowA.Length; i++)
            {
                newRow[i] = rowA[i] + rowB[i];
            }

            return newRow;
        }

        public override bool Equals(object? obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            var row = obj as MatrixRow;

            if (row.Length != this.Length)
                return false;

            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != this[i])
                    return false;
            }

            return true;
        }
        public override string ToString()
        {
            return _row.ToString();
        }
        public override int GetHashCode()
        {
            return _row.GetHashCode() + Length.GetHashCode();
        }
    }
}