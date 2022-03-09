namespace Facility.Interfaces
{
    public interface ITable <Top, Leg> 
        where Top : IDetail
        where Leg : IDetail
    {
        public string Name { get; set; }
        public double Price { get; }
        public int LegsCount { get; }
        public Top TableTop { get; }
        public List<Leg> TableLegs { get; }

        public double GetChipboardConsumption();
    }
}