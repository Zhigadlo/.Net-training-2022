namespace Paintings
{
    /// <summary>
    /// Class for painting. Painting contains name of painting(Name), name of author(Author),
    /// year of realease, genre of painting(Genre), number of hall place and date of receipt of the painting
    /// by storage
    /// </summary>
    public class Painting
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public int YearOfRealese { get; private set; }
        public string Genre { get; private set; }
        public int NumberOfHallPlace { get; set; }
        public DateTime DateOfReceipt { get; private set; }

        public Painting(string Name, string Author, int YearOfRealese, string Genre, int NumberOfHallPlace, DateTime DateOfReceipt)
        {
            this.Name = Name;
            this.Author = Author;
            this.YearOfRealese = YearOfRealese; 
            this.Genre = Genre;
            this.NumberOfHallPlace = NumberOfHallPlace;
            this.DateOfReceipt = DateOfReceipt;
        }
        /// <summary>
        /// Count how long the painting has been in storage
        /// </summary>
        /// <returns>the time the painting was in storage</returns>
        private DateTime GetStorageTime()
        {
            return new DateTime(DateTime.Today.Month - DateOfReceipt.Month,DateTime.Today.Day - DateOfReceipt.Day, DateTime.Today.Year - DateOfReceipt.Year);
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
            return YearOfRealese.GetHashCode() + NumberOfHallPlace.GetHashCode() + Name.GetHashCode() +
                Author.GetHashCode() + Genre.GetHashCode() + DateOfReceipt.GetHashCode();
        }
    }
}