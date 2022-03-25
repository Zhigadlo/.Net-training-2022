using Eatery.Food;
using Eatery.IngredientStorage.Interfaces;

namespace Eatery.IngredientStorage
{
    public class StorageForIngredients : IStorage<Ingredient>
    {
        public StorageType Type { get; }
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        
        public StorageForIngredients(StorageType type, Dictionary<Ingredient, int> ingredients)
        {
            Type = type;
            Ingredients = ingredients;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not StorageForIngredients) 
                return false;
            else
            {
                var newObj = obj as StorageForIngredients;
                return Type == newObj.Type && Enumerable.SequenceEqual(Ingredients, newObj.Ingredients);
            }
        }
        public override int GetHashCode()
        {
            return Type.GetHashCode() + Ingredients.GetHashCode();
        }
        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
