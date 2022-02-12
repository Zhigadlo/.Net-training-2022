using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageOfPaintings;
using Paintings;
using System.Collections.Generic;
using System;

namespace StorageOfPaintingsTests
{
    class PaintingTests
    {
        [TestMethod]
        public void TestGetStorageDays()
        {
            Painting painting = new Painting("name", "author", "genre", 3, new DateTime(2022, 1, 12));

            int actualDays = (DateTime.Now - painting.DateOfReceipt).Days;
            int expectedDays = painting.GetStorageDays();

            Assert.AreEqual(expectedDays, actualDays);
        }
    }
}
