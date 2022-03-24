using Eatery.FoodProcessing;

namespace Eatery
{
    public class WorkPlace
    {
        public int MaxCountOfIngredients { get; }
        public int TimeOfProcessing { get; }
        public ProcessingType ProcessingType { get; }

        public WorkPlace(int maxCountOfIngredients, int timeOfProcessing, ProcessingType processingType)
        {
            TimeOfProcessing = timeOfProcessing;
            MaxCountOfIngredients = maxCountOfIngredients;
            ProcessingType = processingType;
        }
    }
}
