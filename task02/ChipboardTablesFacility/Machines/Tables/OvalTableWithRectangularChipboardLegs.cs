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
            return TableTop.Height * TableTop.Square + LegsCount * (TableLeg.Square * TableLeg.Height);
        }

        public override int GetHashCode() => Name.GetHashCode() + TableLeg.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not OvalTableWithRectangularChipboardLegs)
                return false;
            else
            {
                OvalTableWithRectangularChipboardLegs newObj = obj as OvalTableWithRectangularChipboardLegs;

                return Name == newObj.Name && TableLeg.Equals(newObj.TableLeg) && TableTop.Equals(newObj.TableTop) &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount;
            }
        }
        public override string ToString()
        {
            return $"Oval table with metal legs. Name = {Name}";
        }
    }
}
