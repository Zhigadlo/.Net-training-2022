using Eatery.Food;

namespace Eatery.FoodProcessing
{
    public class Processing
    {
        public ProcessingType Type { get; }
        public Ingredient Ingredient { get; }
        public int CountOfIngredients { get; }

        public Processing(ProcessingType type, Ingredient ingredient,int countOfIngredients)
        {
            CountOfIngredients = countOfIngredients;
            Type = type;
            Ingredient = ingredient;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Processing)
                return false;
            else
            {
                var newObj = obj as Processing;
                return CountOfIngredients == newObj.CountOfIngredients && Type == newObj.Type
                    && Ingredient.Equals(newObj.Ingredient);
            }
        }



    }
}
