using Eatery.Food;
using Eatery.FoodProcessing;

namespace Eatery.Employees
{
    /// <summary>
    /// Chef is modification of class cook. Chef can process ingredients and create new recipes
    /// </summary>
    public class Chef : Cook
    {
        public Chef(string name, string surname, WorkPlace workPlace) : base(name, surname, workPlace)
        {
        }

        public Recipe CreateNewRecipe(string name, params Processing[] processings) => new(name, processings);

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Chef)
                return false;
            else
            {
                var newObj = obj as Chef;
                return Name == newObj.Name && Surname == newObj.Surname && WorkPlace.Equals(newObj.WorkPlace);
            }
        }
    }
}
