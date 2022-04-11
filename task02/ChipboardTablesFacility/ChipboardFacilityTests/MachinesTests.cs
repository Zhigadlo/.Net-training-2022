using Facility.Machines;
using Facility.Materials;
using Facility.TableDetails;
using Facility.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facility.Interfaces;
using System;
using System.Collections.Generic;

namespace ChipboardFacilityTests
{
    [TestClass]
    public class MachinesTests
    {
        private static List<ITable> _tables = new List<ITable>();
        [TestInitialize]
        public void TestInitialize()
        {
            WorkPiece pieceOfChipboardForTopOfTable = new WorkPiece(1000, 50, 1000, MaterialType.Chipboard);
            WorkPiece pieceOfChipboardForLegsOfTable = new WorkPiece(100, 100, 100, MaterialType.Chipboard);
            WorkPiece pieceOfMetal = new WorkPiece(120, 100, 50, MaterialType.Metal);

            UniversalMachine chipboardMachine = new UniversalMachine();
            MachineForMetal metalMachine = new MachineForMetal();

            var tableTop1 = chipboardMachine.GetTableTop(pieceOfChipboardForTopOfTable, 1, 100, 200);
            var tableTop2 = chipboardMachine.GetTableTop(pieceOfChipboardForTopOfTable, 2, 120, 120);

            List<IDetail> legsForTable1 = new List<IDetail>();
            List<IDetail> legsForTable2 = new List<IDetail>();

            Dictionary<TableAccessoriesType, int> accessories = new Dictionary<TableAccessoriesType, int>
            {
                { TableAccessoriesType.Ties, 5 },
                { TableAccessoriesType.Shkants, 12 },
                { TableAccessoriesType.Corners, 4 }
            };

            for (int i = 0; i < 4; i++)
            {
                legsForTable1.Add(chipboardMachine.GetTableLeg(pieceOfChipboardForLegsOfTable, 90, 4, 4));
                legsForTable2.Add(metalMachine.GetTableLeg(pieceOfMetal, 110, 2));
            }

            _tables.Add(new TableWithAccessories(legsForTable1, tableTop1, accessories));
            _tables.Add(new OrdinaryTable(legsForTable2, tableTop2));
        }
        [TestMethod]
        //[NUnit.Framework.TestCase(108235, 0)]
        public void MachinesTest1()
        {
            double expectedPrice = 108235;
            double actualPrice = _tables[0].Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestMethod]
        public void MachinesTest2()
        {
            double expectedPrice = (115200 + 4 * 2 * 2 * Math.PI * 110 * (8 + 8)) * 1.05;
            double actualPrice = _tables[1].Price;

            Assert.AreEqual(expectedPrice, actualPrice);
        }
    }
}