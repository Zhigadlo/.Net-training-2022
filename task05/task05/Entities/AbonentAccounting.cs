using ORM;

namespace Entities
{
    [DataTableName("AbonentAccountings")]
    public class AbonentAccounting : IEntity
    {
        public Abonent Abonent { get; set; }
        public Book Book { get; set; }
        public DateTime TakeDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BookCondition { get; set; }

        public AbonentAccounting(Abonent abonent, Book book, DateTime takeDate, DateTime returnDate, string bookCondition)
        {
            Abonent = abonent;
            Book = book;
            TakeDate = takeDate;
            ReturnDate = returnDate;
            BookCondition = bookCondition;
        }
    }
}
