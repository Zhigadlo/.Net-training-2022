using Paintings;

namespace StorageOfPaintings
{
    public interface IPaintingStorage
    {
        public List<Painting> Paintings { get; set; }
        
    }

    public class Gallery : IPaintingStorage
    {
        public List<Painting> Paintings { get; set; }
        public TypesOfStorageOfPaintings TypeOfStorage { get; private set; }
        public Gallery(List<Painting> paintings)
        {
            Paintings = paintings;
            TypeOfStorage = TypesOfStorageOfPaintings.Gallery;
        }
    }

    public class Reserve : IPaintingStorage
    {
        public List<Painting> Paintings { get; set; }
        public TypesOfStorageOfPaintings TypeOfStorage { get; private set; }
        public Reserve(List<Painting> paintings)
        {
            Paintings = paintings;
            TypeOfStorage = TypesOfStorageOfPaintings.Reserve;
        }
    }
}