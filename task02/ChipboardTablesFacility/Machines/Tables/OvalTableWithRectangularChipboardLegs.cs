using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class OvalTableWithRectangularChipboardLegs : ITable<OvalTableTop, ChipboardRectangleLeg>
    {
        public string Name { get; set; }
        public double Price { get; }
        public int LegsCount { get; }
        public OvalTableTop TableTop { get; }
        public ChipboardRectangleLeg TableLeg { get; }

        public OvalTableWithRectangularChipboardLegs(string name, OvalTableTop top, int countOfLegs, ChipboardRectangleLeg leg)
        {
            Name = name;
            LegsCount = countOfLegs;
            TableLeg = leg;
            TableTop = top;
            Price = top.Price + LegsCount * leg.Price;
        }

        public double GetChipboardConsumption()
        {
            double consumption = TableTop.Height * TableTop.Square;
            return TableTop.Height * TableTop.Square + LegsCount * (TableLeg.Square * TableLeg.Height);
        }
    }
}
