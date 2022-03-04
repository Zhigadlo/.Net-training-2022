namespace Facility.Interfaces
{
    public interface ITable
    {
        public string Name { get; set; }
        public List<ITableLeg> TableLegs { get; }
        public ITableTop TableTop { get; }
        public double Price { get; }
        /*
        public ITable(string name,ITableTop top, params ITableLeg[] legs)
        {
            Name = name;
            tableLegs = new List<ITableLeg>();
            double priceForLegs = 0;
            foreach (ITableLeg leg in legs)
            {
                tableLegs.Add(leg);
                priceForLegs += leg.Price;
            }
            TableTop = top;
            Price = (top.Price + priceForLegs) * (1 + _percentageForBuild);
        }*/

        public double GetPriceForBuild();
    }
}