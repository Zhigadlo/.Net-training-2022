namespace Eatery.Food
{
    public class Dish
    {
        /// <summary>
        /// Class dish is class for dishes and drinks
        /// </summary>
        public string Name { get; }
        public int Price { get; }
        public Dictionary<ProcessedIngredient, int> ProcessedIngredients { get; }
        public Dish(string name, Dictionary<ProcessedIngredient, int> processedIngredients)
        {
            Name = name;
            ProcessedIngredients = processedIngredients;
            foreach (var ingredient in processedIngredients)
                Price += ingredient.Key.Price * ingredient.Value;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Dish)
                return false;
            else
            {
                var newObj = obj as Dish;
                return newObj.Name == Name && newObj.Price == Price && Enumerable.SequenceEqual(ProcessedIngredients, newObj.ProcessedIngredients);
            }
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode() + ProcessedIngredients.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
