using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<IngredientProcessing> ListOfProcessing { get; }
        public int Price { get; }
        public Recipe(string name, params IngredientProcessing[] listOfProcessing)
        {
            Name = name;
            ListOfProcessing = listOfProcessing.ToList();
            foreach (var item in ListOfProcessing)
            {
                Price += item.IngredientForProcessing.Price;
                foreach (var process in item.ProcessingTypes)
                {
                    Price += process.Price;
                }
            }
        }

        public List<Ingredient> GetIngridients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var item in ListOfProcessing)
                ingredients.Add(item.IngredientForProcessing);

            return ingredients;
        }

    }
}
