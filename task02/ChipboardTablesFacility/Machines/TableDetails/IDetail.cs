using Facility.Materials;

namespace Facility.TableDetails
{
    public interface IDetail
    {
        public double Square { get; set; }
        public double Height { get; set; }
        public Material Material { get; set; }
    }
}