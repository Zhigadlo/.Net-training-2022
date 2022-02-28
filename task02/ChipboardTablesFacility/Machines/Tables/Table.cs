using Facility.TableDetails;

namespace Facility.Tables
{
    public abstract class Table
    {
        public List<TableLeg> tableLegs;
        public TableTop tableTop;
        public double Price;
        private double _coeffForBuild = 0.05;

        public Table(List<TableLeg> legs, TableTop top)
        {
            tableLegs = new List<TableLeg>();
            double priceForLegs = 0;
            for (int i = 0; i < legs.Count; i++)
            {
                tableLegs.Add(legs[i]);
                priceForLegs += legs[i].Price;
            }
            tableTop = top;
            Price = (top.Price + priceForLegs) * (1 + _coeffForBuild);
        }
    }
}