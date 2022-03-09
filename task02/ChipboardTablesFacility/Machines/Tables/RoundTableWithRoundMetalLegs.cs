using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RoundTableWithRoundMetalLegs : ITable <RoundTableTop, MetalRoundLeg>
    {
        public string Name { get; set; }
        public double Price { get; }
        public List<MetalRoundLeg> TableLegs { get; }
        public RoundTableTop TableTop { get; }
        public int LegsCount { get; }

        public RoundTableWithRoundMetalLegs(string name, RoundTableTop top, int countOfLegs, MetalRoundLeg leg)
        {
            Name = name;
            TableTop = top;
            LegsCount = countOfLegs;
            double priceForLegs = 0;
            TableLegs = new List<MetalRoundLeg>();
            for (int i = 0; i < countOfLegs; i++)
            {
                TableLegs.Add(leg);
                priceForLegs += leg.Price;
            }

            Price = top.Price + priceForLegs;
        }

        public double GetChipboardConsumption() => TableTop.Height * TableTop.Square;
    }
}
