using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for reserve is a heir of PaintingStorage class, contains 
    /// an additional field with the storage type 
    /// </summary>
    public class Reserve : PaintingStorage
    {
        public List<Painting> Paintings { get; set; }
        public TypesOfStorageOfPaintings TypeOfStorage = TypesOfStorageOfPaintings.Reserve;
        
        public Reserve(List<Painting> paintings)
        {
            Paintings = paintings;
        }

        public override List<Painting> GetPaintingsByAuthor(string author)
        {
            List<Painting> paintingByAythor = new List<Painting>();

            foreach (Painting painting in Paintings)
            {
                if (painting.Author == author)
                {
                    paintingByAythor.Add(painting);
                }
            }

            return paintingByAythor;
        }

        public override List<Painting> GetPaintingsByName(string name)
        {
            List<Painting> paintingByName = new List<Painting>();

            foreach (Painting painting in Paintings)
            {
                if (painting.Name == name)
                {
                    paintingByName.Add(painting);
                }
            }

            return paintingByName;
        }

        public override List<Painting> GetPaintingsByGenre(string genre)
        {
            List<Painting> paintingByGenre = new List<Painting>();

            foreach (Painting painting in Paintings)
            {
                if (painting.Genre == genre)
                {
                    paintingByGenre.Add(painting);
                }
            }

            return paintingByGenre;
        }

        public override List<Painting> GetSimilarPaintings(Painting paintingForCompare)
        {
            List<Painting> similarPaintings = new List<Painting>();

            foreach (Painting painting in Paintings)
            {
                if (paintingForCompare.Genre == painting.Genre &&
                   paintingForCompare.Author == painting.Author)
                {
                    similarPaintings.Add(painting);
                }
            }

            return similarPaintings;
        }
    }
}
