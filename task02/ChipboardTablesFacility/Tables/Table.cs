using TableDetails;

namespace Tables
{
    public abstract class Table
    {
        public List<TableLeg> tableLegs;
        public TableTop tableTop;
        public double Price;
        private double _coeffForBuild = 0.05;

        public Table(TableLeg leg, int countOfLegs, TableTop top)
        {
            tableLegs = new List<TableLeg>();
            for (int i = 0; i < countOfLegs; i++)
                tableLegs.Add(leg);

            tableTop = top;
            Price = (top.Price + leg.Price * countOfLegs) * (1 + _coeffForBuild);
        }
    }
}