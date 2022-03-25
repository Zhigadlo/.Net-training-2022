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

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not Dish) 
                return false;
            else
            {
                var newObj = obj as Dish;
                return newObj.Name == Name && newObj.Price == Price && newObj.DishRecipe.Equals(DishRecipe);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode() + DishRecipe.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
