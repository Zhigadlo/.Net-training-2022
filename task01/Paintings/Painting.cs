namespace Paintings
{
    /// <summary>
    /// Class for painting. Painting contains name of painting(Name), name of author(Author),
    /// year of realease, genre of painting(Genre) and number of hall place
    /// </summary>
    public class Painting
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearOfRealese { get; private set; }
        public string Genre { get; private set; }
        public int NumberOfHallPlace { get; set; }

        public Painting(string Name, string Author, int YearOfRealese, string Genre, int NumberOfHallPlace)
        {
            this.Name = Name;
            this.Author = Author;
            this.YearOfRealese = YearOfRealese; 
            this.Genre = Genre;
            this.NumberOfHallPlace = NumberOfHallPlace;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAuthor: {Author}\nYear of realese: {YearOfRealese}\n" +
                $"Genre: {Genre}\nNumber of hall place: {NumberOfHallPlace}";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || !(obj is Painting))
                return false;
            else
                return Name == ((Painting)obj).Name 
                    && Author == ((Painting)obj).Author 
                    && YearOfRealese == ((Painting)obj).YearOfRealese 
                    && Genre == ((Painting)obj).Genre;
            
        }

        public override int GetHashCode()
        {
            return YearOfRealese + NumberOfHallPlace;
        }
    }
}