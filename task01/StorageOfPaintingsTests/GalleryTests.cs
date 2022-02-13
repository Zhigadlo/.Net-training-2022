using Microsoft.VisualStudio.TestTools.UnitTesting;
using StorageOfPaintings;
using Paintings;
using System.Collections.Generic;
using System;

namespace StorageOfPaintingsTests
{
    [TestClass]
    public class GalleryTests
    {
        private List<Hall> _halls = new List<Hall>();

        [TestInitialize]
        public void TestInitialize()
        {
            var paintingsForTest = new List<Painting>();
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(10, 20); i++)
            {
                paintingsForTest.Add(new Painting("painting" + i.ToString(), "author" + rnd.Next(1, 7).ToString(),
                    "genre" + rnd.Next(1, 5).ToString(), rnd.Next(1, 5), new DateTime(rnd.Next(2000, 2014),
                    rnd.Next(1, 12), rnd.Next(1, 30))));
            }

            for(int i = 0; i < 3; i++)
            {
                _halls.Add(new Hall(i + 1, new List<Painting>()));
            }

            for(int i = 0; i < paintingsForTest.Count; i++)
            {
                int num = rnd.Next(1, 3);
                switch(num)
                {
                    case 1:
                        _halls[0].Paintings.Add(paintingsForTest[i]);
                        break;
                    case 2:
                        _halls[1].Paintings.Add(paintingsForTest[i]);
                        break;
                    case 3:
                        _halls[2].Paintings.Add(paintingsForTest[i]);
                        break;
                }
            }

            
        }

        [TestMethod]
        public void TestGetPaintingsListByHalls()
        {
            
            Gallery gallery = new Gallery(_halls);

            Dictionary<int, List<Painting>> actualDict = new Dictionary<int, List<Painting>>();
            
            for(int i = 0; i < _halls.Count; i++)
            {
                actualDict.Add(_halls[i].Number, _halls[i].Paintings);
            }

            Dictionary<int, List<Painting>> expectedDict = gallery.GetPaintingsListByHalls();

            for(int i = 1; i <= actualDict.Count; i++)
            {
                for(int j = 0; j < actualDict[i].Count; j++)
                {
                    Assert.AreEqual(expectedDict[i][j].Name, actualDict[i][j].Name);
                    Assert.AreEqual(expectedDict[i][j].Author, actualDict[i][j].Author);
                    Assert.AreEqual(expectedDict[i][j].Genre, actualDict[i][j].Genre);
                    Assert.AreEqual(expectedDict[i][j].DateOfReceipt, actualDict[i][j].DateOfReceipt);
                    Assert.AreEqual(expectedDict[i][j].NumberOfHallPlace, actualDict[i][j].NumberOfHallPlace);
                }
            }
        }

        [TestMethod]
        public void TestGetPaintingsByAuthor()
        {
            Gallery gallery = new Gallery(_halls);

            string authorForSearch = "author3";

            List<Painting> actualPaintings = new List<Painting>();

            for(int i = 0; i < _halls.Count; i++)
            {
                for(int j = 0; j < _halls[i].Paintings.Count; j++)
                {
                    var paintingForAdd = _halls[i].Paintings[j];
                    if (paintingForAdd.Author == authorForSearch)
                        actualPaintings.Add(paintingForAdd);
                }
            }

            List<Painting> expectedPaintings = gallery.GetPaintingsByAuthor(authorForSearch);

            for(int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Author, actualPaintings[i].Author);
            }
        }

        [TestMethod]
        public void TestGetPaintingsByGenre()
        {
            Gallery gallery = new Gallery(_halls);

            string genreForTest = "genre1";

            List<Painting> actualPaintings = new List<Painting>();

            for (int i = 0; i < _halls.Count; i++)
            {
                for (int j = 0; j < _halls[i].Paintings.Count; j++)
                {
                    var paintingForAdd = _halls[i].Paintings[j];
                    if (paintingForAdd.Genre == genreForTest)
                        actualPaintings.Add(paintingForAdd);
                }
            }

            List<Painting> expectedPaintings = gallery.GetPaintingsByGenre(genreForTest);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Genre, actualPaintings[i].Genre);
            }
        }

        [TestMethod]
        public void TestGetPaintingsByName()
        {
            Gallery gallery = new Gallery(_halls);

            string nameForSearch = "painting4";

            List<Painting> actualPaintings = new List<Painting>();

            for (int i = 0; i < _halls.Count; i++)
            {
                for (int j = 0; j < _halls[i].Paintings.Count; j++)
                {
                    var paintingForAdd = _halls[i].Paintings[j];
                    if (paintingForAdd.Name == nameForSearch)
                        actualPaintings.Add(paintingForAdd);
                }
            }

            List<Painting> expectedPaintings = gallery.GetPaintingsByName(nameForSearch);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Name, actualPaintings[i].Name);
            }
        }

        [TestMethod]
        public void TestGetSimilarPaintings()
        {
            Random rnd = new Random();
            Gallery gallery = new Gallery(_halls);

            Painting paintingForTest = new Painting("painting" + rnd.Next(1, 20).ToString(), 
                "author" + rnd.Next(1, 7).ToString(), "genre" + rnd.Next(1, 5).ToString(), rnd.Next(1, 5), 
                new DateTime(rnd.Next(2000, 2014), rnd.Next(1, 12), rnd.Next(1, 30)));

            List<Painting> actualPaintings = new List<Painting>();

            for (int i = 0; i < _halls.Count; i++)
            {
                for (int j = 0; j < _halls[i].Paintings.Count; j++)
                {
                    var paintingForAdd = _halls[i].Paintings[j];
                    if (paintingForAdd.Author == paintingForTest.Author &&
                        paintingForAdd.Genre == paintingForTest.Author)
                        actualPaintings.Add(paintingForAdd);
                }
            }

            List<Painting> expectedPaintings = gallery.GetSimilarPaintings(paintingForTest);

            for (int i = 0; i < actualPaintings.Count; i++)
            {
                Assert.AreEqual(expectedPaintings[i].Author, actualPaintings[i].Author);
                Assert.AreEqual(expectedPaintings[i].Genre, actualPaintings[i].Genre);
            }
        }
    }
}