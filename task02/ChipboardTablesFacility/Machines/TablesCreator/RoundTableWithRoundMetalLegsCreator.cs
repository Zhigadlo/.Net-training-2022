using Facility.Tables;
using Facility.TableDetails;
using Facility.TablesCreator.Interfaces;

namespace Facility.TablesCreator
{
    public class RoundTableWithRoundMetalLegsCreator : ITableCreator<RoundTableTop, MetalRoundLeg, RoundTableWithRoundMetalLegs>
    {
        public RoundTableWithRoundMetalLegs CreateTable(string name, RoundTableTop top, int countOfLegs, MetalRoundLeg leg)
        {
            return new RoundTableWithRoundMetalLegs(name, top, countOfLegs, leg);
        }
    }
}
