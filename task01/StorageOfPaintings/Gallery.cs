using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for gallery is a heir of PaintingStorage class, contains 
    /// an additional fields with the storage type and list of gallery halls
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
        public Dictionary<int, List<Painting>> GetPaintingsListByHalls()
        {
            Dictionary<int, List<Painting>> paintings = new Dictionary<int, List<Painting>>();
            foreach (Hall hall in Halls)
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
        /// <summary>
        /// Finds in gallery all paintings of a certain author  
        /// </summary>
        /// <param name="author">name of author of painting</param>
        /// <returns>List with paintings of a certain author</returns>
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
        /// <summary>
        /// Finds in gallery all paintings with a certain name
        /// </summary>
        /// <param name="name">Name of painting</param>
        /// <returns>List paintings with a certain name</returns>
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
        /// <summary>
        /// Finds in gallery all paintings of a certain genre
        /// </summary>
        /// <param name="genre">Genre for search paintings</param>
        /// <returns>List with paintings of a certain genre</returns>
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
        /// <summary>
        /// Find in gallery all similar painting
        /// </summary>
        /// <param name="paintingForCompare">Painting for compare</param>
        /// <returns>List with similar paintings</returns>
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

        public override string ToString()
        {
            return $"{TypeOfStorage} with {Halls.Count} halls and {GetAllPaintings().Count} paintings";
        }

        public override int GetHashCode()
        {
            return Halls.GetHashCode() + TypeOfStorage.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            bool IsEqual = true;

            foreach (Hall hall in Halls)
            {
                if (!hall.Equals(obj))
                {
                    IsEqual = false;
                    break;
                }
            }

            if (!(obj is Gallery) || obj == null)
                return false;
            else
                return IsEqual;
        }
    }
}
