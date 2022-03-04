namespace Facility.Interfaces
{
    public interface ITable
    {
        public string Name { get; set; }
        public List<IDetail> TableLegs { get; }
        public IDetail TableTop { get; }
        public double Price { get; }
        public double GetPriceForBuild();
    }
}