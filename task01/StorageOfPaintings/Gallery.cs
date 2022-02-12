using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for gallery is a heir of PaintingStorage class, contains 
    /// an additional field with the storage type 
    /// </summary>
    public class Gallery : PaintingStorage
    {
        public List<Hall> Halls { get; set; }
        public TypesOfStorageOfPaintings TypeOfStorage = TypesOfStorageOfPaintings.Gallery;
        
        public Gallery(List<Hall> halls)
        {
            Halls = halls;
        }

        /// <summary>
        /// Sorts number of hall and paintings in it
        /// </summary>
        /// <param name="halls">List of halls with paintings</param>
        /// <returns>Return dictionary with a list of paintings and their hall number</returns>
        public Dictionary<int, List<Painting>> GetPaintingsListByHalls(List<Hall> halls)
        {
            Dictionary<int, List<Painting>> paintings = new Dictionary<int, List<Painting>>();
            foreach (Hall hall in halls)
            {
                paintings.Add(hall.Number, hall.Paintings);
            }

            return paintings;
        }

        /// <summary>
        /// Finds all paintings from each hall
        /// </summary>
        /// <returns>List with paintings in this storage</returns>
        private List<Painting> GetAllPaintings()
        {
            List<Painting> allPaintings = new List<Painting>();

            foreach (Hall hall in Halls)
            {
                allPaintings.AddRange(hall.Paintings);
            }

            return allPaintings;
        }

        public override List<Painting> GetPaintingsByAuthor(string author)
        {
            var allPaintings = GetAllPaintings();
            List<Painting> paintingByAythor = new List<Painting>();

            foreach (Painting painting in allPaintings)
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
            var allPaintings = GetAllPaintings();
            List<Painting> paintingByName = new List<Painting>();

            foreach (Painting painting in allPaintings)
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
            var allPaintings = GetAllPaintings();
            List<Painting> paintingByGenre = new List<Painting>();

            foreach (Painting painting in allPaintings)
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
            var paintings = GetAllPaintings();
            List<Painting> similarPaintings = new List<Painting>();

            foreach (Painting painting in paintings)
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
