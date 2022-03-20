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

        private RoundTableTop _roundTop = new RoundTableTop(MaterialType.GeneralPurposeChipboard, 3, 0.8, 15);
        private Dictionary<TableAccessoriesType, int> accessories = new Dictionary<TableAccessoriesType, int>
            {
                { TableAccessoriesType.Shkants, 5 },
                { TableAccessoriesType.Corners, 3 },
                { TableAccessoriesType.BoltNut, 10 }
            };

        private OvalTableTop _top = new OvalTableTop(MaterialType.GeneralPurposeChipboard, 0.05, 2, 1, 50);
        private RectangleChipboardLeg _leg = new RectangleChipboardLeg(MaterialType.ConstructionChipboard, 10, 1, 1, 5);
        private RectangularTableTop _rectangularTableTop = new RectangularTableTop(MaterialType.SpecialChipboard, 0.07, 2, 3, 100);
        private MetalRectangleLeg _metalRectangleLeg = new MetalRectangleLeg(5, 0.03, 0.04, 20);
        private MetalRoundLeg _metalRoundLeg = new MetalRoundLeg(0.8, 0.3, 23);

        private string _path = "D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";
        public static List<ITable<IDetail, IDetail>> GetTestTables()
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

        [Fact]
        public void OvalTableWithRectangularChipboardLegsCreatorTest()
        {
            OvalTableWithRectangularChipboardLegsCreator creator = new OvalTableWithRectangularChipboardLegsCreator();
             
            List<OvalTableWithRectangularChipboardLegs> expectedTables = new List<OvalTableWithRectangularChipboardLegs>();
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable", _top, 5, _leg));
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable2", _top, 5, _leg));
            var tables = creator.GetTablesFromXmlFile(_path);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableWithAccessoriesCreatorTest()
        {
            RectangularChipboardTableWithAccessoriesCreator creator = new RectangularChipboardTableWithAccessoriesCreator();

            List<RectangularChipboardTableWithAccessories> expectedTables = new List<RectangularChipboardTableWithAccessories>();
            expectedTables.Add(new RectangularChipboardTableWithAccessories("Andora", _rectangularTableTop, 3, _leg, accessories));

            var tables = creator.GetTablesFromXmlFile(_path);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void OvalTableWithMetalRectangularLegsCreatorTest()
        {
            OvalTableWithMetalRectangularLegsCreator creator = new OvalTableWithMetalRectangularLegsCreator();

            List<OvalTableWithMetalRectangularLegs> expectedTables = new List<OvalTableWithMetalRectangularLegs>();
            expectedTables.Add(new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg));

            var tables = creator.GetTablesFromXmlFile(_path);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableCreatorTest()
        {
            RectangularChipboardTableCreator creator = new RectangularChipboardTableCreator();

            List<RectangularChipboardTable> expectedTables = new List<RectangularChipboardTable>();
            expectedTables.Add(new RectangularChipboardTable("RectangularTable4", _rectangularTableTop, 6, _leg));

            var tables = creator.GetTablesFromXmlFile(_path);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RoundTableWithRoundMetalLegsCreatorTest()
        {
            RoundTableWithRoundMetalLegsCreator creator = new RoundTableWithRoundMetalLegsCreator();

            List<RoundTableWithRoundMetalLegs> expectedTables = new List<RoundTableWithRoundMetalLegs>();
            expectedTables.Add(new RoundTableWithRoundMetalLegs("OvalTable5", _roundTop, 5, _metalRoundLeg));

            var tables = creator.GetTablesFromXmlFile(_path);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }
    }
}
