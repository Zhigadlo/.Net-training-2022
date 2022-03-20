using Facility.Interfaces;
using Facility.TableDetails;
using System.Text.Json.Serialization;

namespace Facility.Tables
{
    public class OvalTableWithMetalRectangularLegs : ITable<OvalTableTop, MetalRectangleLeg>
    {
        public string Name { get; set; }
        public MetalRectangleLeg TableLeg { get; }
        public OvalTableTop TableTop { get; }
        [JsonIgnore]
        public double Price { get; }
        public int LegsCount { get; }

        public OvalTableWithMetalRectangularLegs(string name, OvalTableTop tableTop, int legsCount, MetalRectangleLeg tableLeg)
        {
            Name = name;
            LegsCount = legsCount;
            TableTop = tableTop;
            TableLeg = tableLeg;
            Price = tableTop.Price + LegsCount * tableLeg.Price;
        }

        public double GetChipboardConsumption() => TableTop.Height * TableTop.Square;

        public override int GetHashCode() => Name.GetHashCode() + TableLeg.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not OvalTableWithMetalRectangularLegs)
                return false;
            else
            {
                OvalTableWithMetalRectangularLegs newObj = obj as OvalTableWithMetalRectangularLegs;

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
