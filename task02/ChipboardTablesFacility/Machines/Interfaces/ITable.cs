namespace Facility.Interfaces
{
    /// <summary>
    /// Table interface
    /// </summary>
    /// <typeparam name="Top"></typeparam>
    /// <typeparam name="Leg"></typeparam>
    public interface ITable<Top, Leg>
        where Top : IDetail
        where Leg : IDetail
    {
        public string Name { get; set; }
        public double Price { get; }
        public int LegsCount { get; }
        public Top TableTop { get; }
        public Leg TableLeg { get; }

        public double GetChipboardConsumption();
    }
}