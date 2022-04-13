namespace SolvingSOLE.Elements
{
    public class Matrix
    {
        private readonly MatrixRow[] _rows;
        private double[,] _cells;

        public int Length => _cells.Length;
        public int ColumnCount => _cells.GetLength(0);
        public int RowCount => _rows.Length;
        public MatrixRow[] Rows => _rows;

        /// <returns>The size of the given dimension</returns>
        public int GetLength(int dimension)
        {
            return _cells.GetLength(dimension);
        }

        public Matrix(double[,] cells)
        {
            _cells = cells;
            _rows = new MatrixRow[cells.GetLength(0)];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                MatrixRow row = new MatrixRow(new double[cells.GetLength(1)]);
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    row[j] = cells[i, j];
                }

                _rows[i] = row;
            }
        }

        public MatrixRow this[int i]
        {
            get => _rows[i];
            set => _rows[i] = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj?.GetType() != this.GetType())
                return false;

            var matrix = obj as Matrix;

            if (matrix.GetLength(0) != this.GetLength(0))
                return false;

            if (matrix.GetLength(1) != this.GetLength(1))
                return false;

            for (int i = 0; i < GetLength(0); i++)
            {
                for (int j = 0; j < GetLength(1); j++)
                {
                    if (!Equals(this[i], matrix[i]))
                        return false;
                }
            }

            return true;
        }
        public override string ToString()
        {
            return _cells.ToString();
        }
        public override int GetHashCode()
        {
            return _rows.GetHashCode();
        }
    }
}
