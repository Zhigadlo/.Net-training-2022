using Facility.Interfaces;
using Facility.TableDetails;
using System.Text.Json.Serialization;

namespace Facility.Tables
{
    public class OvalTableWithRectangularChipboardLegs : ITable<OvalTableTop, RectangleChipboardLeg>
    {
        public string Name { get; set; }
        [JsonIgnore]
        public double Price { get; }
        public int LegsCount { get; }
        public OvalTableTop TableTop { get; }
        public RectangleChipboardLeg TableLeg { get; }

        public OvalTableWithRectangularChipboardLegs(string name, OvalTableTop tableTop, int legsCount, RectangleChipboardLeg tableLeg)
        {
            Name = name;
            LegsCount = legsCount;
            TableLeg = tableLeg;
            TableTop = tableTop;
            Price = tableTop.Price + LegsCount * tableLeg.Price;
        }

        public double GetChipboardConsumption()
        {
            double consumption = TableTop.Height * TableTop.Square;
            return TableTop.Height * TableTop.Square + LegsCount * (TableLeg.Square * TableLeg.Height);
        }
    }
}
