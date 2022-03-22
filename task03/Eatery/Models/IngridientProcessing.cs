namespace Eatery.Models
{
    public class IngridientProcessing
    {
        public List<ProcessingType> ProcessingTypes { get; set; }
        public Ingridient IngridientForProcessing { get; set; }

        public IngridientProcessing(Ingridient ingridient, params ProcessingType[] processingTypes)
        {
            IngridientForProcessing = ingridient;   
            ProcessingTypes = processingTypes.ToList();
        }
    }
}
