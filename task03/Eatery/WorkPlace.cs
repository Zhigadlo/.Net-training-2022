using Eatery.Employees;
using Eatery.FoodProcessing;

namespace Eatery
{
    public class WorkPlace
    {
        public int MaxCountOfIngredients { get; }
        public int TimeOfProcessing { get; }
        public Cook Cook { get; }
        public ProcessingType ProcessingType { get; }

        public WorkPlace(int maxCountOfIngredients, int timeOfProcessing, Cook cook, ProcessingType processingType)
        {
            TimeOfProcessing = timeOfProcessing;
            Cook = cook;
            MaxCountOfIngredients = maxCountOfIngredients;
            ProcessingType = processingType;
        }
    }
}
