using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class TableWithAccessories : ITable, ITableWithAccessories
    {
        public string Name { get; set; }
        public List<ITableLeg> TableLegs { get; }
        public ITableTop TableTop { get; }
        public double Price { get; }
        public Dictionary<TableAccessoriesType, int> TableAccessories { get; }

        public TableWithAccessories(string name, ITableTop top, Dictionary<TableAccessoriesType, int> tableAccessories, params ITableLeg[] legs)
        {
            Name = name;
            TableTop = top;
            TableAccessories = tableAccessories;
            TableLegs = new List<ITableLeg>();
            double priceForLegs = 0;
            foreach (var leg in legs)
            {
                TableLegs.Add(leg);
                priceForLegs += leg.Price;
            }

            Price = priceForLegs + top.Price;
        }

        public double GetPriceForBuild()
        {
            throw new NotImplementedException();
        }
    }
}
