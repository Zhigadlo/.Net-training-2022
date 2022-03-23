using Eatery.IngredientStorage.Interfaces;
using Eatery.Food;

namespace Eatery.IngredientStorage
{
    public class StorageForProcessedIngredients : IStorage<ProcessedIngredient>
    {
        public List<ProcessedIngredient> Ingredients { get; }

        public StorageForProcessedIngredients()
        {
            Ingredients = new List<ProcessedIngredient>();
        }
    }
}
