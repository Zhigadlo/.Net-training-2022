namespace Paintings
{
    /// <summary>
    /// Class for painting. Painting contains name of painting(Name), name of author(Author),
    /// genre of painting(Genre), number of hall place and date of receipt of the painting
    /// by storage
    /// </summary>
    public class Painting
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Genre { get; private set; }
        public int NumberOfHallPlace { get; set; }
        public DateTime DateOfReceipt { get; private set; }

        public Painting(string Name, string Author, string Genre, int NumberOfHallPlace, DateTime DateOfReceipt)
        {
            this.Name = Name;
            this.Author = Author; 
            this.Genre = Genre;
            this.NumberOfHallPlace = NumberOfHallPlace;
            this.DateOfReceipt = DateOfReceipt;
        }
        /// <summary>
        /// Count how many days the painting has been in storage
        /// </summary>
        /// <returns>number of days the painting was in storage</returns>
        public int GetStorageDays()
        {
            DateTime date1 = DateTime.Now.Date;
            DateTime date2 = DateOfReceipt.Date;
            return (date1 - date2).Days;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAuthor: {Author}\n" +
                $"Genre: {Genre}\nNumber of hall place: {NumberOfHallPlace}";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || !(obj is Painting))
                return false;
            else
                return Name == ((Painting)obj).Name 
                    && Author == ((Painting)obj).Author 
                    && Genre == ((Painting)obj).Genre;
            
        }

        public override int GetHashCode()
        {
            return NumberOfHallPlace.GetHashCode() + Name.GetHashCode() +
                Author.GetHashCode() + Genre.GetHashCode() + DateOfReceipt.GetHashCode();
        }
    }
}