namespace Eatery.Food
{
    public class Dish
    {
        public string Name { get; }
        public int Price { get;}
        public List<Ingredient> Ingridients { get; }
        public Recipe DishRecipe { get; }
        public Dish(Recipe dishRecipe)
        {
            DishRecipe = dishRecipe;
            Ingridients = dishRecipe.GetIngridients();
            Price = dishRecipe.Price;
            Name = dishRecipe.Name;
        }
    }
}
