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
    }
}
