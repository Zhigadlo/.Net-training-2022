using Eatery.Food;

namespace Eatery.FoodProcessing
{
    public class IngredientProcessing
    {
        public List<ProcessingType> ProcessingTypes { get; set; }
        public Ingredient IngredientForProcessing { get; set; }
        public int MaxCountOfIngredients { get; }
        public int Time { get; }
        public IngredientProcessing(int maxCountOfIngredients, Ingredient ingredient, int time, List<ProcessingType> processingTypes)
        {
            Time = time;
            MaxCountOfIngredients = maxCountOfIngredients;
            IngredientForProcessing = ingredient;
            ProcessingTypes = processingTypes;
        }
    }
}
