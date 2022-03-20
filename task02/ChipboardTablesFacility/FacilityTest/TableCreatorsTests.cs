using Xunit;
using System.Collections.Generic;
using Facility.Tables;
using Facility.TablesCreator;
using Facility.Interfaces;
using Facility.Materials;
using Facility.TableDetails;

namespace FacilityTest
{
    public class TableCreatorsTests
    {
        private List<ITable<IDetail, IDetail>> _tables;

        private List<ITable<IDetail, IDetail>> GetTestTables()
        {
            var tables = new List<ITable<IDetail, IDetail>>();

            RoundTableTop roundTop = new RoundTableTop(MaterialType.GeneralPurposeChipboard, 3, 0.8, 15);
            Dictionary<TableAccessoriesType, int> accessories = new Dictionary<TableAccessoriesType, int>
            {
                { TableAccessoriesType.Shkants, 5 },
                { TableAccessoriesType.Corners, 3 },
                { TableAccessoriesType.BoltNut, 10 }
            };

            OvalTableTop top = new OvalTableTop(MaterialType.GeneralPurposeChipboard, 0.05, 2, 1, 50);
            RectangleChipboardLeg leg = new RectangleChipboardLeg(MaterialType.ConstructionChipboard, 10, 1, 1, 5);
            RectangularTableTop rectangularTableTop = new RectangularTableTop(MaterialType.SpecialChipboard ,0.07, 2, 3, 100);
            MetalRectangleLeg metalRectangleLeg = new MetalRectangleLeg(5, 0.03, 0.04 ,20);
            MetalRoundLeg metalRoundLeg = new MetalRoundLeg(0.8, 0.3, 23);


            OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", top, 5, leg);
            OvalTableWithRectangularChipboardLegs table1 = new OvalTableWithRectangularChipboardLegs("OvalTable2", top, 5, leg);
            RectangularChipboardTableWithAccessories table2 = new RectangularChipboardTableWithAccessories("Andora", rectangularTableTop, 3, leg, accessories);
            OvalTableWithMetalRectangularLegs table3 = new OvalTableWithMetalRectangularLegs("OvalTable3", top, 3, metalRectangleLeg);
            RectangularChipboardTable table4 = new RectangularChipboardTable("RectangularTable4", rectangularTableTop, 6, leg);
            RoundTableWithRoundMetalLegs table5 = new RoundTableWithRoundMetalLegs("OvalTable5", roundTop, 5, metalRoundLeg);

            return tables;
        }

        [Theory]
        [InlineData()]
        public void OvalTableWithRectangularLegsCreatorTest1(string path, string tableName, )
        {
            
        }
    }
}
