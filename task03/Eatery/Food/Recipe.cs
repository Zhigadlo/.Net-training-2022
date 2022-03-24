using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Processing> ListOfProcessing { get; }
        public int Price { get; }
        public Recipe(string name, params Processing[] listOfProcessing)
        {
            Name = name;
            ListOfProcessing = listOfProcessing.ToList();
        }

        public List<Ingredient> GetIngridients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in ListOfProcessing)
                ingredients.Add(item.Ingredient);

            return ingredients;
        }

    }
}
