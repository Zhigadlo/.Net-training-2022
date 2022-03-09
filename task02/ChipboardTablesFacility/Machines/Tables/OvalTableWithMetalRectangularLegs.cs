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

        public override int GetHashCode() => Name.GetHashCode() + TableLegs.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not OvalTableWithMetalRectangularLegs)
                return false;
            else
            {
                OvalTableWithMetalRectangularLegs newObj = obj as OvalTableWithMetalRectangularLegs;

                return Name == newObj.Name && TableLegs == newObj.TableLegs && TableTop == newObj.TableTop &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount;
            }
        }
        public override string ToString()
        {
            return $"Oval table with metal legs. Name = {Name}";
        }
    }
}
