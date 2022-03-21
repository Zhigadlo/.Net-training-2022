using Xunit;
using Facility.TableDetails;
using System.Collections.Generic;
using Facility.Materials;
using Facility.Parsing;
using System.IO;
using Facility.Tables;

namespace FacilityTest
{
    public class ParsingTests
    {
        private string _xmlPath1 = "D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/Machines/Parsing/XMLFile1.xml";
        private string _xmlPath2 = "D:/Epam-тренинг/external training/.Net-training-2022/task02/ChipboardTablesFacility/FacilityTest/XMLFileForTest.xml";
        private string _jsonPath1 = "C:/Users/Lenovo/Desktop/JSONFileForTest.json";
        private string _jsonPath2 = "C:/Users/Lenovo/Desktop/newjsonfile.json";

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

        [Fact]
        public void XmlParsingWriteListOfObjectsTest()
        {
            StreamReader reader = new StreamReader(_xmlPath1);

            string expectedText = reader.ReadToEnd();
            expectedText = expectedText.Replace("\n", "");
            expectedText = expectedText.Replace("\t", "");

            reader.Dispose();

            XMLParsing parser = new XMLParsing();

            OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", _top, 5, _leg);
            OvalTableWithRectangularChipboardLegs table1 = new OvalTableWithRectangularChipboardLegs("OvalTable2", _top, 5, _leg);
            RectangularChipboardTableWithAccessories table2 = new RectangularChipboardTableWithAccessories("Andora", _rectangularTableTop, 3, _leg, _accessories);
            OvalTableWithMetalRectangularLegs table3 = new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg);
            RectangularChipboardTable table4 = new RectangularChipboardTable("RectangularTable4", _rectangularTableTop, 6, _leg);
            RoundTableWithRoundMetalLegs table5 = new RoundTableWithRoundMetalLegs("OvalTable5", _roundTop, 5, _metalRoundLeg);

            parser.WriteListOfObjects(_xmlPath2, table, table1, table2, table3, table4, table5);

            reader = new StreamReader(_xmlPath1);

            string actualText = reader.ReadToEnd();
            actualText = actualText.Replace("\n", "");
            actualText = actualText.Replace("\t", "");

            reader.Dispose();

            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void XmlStreamParsingWriteListOfObjectsTest()
        {
            StreamReader reader = new StreamReader(_xmlPath1);

            string expectedText = reader.ReadToEnd();
            expectedText = expectedText.Replace("\n", "");
            expectedText = expectedText.Replace("\t", "");

            reader.Dispose();

            XMLStreamParsing parser = new XMLStreamParsing();

            OvalTableWithRectangularChipboardLegs table = new OvalTableWithRectangularChipboardLegs("OvalTable", _top, 5, _leg);
            OvalTableWithRectangularChipboardLegs table1 = new OvalTableWithRectangularChipboardLegs("OvalTable2", _top, 5, _leg);
            RectangularChipboardTableWithAccessories table2 = new RectangularChipboardTableWithAccessories("Andora", _rectangularTableTop, 3, _leg, _accessories);
            OvalTableWithMetalRectangularLegs table3 = new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg);
            RectangularChipboardTable table4 = new RectangularChipboardTable("RectangularTable4", _rectangularTableTop, 6, _leg);
            RoundTableWithRoundMetalLegs table5 = new RoundTableWithRoundMetalLegs("OvalTable5", _roundTop, 5, _metalRoundLeg);

            parser.WriteListOfObjects(_xmlPath2, table, table1, table2, table3, table4, table5);
            
            reader = new StreamReader(_xmlPath1);

            string actualText = reader.ReadToEnd();
            actualText = actualText.Replace("\n", "");
            actualText = actualText.Replace("\t", "");

            reader.Dispose();

            Assert.Equal(expectedText, actualText);
        }

        [Fact]
        public void JsonParsingWriteObjectTest()
        {
            OvalTableWithMetalRectangularLegs table3 = new OvalTableWithMetalRectangularLegs("OvalTable3", _top, 3, _metalRectangleLeg);

            JsonParsing<OvalTableWithMetalRectangularLegs>.WriteObjectInJsonFile(table3, _jsonPath1);

            StreamReader reader1 = new StreamReader(_jsonPath2);

            string actualText = reader1.ReadToEnd();
            actualText.Replace("\t", "");
            actualText.Replace("\n", "");
            reader1.Dispose();

            StreamReader reader2 = new StreamReader(_jsonPath1);

            string expectedText = reader2.ReadToEnd();
            expectedText.Replace("\t", "");
            expectedText.Replace("\n", "");

            reader2.Dispose();

            Assert.True(expectedText.Equals(actualText));
        }
    }
}

