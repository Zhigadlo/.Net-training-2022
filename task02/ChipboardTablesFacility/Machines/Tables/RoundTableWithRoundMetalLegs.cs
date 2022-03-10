using Facility.Interfaces;
using Facility.TableDetails;

namespace Facility.Tables
{
    public class RoundTableWithRoundMetalLegs : ITable <RoundTableTop, MetalRoundLeg>
    {
        public string Name { get; set; }
        public double Price { get; }
        public MetalRoundLeg TableLeg { get; }
        public RoundTableTop TableTop { get; }
        public int LegsCount { get; }

        public RoundTableWithRoundMetalLegs(string name, RoundTableTop top, int countOfLegs, MetalRoundLeg leg)
        {
            Name = name;
            TableTop = top;
            LegsCount = countOfLegs;
            TableLeg = leg;
            Price = top.Price + LegsCount * leg.Price;
        }

        public double GetChipboardConsumption() => TableTop.Height * TableTop.Square;

        public override int GetHashCode() => Name.GetHashCode() + TableLeg.GetHashCode() + TableTop.GetHashCode() + Price.GetHashCode() + LegsCount.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RoundTableWithRoundMetalLegs)
                return false;
            else
            {
                RoundTableWithRoundMetalLegs newObj = obj as RoundTableWithRoundMetalLegs;

                return Name == newObj.Name && TableLeg == newObj.TableLeg && TableTop == newObj.TableTop &&
                        Price == newObj.Price && LegsCount == newObj.LegsCount;
            }
        }
        public override string ToString()
        {
            return $"Oval table with metal legs. Name = {Name}";
        }
    }
}
