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

        public override string ToString()
        {
            return "Work place for " + ProcessingType.ToString();
        }
        public override int GetHashCode()
        {
            return MaxCountOfIngredients.GetHashCode() + TimeOfProcessing.GetHashCode() + ProcessingType.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not WorkPlace)
                return false;
            else
            {
                var newObj = obj as WorkPlace;
                return MaxCountOfIngredients == newObj.MaxCountOfIngredients &&
                    TimeOfProcessing == newObj.TimeOfProcessing && ProcessingType == newObj.ProcessingType;
            }
        }
    }
}
