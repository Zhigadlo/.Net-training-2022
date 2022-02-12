using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for reserve is a heir of PaintingStorage class, contains 
    /// an additional fields with the storage type and list of paintings
    /// </summary>
    public class Reserve : PaintingStorage
    {
        public List<Painting> Paintings { get; set; }
        public TypesOfStorageOfPaintings TypeOfStorage = TypesOfStorageOfPaintings.Reserve;
        
        public Reserve(List<Painting> paintings)
        {
            Paintings = paintings;
        }
        /// <summary>
        /// Finds in reserve all paintings of a certain author  
        /// </summary>
        /// <param name="author">name of author of painting</param>
        /// <returns>List with paintings of a certain author</returns>
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
        /// <summary>
        /// Finds in reserve all paintings with a certain name
        /// </summary>
        /// <param name="name">Name of painting</param>
        /// <returns>List paintings with a certain name</returns>
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
        /// <summary>
        /// Finds in reserve all paintings of a certain genre
        /// </summary>
        /// <param name="genre">Genre for serach paintings</param>
        /// <returns>List with paintings of a certain genre</returns>
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
        /// <summary>
        /// Find in reserve all similar painting
        /// </summary>
        /// <param name="paintingForCompare">Painting for compare</param>
        /// <returns>List with similar paintings</returns>
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
