using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Abonents")]
    public class Abonent : Author, IEntity
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

        public override string ToString()
        {
            return Name + " " + LastName + " " + MidleName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + MidleName.GetHashCode() 
                + Sex.GetHashCode() + BirthDate.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Abonent)
                return false;
            else
            {
                Abonent newObj = obj as Abonent;
                return MidleName == newObj.MidleName && Sex == newObj.Sex && BirthDate == newObj.BirthDate
                    && Name == newObj.Name && LastName == newObj.LastName; 
            }
        }
    }
}
