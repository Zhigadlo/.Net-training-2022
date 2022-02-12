using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageOfPaintings;
using Paintings;
using System.Collections.Generic;
using System;

namespace StorageOfPaintingsTests
{
    [TestClass]
    public class ReserveTests
    {
        
        [TestMethod]
        public void TestGetPaintingsByAuthor()
        {
            Painting painting1 = new Painting("painting1", "author1", "genre1", 1, new DateTime(2007, 12, 25));
            Painting painting2 = new Painting("painting2", "author2", "genre2", 3, new DateTime(1914, 7, 5));
            Painting painting3 = new Painting("painting3", "author3", "genre1", 2, new DateTime(2001, 10, 15));
            Painting painting4 = new Painting("painting4", "author1", "genre4", 1, new DateTime(1943, 2, 3));
            Painting painting5 = new Painting("painting5", "author3", "genre1", 2, new DateTime(1999, 3, 29));
            Painting painting6 = new Painting("painting6", "author5", "genre3", 2, new DateTime(1987, 6, 19));
            Painting painting7 = new Painting("painting7", "author2", "genre5", 3, new DateTime(2007, 8, 17));
            Painting painting8 = new Painting("painting8", "author7", "genre1", 1, new DateTime(2019, 12, 9));
            Painting painting9 = new Painting("painting9", "author6", "genre4", 4, new DateTime(2014, 8, 4));
            Painting painting10 = new Painting("painting10", "author5", "genre2", 3, new DateTime(1991, 11, 5));
            Painting painting11 = new Painting("painting11", "author1", "genre3", 4, new DateTime(2011, 2, 19));
            Painting painting12 = new Painting("painting12", "author6", "genre5", 5, new DateTime(2005, 1, 11));;

            List<Painting> paintingsForTest = new List<Painting>()
            {
                painting1, painting2, painting3, painting4, painting5, painting6, painting7,
                painting8, painting9, painting10, painting11, painting12
            };

            Reserve reserve = new Reserve(paintingsForTest);

            string authorForSearch = "author3";

            List<Painting> actualPaintings = new List<Painting>() { painting3, painting5 };
            List<Painting> expectedPaintings = reserve.GetPaintingsByAuthor(authorForSearch);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Author, actualPaintings[i].Author);
            }
        }

        [TestMethod]
        public void TestGetPaintingsByGenre()
        {
            Painting painting1 = new Painting("painting1", "author1", "genre1", 1, new DateTime(2007, 12, 25));
            Painting painting2 = new Painting("painting2", "author2", "genre2", 3, new DateTime(1914, 7, 5));
            Painting painting3 = new Painting("painting3", "author3", "genre1", 2, new DateTime(2001, 10, 15));
            Painting painting4 = new Painting("painting4", "author1", "genre4", 1, new DateTime(1943, 2, 3));
            Painting painting5 = new Painting("painting5", "author3", "genre1", 2, new DateTime(1999, 3, 29));
            Painting painting6 = new Painting("painting6", "author5", "genre3", 2, new DateTime(1987, 6, 19));
            Painting painting7 = new Painting("painting7", "author2", "genre5", 3, new DateTime(2007, 8, 17));
            Painting painting8 = new Painting("painting8", "author7", "genre1", 1, new DateTime(2019, 12, 9));
            Painting painting9 = new Painting("painting9", "author6", "genre4", 4, new DateTime(2014, 8, 4));
            Painting painting10 = new Painting("painting10", "author5", "genre2", 3, new DateTime(1991, 11, 5));
            Painting painting11 = new Painting("painting11", "author1", "genre3", 4, new DateTime(2011, 2, 19));
            Painting painting12 = new Painting("painting12", "author6", "genre5", 5, new DateTime(2005, 1, 11)); ;

            List<Painting> paintingsForTest = new List<Painting>()
            {
                painting1, painting2, painting3, painting4, painting5, painting6, painting7,
                painting8, painting9, painting10, painting11, painting12
            };

            Reserve reserve = new Reserve(paintingsForTest);

            string genreForSearch = "genre1";

            List<Painting> actualPaintings = new List<Painting>() { painting1, painting3, painting5, painting8 };
            List<Painting> expectedPaintings = reserve.GetPaintingsByGenre(genreForSearch);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Genre, actualPaintings[i].Genre);
            }
        }

        [TestMethod]
        public void TestGetPaintingsByName()
        {
            Painting painting1 = new Painting("painting1", "author1", "genre1", 1, new DateTime(2007, 12, 25));
            Painting painting2 = new Painting("painting2", "author2", "genre2", 3, new DateTime(1914, 7, 5));
            Painting painting3 = new Painting("painting3", "author3", "genre1", 2, new DateTime(2001, 10, 15));
            Painting painting4 = new Painting("painting4", "author1", "genre4", 1, new DateTime(1943, 2, 3));
            Painting painting5 = new Painting("painting5", "author3", "genre1", 2, new DateTime(1999, 3, 29));
            Painting painting6 = new Painting("painting6", "author5", "genre3", 2, new DateTime(1987, 6, 19));
            Painting painting7 = new Painting("painting7", "author2", "genre5", 3, new DateTime(2007, 8, 17));
            Painting painting8 = new Painting("painting8", "author7", "genre1", 1, new DateTime(2019, 12, 9));
            Painting painting9 = new Painting("painting4", "author6", "genre4", 4, new DateTime(2014, 8, 4));
            Painting painting10 = new Painting("painting10", "author5", "genre2", 3, new DateTime(1991, 11, 5));
            Painting painting11 = new Painting("painting11", "author1", "genre3", 4, new DateTime(2011, 2, 19));
            Painting painting12 = new Painting("painting12", "author6", "genre5", 5, new DateTime(2005, 1, 11));

            List<Painting> paintingsForTest = new List<Painting>()
            {
                painting1, painting2, painting3, painting4, painting5, painting6, painting7,
                painting8, painting9, painting10, painting11, painting12
            };

            Reserve reserve = new Reserve(paintingsForTest);

            string nameForSearch = "painting4";

            List<Painting> actualPaintings = new List<Painting>() { painting4, painting9 };
            List<Painting> expectedPaintings = reserve.GetPaintingsByName(nameForSearch);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Name, actualPaintings[i].Name);
            }
        }

        [TestMethod]
        public void TestGetSimilarPaintings()
        {
            Painting painting1 = new Painting("painting1", "author1", "genre1", 1, new DateTime(2007, 12, 25));
            Painting painting2 = new Painting("painting2", "author2", "genre2", 3, new DateTime(1914, 7, 5));
            Painting painting3 = new Painting("painting3", "author3", "genre1", 2, new DateTime(2001, 10, 15));
            Painting painting4 = new Painting("painting4", "author1", "genre4", 1, new DateTime(1943, 2, 3));
            Painting painting5 = new Painting("painting5", "author7", "genre1", 2, new DateTime(1999, 3, 29));
            Painting painting6 = new Painting("painting6", "author5", "genre3", 2, new DateTime(1987, 6, 19));
            Painting painting7 = new Painting("painting7", "author2", "genre5", 3, new DateTime(2007, 8, 17));
            Painting painting8 = new Painting("painting8", "author7", "genre1", 1, new DateTime(2019, 12, 9));
            Painting painting9 = new Painting("painting9", "author6", "genre4", 4, new DateTime(2014, 8, 4));
            Painting painting10 = new Painting("painting10", "author5", "genre2", 3, new DateTime(1991, 11, 5));
            Painting painting11 = new Painting("painting11", "author1", "genre3", 4, new DateTime(2011, 2, 19));
            Painting painting12 = new Painting("painting12", "author6", "genre5", 5, new DateTime(2005, 1, 11));

            List<Painting> paintingsForTest = new List<Painting>()
            {
                painting1, painting2, painting3, painting4, painting5, painting6, painting7,
                painting8, painting9, painting10, painting11, painting12
            };

            Reserve reserve = new Reserve(paintingsForTest);

            Painting paintingForTest = new Painting("Painting", "author7", "genre1", 1, new DateTime(2022, 1, 17));

            List<Painting> actualPaintings = new List<Painting>() { painting5, painting8 };
            List<Painting> expectedPaintings = reserve.GetSimilarPaintings(paintingForTest);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Author, actualPaintings[i].Author);
                Assert.AreEqual(expectedPaintings[i].Genre, actualPaintings[i].Genre);
            }
        }
    }
}