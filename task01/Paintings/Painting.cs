namespace Paintings
{
    public class Painting
    {
        public string Name;
        public string Author;
        public int YearOfRealese;
        public string Genre;

        public Painting(string Name, string Author, int YearOfRealese, string Genre)
        {
            this.Name = Name;
            this.Author = Author;
            this.YearOfRealese = YearOfRealese; 
            this.Genre = Genre;
        }
    }
}