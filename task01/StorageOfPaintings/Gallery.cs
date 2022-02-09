using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for gallery is a heir of PaintingStorage class, contains 
    /// an additional field with the storage type 
    /// </summary>
    public class Gallery : PaintingStorage
    {
        public TypesOfStorageOfPaintings TypeOfStorage = TypesOfStorageOfPaintings.Gallery;
        public Gallery(List<Hall> halls) : base(halls)
        {
            Halls = halls;
        }
    }
}
