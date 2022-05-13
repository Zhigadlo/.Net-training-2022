using ORM;
using ORM.Interfaces;

namespace Entities
{
    [DataTableName("Abonents")]
    public class Abonent : Author, IEntity
    {
        public string MiddleName { get; set; }
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public Abonent(string name, string lastName, string middleName, bool isMale, DateTime birthDate) : base(name, lastName)
        {
            MiddleName = middleName;
            IsMale = isMale;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name + " " + LastName + " " + MiddleName;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + MiddleName.GetHashCode() 
                + IsMale.GetHashCode() + BirthDate.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Abonent)
                return false;
            else
            {
                Abonent newObj = obj as Abonent;
                return MiddleName == newObj.MiddleName && IsMale == newObj.IsMale && BirthDate == newObj.BirthDate
                    && Name == newObj.Name && LastName == newObj.LastName; 
            }
        }
    }
}
