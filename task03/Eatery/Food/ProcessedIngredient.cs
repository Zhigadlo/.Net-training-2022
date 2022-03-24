using Eatery.Food.Interfaces;
using Eatery.IngredientStorage;
using Eatery.FoodProcessing;

namespace Eatery.Food
{
    public class ProcessedIngredient : IIngredient
    {
        public string Name { get; }
        public int Price { get; set; }
        public StorageType StoragePlace { get; }
        public Processing TypeOfProcessing { get; }

        public ProcessedIngredient(string name, int price, Processing typeOfProcessing)
        {
            Name = name;
            Price = price;
            TypeOfProcessing = typeOfProcessing;
            StoragePlace = StorageType.Warehouse;
        }

        
    }
}
