using Paintings;

namespace StorageOfPaintings
{
    public class Reserve : PaintingStorage
    {
        /// <summary>
        /// Class for reserve is a heir of PaintingStorage class, contains 
        /// an additional field with the storage type 
        /// </summary>
        public TypesOfStorageOfPaintings TypeOfStorage = TypesOfStorageOfPaintings.Reserve;
        public Reserve(List<Hall> halls) : base(halls)
        {
            Halls = halls;
        }
    }
}
