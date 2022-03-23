using Eatery.IngredientStorage;
using Eatery.Food.Interfaces;

namespace Eatery.Food
{
    /// <summary>
    /// Ingridient class with sizes, name and storage place
    /// </summary>
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public int Weight { get; set; }
        public int Price { get; set; }
        public StorageType StoragePlace { get; }
        public Ingredient(string name, int weight, int price, StorageType storagePlace)
        {
            Name = name;
            Weight = weight;
            Price = price;
            StoragePlace = storagePlace;
        }
    }
}