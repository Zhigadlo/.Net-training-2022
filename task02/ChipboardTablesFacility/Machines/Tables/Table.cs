using Facility.Interfaces;

namespace Facility.Tables
{
    public abstract class Table
    {
        public string Name { get; set; }
        public List<ITableLeg> tableLegs;
        public ITableTop tableTop;
        public double Price;
        private double _coeffForBuild = 0.05;

        public Table(List<ITableLeg> legs, ITableTop top)
        {
            tableLegs = new List<ITableLeg>();
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