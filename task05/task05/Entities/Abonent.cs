using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Abonents")]
    public class Abonent : Author, IEntity
    {
        public string MiddleName { get; set; }
        public int Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Abonent(string name, string lastName, string middleName, int sex, DateTime birthDate) : base(name, lastName)
        {
            MiddleName = middleName;
            Sex = sex;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name + " " + LastName + " " + MiddleName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + MiddleName.GetHashCode() 
                + Sex.GetHashCode() + BirthDate.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Abonent)
                return false;
            else
            {
                Abonent newObj = obj as Abonent;
                return MiddleName == newObj.MiddleName && Sex == newObj.Sex && BirthDate == newObj.BirthDate
                    && Name == newObj.Name && LastName == newObj.LastName; 
            }
        }
    }
}
