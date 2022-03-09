using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class OvalTableWithMetalRectangularLegs : ITable <OvalTableTop, MetalRectangleLeg>
    {
        public string Name { get; set; }
        public List<MetalRectangleLeg> TableLegs { get; }
        public OvalTableTop TableTop { get; }
        public double Price { get; }
        public int LegsCount { get; }

        public OvalTableWithMetalRectangularLegs(string name, OvalTableTop top, int countOfLegs, MetalRectangleLeg leg)
        {
            Name = name;
            LegsCount = countOfLegs;
            TableTop = top;
            double priceForLegs = 0;
            TableLegs = new List<MetalRectangleLeg>();
            for(int i = 0; i < countOfLegs; i++)
            {
                TableLegs.Add(leg);
                priceForLegs += leg.Price;
            }

            Price = top.Price + priceForLegs;
        }

        public double GetChipboardConsumption() => TableTop.Height * TableTop.Square;
    }
}
