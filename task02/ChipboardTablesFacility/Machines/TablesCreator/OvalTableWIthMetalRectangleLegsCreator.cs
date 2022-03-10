using Facility.Tables;
using Facility.TableDetails;
using Facility.TablesCreator.Interfaces;

namespace Facility.TablesCreator
{
    public class OvalTableWIthMetalRectangleLegsCreator : ITableCreator <OvalTableTop, MetalRectangleLeg, OvalTableWithMetalRectangularLegs>
    {
        public OvalTableWithMetalRectangularLegs CreateTable(string name, OvalTableTop top, int countOfLegs, MetalRectangleLeg leg)
        {
            return new OvalTableWithMetalRectangularLegs(name, top, countOfLegs, leg);
        }
    }
}
