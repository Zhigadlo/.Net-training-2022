using Eatery.IngredientStorage;
using Eatery.Food.Interfaces;
using Eatery.FoodProcessing;

namespace Eatery.Food
{
    /// <summary>
    /// Ingridient class with sizes, name and storage place
    /// </summary>
    public class Ingredient : IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public StorageType StoragePlace { get; }
        public List<ProcessingType> PossibleTypesOfProcessing { get; }
        public Ingredient(string name, int price, StorageType storagePlace, params ProcessingType[] possibleTypesOfProcessing)
        {
            Name = name;
            Price = price;
            StoragePlace = storagePlace;
            PossibleTypesOfProcessing = possibleTypesOfProcessing.ToList();
        }
    }
}