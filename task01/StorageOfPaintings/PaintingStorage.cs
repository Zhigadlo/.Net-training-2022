using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Abstract class for the storage of paintings. Contains a type
    /// of storage of paintings and methods for searching for paintings
    /// </summary>
    public abstract class PaintingStorage
    {
        public TypesOfStorageOfPaintings TypesOfStorage;

        /// <summary>
        /// Finds all paintings of a certain author  
        /// </summary>
        /// <param name="author">name of author of painting</param>
        /// <returns>List with paintings of a certain author</returns>
        public abstract List<Painting> GetPaintingsByAuthor(string author);
        /// <summary>
        /// Finds all paintings with a certain name
        /// </summary>
        /// <param name="name">Name of painting</param>
        /// <returns>List paintings with a certain name</returns>
        public abstract List<Painting> GetPaintingsByName(string name);
        /// <summary>
        /// Finds all paintings of a certain genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns>List with paintings of a certain genre</returns>
        public abstract List<Painting> GetPaintingsByGenre(string genre);
        /// <summary>
        /// Find all similar painting
        /// </summary>
        /// <param name="paintingForCompare">Painting for compare</param>
        /// <returns>List with similar paintings</returns>
        public abstract List<Painting> GetSimilarPaintings(Painting paintingForCompare);
    }
}