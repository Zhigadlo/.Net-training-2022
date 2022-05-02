namespace Entities
{
    public class Abonent : Human
    {
        public string MidleName { get; set; }
        public int Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Abonent(string name, string lastName, string midleName, int sex, DateTime birthDate) : base(name, lastName)
        {
            MidleName = midleName;
            Sex = sex;
            BirthDate = birthDate;
        }
    }
}
