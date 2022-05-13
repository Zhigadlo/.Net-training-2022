using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("AbonentAccountings")]
    public class AbonentAccounting : IEntity
    {
        public int Id { get; set; }
        public Abonent Abonent { get; set; }
        public Book Book { get; set; }
        public DateTime TakeDate { get; set; }
        public bool IsBookReturned { get; set; }
        public string BookCondition { get; set; }

        public AbonentAccounting(Abonent abonent, Book book, DateTime takeDate, bool isBookReturned, string bookCondition)
        {
            Abonent = abonent;
            Book = book;
            TakeDate = takeDate;
            BookCondition = bookCondition;
            IsBookReturned = isBookReturned;
        }

        public override string ToString()
        {
            return Abonent.Name + " " + Abonent.LastName + " " + TakeDate.ToShortDateString();
        }
        public override int GetHashCode()
        {
            return Abonent.GetHashCode() + Book.GetHashCode() 
                + TakeDate.GetHashCode() + BookCondition.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not AbonentAccounting)
                return false;
            else
            {
                AbonentAccounting newObj = obj as AbonentAccounting;
                return Abonent.Equals(newObj.Abonent) && Book.Equals(newObj.Book) 
                    && BookCondition.Equals(newObj.BookCondition);
            }
        }
    }
}
