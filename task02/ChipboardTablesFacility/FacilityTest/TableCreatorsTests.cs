using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;
using Facility.TablesCreator;
using System.Collections.Generic;
using Xunit;

namespace FacilityTest
{
    public class TableCreatorsTests
    {

        private RoundTableTop _roundTop = new RoundTableTop(MaterialType.GeneralPurposeChipboard, 3, 0.8, 15);
        private Dictionary<TableAccessoriesType, int> _accessories = new Dictionary<TableAccessoriesType, int>
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

        private string _path1 = @"..\..\..\XMLFile1.xml";
        private string _path2 = @"..\..\..\XMLFile2.xml";

        [Fact]
        public void OvalTableWithRectangularChipboardLegsCreatorXmlTest()
        {
            OvalTableWithRectangularChipboardLegsCreator creator = new OvalTableWithRectangularChipboardLegsCreator();

            List<OvalTableWithRectangularChipboardLegs> expectedTables = new List<OvalTableWithRectangularChipboardLegs>();
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable", _top, 5, _leg));
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable2", _top, 5, _leg));
            var tables = creator.GetTablesFromXmlFile(_path1);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void OvalTableWithRectangularChipboardLegsCreatorXmlStreamTest()
        {
            OvalTableWithRectangularChipboardLegsCreator creator = new OvalTableWithRectangularChipboardLegsCreator();

            List<OvalTableWithRectangularChipboardLegs> expectedTables = new List<OvalTableWithRectangularChipboardLegs>();
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable", _top, 5, _leg));
            expectedTables.Add(new OvalTableWithRectangularChipboardLegs("OvalTable2", _top, 5, _leg));
            var tables = creator.GetTablesFromXmlFileStream(_path2);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableWithAccessoriesCreatorXmlTest()
        {
            RectangularChipboardTableWithAccessoriesCreator creator = new RectangularChipboardTableWithAccessoriesCreator();

            List<RectangularChipboardTableWithAccessories> expectedTables = new List<RectangularChipboardTableWithAccessories>();
            expectedTables.Add(new RectangularChipboardTableWithAccessories("Andora", _rectangularTableTop, 3, _leg, _accessories));

            var tables = creator.GetTablesFromXmlFile(_path1);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableWithAccessoriesCreatorXmlStreamTest()
        {
            RectangularChipboardTableWithAccessoriesCreator creator = new RectangularChipboardTableWithAccessoriesCreator();

            List<RectangularChipboardTableWithAccessories> expectedTables = new List<RectangularChipboardTableWithAccessories>();
            expectedTables.Add(new RectangularChipboardTableWithAccessories("Andora", _rectangularTableTop, 3, _leg, _accessories));

            var tables = creator.GetTablesFromXmlFileStream(_path2);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void OvalTableWithMetalRectangularLegsCreatorXmlTest()
        {
            OvalTableWithMetalRectangularLegsCreator creator = new OvalTableWithMetalRectangularLegsCreator();

            List<OvalTableWithMetalRectangularLegs> expectedTables = new List<OvalTableWithMetalRectangularLegs>();
            expectedTables.Add(new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg));

            var tables = creator.GetTablesFromXmlFile(_path1);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void OvalTableWithMetalRectangularLegsCreatorXmlStreamTest()
        {
            OvalTableWithMetalRectangularLegsCreator creator = new OvalTableWithMetalRectangularLegsCreator();

            List<OvalTableWithMetalRectangularLegs> expectedTables = new List<OvalTableWithMetalRectangularLegs>();
            expectedTables.Add(new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg));

            var tables = creator.GetTablesFromXmlFileStream(_path2);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableCreatorXmlTest()
        {
            RectangularChipboardTableCreator creator = new RectangularChipboardTableCreator();

            List<RectangularChipboardTable> expectedTables = new List<RectangularChipboardTable>();
            expectedTables.Add(new RectangularChipboardTable("RectangularTable4", _rectangularTableTop, 6, _leg));

            var tables = creator.GetTablesFromXmlFile(_path1);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RectangularChipboardTableCreatorXmlStreamTest()
        {
            RectangularChipboardTableCreator creator = new RectangularChipboardTableCreator();

            List<RectangularChipboardTable> expectedTables = new List<RectangularChipboardTable>();
            expectedTables.Add(new RectangularChipboardTable("RectangularTable4", _rectangularTableTop, 6, _leg));

            var tables = creator.GetTablesFromXmlFileStream(_path2);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RoundTableWithRoundMetalLegsCreatorXmlTest()
        {
            RoundTableWithRoundMetalLegsCreator creator = new RoundTableWithRoundMetalLegsCreator();

            List<RoundTableWithRoundMetalLegs> expectedTables = new List<RoundTableWithRoundMetalLegs>();
            expectedTables.Add(new RoundTableWithRoundMetalLegs("OvalTable5", _roundTop, 5, _metalRoundLeg));

            var tables = creator.GetTablesFromXmlFile(_path1);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }

        [Fact]
        public void RoundTableWithRoundMetalLegsCreatorXmlStreamTest()
        {
            RoundTableWithRoundMetalLegsCreator creator = new RoundTableWithRoundMetalLegsCreator();

            List<RoundTableWithRoundMetalLegs> expectedTables = new List<RoundTableWithRoundMetalLegs>();
            expectedTables.Add(new RoundTableWithRoundMetalLegs("OvalTable5", _roundTop, 5, _metalRoundLeg));

            var tables = creator.GetTablesFromXmlFileStream(_path2);

            for (int i = 0; i < expectedTables.Count; i++)
            {
                Assert.True(tables[i].Equals(expectedTables[i]));
            }
        }
    }
}
