using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class MetalRoundLeg : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material { get; }
        public double Radius { get; }

        public MetalRoundLeg(double height, double radius, double price)
        {
            Square = radius * radius * Math.PI;
            Height = height;
            Material = MaterialType.Metal;
            Radius = radius;
            Price = price;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + Radius.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not MetalRoundLeg)
                return false;
            else
            {
                MetalRoundLeg newObj = obj as MetalRoundLeg;

                return Square == newObj.Square && Height == newObj.Height &&
                        Price == newObj.Price && Radius == newObj.Radius && Material == newObj.Material;
            }
        }
        public override string ToString()
        {
            return $"Metal round leg {Radius}x{Height}";
        }
    }
}
