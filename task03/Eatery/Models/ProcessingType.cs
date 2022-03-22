namespace Eatery.Models
{
    public class ProcessingType
    {
        public int Price { get; set; }
        public int TimeOfProcessing { get; set; }

        public ProcessingType(int price, int timeOfProcessing)
        {
            Price = price;
            TimeOfProcessing = timeOfProcessing;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not ProcessingType)
                return false;
            else
            {
                var newObj = obj as ProcessingType;
                return Price == newObj.Price && TimeOfProcessing == newObj.TimeOfProcessing;
            }
        }

    }
}
