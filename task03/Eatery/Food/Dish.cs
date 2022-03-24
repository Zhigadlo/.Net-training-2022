namespace Eatery.Food
{
    public class Dish
    {
        public string Name { get; }
        public int Price { get;}
        public Recipe DishRecipe { get; }
        public Dish(Recipe dishRecipe)
        {
            DishRecipe = dishRecipe;
            Price = dishRecipe.Price;
            Name = dishRecipe.Name;
        }

        public List<Ingredient> GetIngredients() => DishRecipe.GetIngridients();
    }
}
