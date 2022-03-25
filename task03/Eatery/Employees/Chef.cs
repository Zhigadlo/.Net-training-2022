using Eatery.Food;
using Eatery.FoodProcessing;

namespace Eatery.Employees
{
    public class Chef : Cook
    {
        public Chef(string name, string surname, WorkPlace workPlace) : base(name, surname, workPlace)
        {
        }

        public Recipe MakeNewRecipe(string name, params Processing[] processings) => new(name, processings);

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Chef)
                return false;
            else
            {
                var newObj = obj as Chef;
                return Name == newObj.Name && Surname == newObj.Surname && WorkPlace.Equals(newObj.WorkPlace);
            }
        }
    }
}
