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
        private List<Painting> _paintingsForTest = new List<Painting>();
        
        [TestInitialize]
        public void TestInitialize()
        {
            Random rnd = new Random();
            for (int i = 0; i < 12; i++)
            {
                _paintingsForTest.Add(new Painting("painting" + i.ToString(), "author" + rnd.Next(1, 7).ToString(), 
                    "genre" + rnd.Next(1,5).ToString(), rnd.Next(1, 5), new DateTime(rnd.Next(2000, 2014),
                    rnd.Next(1, 12), rnd.Next(1, 30))));
            }

        }

        [TestMethod]
        public void TestGetPaintingsByAuthor()
        {
            Reserve reserve = new Reserve(_paintingsForTest);
            string authorForSearch = "author3";

            List<Painting> expectedPaintings = reserve.GetPaintingsByAuthor(authorForSearch);

            int j = 0;
            for (int i = 0; i < _paintingsForTest.Count; i++)
            {
                if (_paintingsForTest[i].Author == authorForSearch)
                {
                    Assert.AreEqual(expectedPaintings[j].Author, _paintingsForTest[i].Author);
                    j++;
                }
            }
        }

        [TestMethod]
        public void TestGetPaintingsByGenre()
        {

            string genreForSearch = "genre1";

            Reserve reserve = new Reserve(_paintingsForTest);

            List<Painting> expectedPaintings = reserve.GetPaintingsByGenre(genreForSearch);

            int j = 0;
            for (int i = 0; i < _paintingsForTest.Count; i++)
            {
                if (_paintingsForTest[i].Genre == genreForSearch)
                {
                    Assert.AreEqual(expectedPaintings[j].Genre, _paintingsForTest[i].Genre);
                    j++;
                }
            }
        }

        [TestMethod]
        public void TestGetPaintingsByName()
        {
            Reserve reserve = new Reserve(_paintingsForTest);

            string nameForSearch = "painting4";

            List<Painting> expectedPaintings = reserve.GetPaintingsByName(nameForSearch);

            int j = 0;
            for (int i = 0; i < _paintingsForTest.Count; i++)
            {
                if (_paintingsForTest[i].Name == nameForSearch)
                {
                    Assert.AreEqual(expectedPaintings[j].Name, _paintingsForTest[i].Name);
                    j++;
                }
            }
        }

        [TestMethod]
        public void TestGetSimilarPaintings()
        {
            Reserve reserve = new Reserve(_paintingsForTest);

            Painting paintingForTest = new Painting("Painting", "author7", "genre1", 1, new DateTime(2022, 1, 17));

            List<Painting> expectedPaintings = reserve.GetSimilarPaintings(paintingForTest);

            int j = 0;
            for (int i = 0; i < _paintingsForTest.Count; i++)
            {
                if (_paintingsForTest[i].Genre == paintingForTest.Genre
                    && _paintingsForTest[i].Author == paintingForTest.Author)
                {
                    Assert.AreEqual(expectedPaintings[i].Author, _paintingsForTest[i].Author);
                    Assert.AreEqual(expectedPaintings[i].Genre, _paintingsForTest[i].Genre);
                    j++;
                }
            }
        }
    }
}