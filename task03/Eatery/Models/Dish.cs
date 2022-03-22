namespace Eatery.Models
{
    public class Dish
    {
        public int Price { get;}
        public List<Ingridient> Ingridients { get; }
        public Recipe DishRecipe { get; }
        public Dish(Recipe recipe)
        {
            DishRecipe = recipe;
            Ingridients = recipe.GetIngridients();
            foreach (var item in recipe.ListOfProcessing)
            {
                Price += item.IngridientForProcessing.Price;
                foreach(var process in item.ProcessingTypes)
                {
                    Price *= process.Price;
                }
            }
        }


    }
}
