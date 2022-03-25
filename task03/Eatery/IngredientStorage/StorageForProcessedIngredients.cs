using Eatery.IngredientStorage.Interfaces;
using Eatery.Food;

namespace Eatery.IngredientStorage
{
    public class StorageForProcessedIngredients : IStorage<ProcessedIngredient>
    {
        public Dictionary<ProcessedIngredient, int>  Ingredients { get; }

        public StorageForProcessedIngredients()
        {
            Ingredients = new Dictionary<ProcessedIngredient, int>();
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj is not StorageForProcessedIngredients)
                return false;
            else
            {
                var newObj = obj as StorageForProcessedIngredients;
                return Enumerable.SequenceEqual(Ingredients, newObj.Ingredients);
            }
        }
        public override int GetHashCode()
        {
            return Ingredients.GetHashCode();
        }
        public override string ToString()
        {
            return "Storage for processed ingredients";
        }
    }
}
