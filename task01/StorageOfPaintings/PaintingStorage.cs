using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Abstract class for the storage of paintings. Contains a list of halls 
    /// with paintings and methods for searching for paintings
    /// </summary>
    public abstract class PaintingStorage
    {
        public List<Hall> Halls { get; set; }

        public PaintingStorage(List<Hall> halls)
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

            foreach(Hall hall in Halls)
            {
                allPaintings.AddRange(hall.Paintings);
            }

            return allPaintings;
        }
        /// <summary>
        /// Finds all paintings of a certain author  
        /// </summary>
        /// <param name="author">name of author of painting</param>
        /// <returns>List with paintings of a certain author</returns>
        public List<Painting> GetPaintingsByAuthor(string author)
        {
            var allPainting = GetAllPaintings();
            List<Painting> paintingByAythor = new List<Painting>();
            
            foreach (Painting painting in allPainting)
            {
                if(painting.Author == author)
                {
                    paintingByAythor.Add(painting);
                }
            }

            return paintingByAythor;
        }
        /// <summary>
        /// Finds all paintings with a certain name
        /// </summary>
        /// <param name="name">Name of painting</param>
        /// <returns>List paintings with a certain name</returns>
        public List<Painting> GetPaintingsByName(string name)
        {
            var allPainting = GetAllPaintings();
            List<Painting> paintingByName = new List<Painting>();

            foreach (Painting painting in allPainting)
            {
                if (painting.Name == name)
                {
                    paintingByName.Add(painting);
                }
            }

            return paintingByName;
        }
        /// <summary>
        /// Finds all paintings of a certain genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>List with paintings of a certain genre</returns>
        public List<Painting> GetPaintingsByGenre(string genre)
        {
            var allPainting = GetAllPaintings();
            List<Painting> paintingByGenre = new List<Painting>();

            foreach (Painting painting in allPainting)
            {
                if (painting.Genre == genre)
                {
                    paintingByGenre.Add(painting);
                }
            }

            return paintingByGenre;
        }
        /// <summary>
        /// Find all similar painting
        /// </summary>
        /// <param name="paintingForCompare">Painting for compare</param>
        /// <returns>List with similar paintings</returns>
        public List<Painting> GetSimilarPaintings(Painting paintingForCompare)
        {
            var paintings = GetAllPaintings();
            List<Painting> similarPaintings = new List<Painting>();

            foreach(Painting painting in paintings)
            {
                if(paintingForCompare.Genre == painting.Genre ||
                   paintingForCompare.YearOfRealese == painting.YearOfRealese ||
                   paintingForCompare.Author == painting.Author)
                    similarPaintings.Add(painting);
            }

            return similarPaintings;
        }
    }
}