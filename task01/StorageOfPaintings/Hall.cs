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

        public override string ToString()
        {
            return $"Gallery hall number {Number} with {Paintings.Count} paintings";
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode() + Paintings.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            bool IsEqual = true;
            foreach(Painting painting in Paintings)
            {
                if(!painting.Equals(obj))
                {
                    IsEqual = false;
                    break;
                }
            }

            if (obj == null || !(obj is Hall))
                return false;
            else
                return IsEqual;
        }

    }
}
