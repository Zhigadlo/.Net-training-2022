using Paintings;

namespace StorageOfPaintings
{
    /// <summary>
    /// Class for storage hall, contains number and list of paintings in it
    /// </summary>
    public class Hall
    {
        public int Number { get; private set; }
        public List<Painting> Paintings { get; set; }

        public Hall(int number, List<Painting> paintings)
        {
            Number = number;
            Paintings = paintings;
        }

    }
}
