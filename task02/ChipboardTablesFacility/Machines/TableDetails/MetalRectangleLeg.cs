﻿using Facility.Interfaces;
using Facility.Materials;

namespace Facility.TableDetails
{
    public class MetalRectangleLeg : IDetail
    {
        public double Square { get; }
        public double Height { get; }
        public double Price { get; }
        public MaterialType Material{ get; }
        public double Width { get; }
        public double Length { get; }

        public MetalRectangleLeg(double height, double width, double length, double Price)
        {
            Material = MaterialType.Metal;
            this.Price = Price;
            Square = width * length;
            Height = height;
            Width = width;
            Length = length;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + Width.GetHashCode() + Length.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not ChipboardRectangleLeg)
                return false;
            else
            {
                ChipboardRectangleLeg newObj = obj as ChipboardRectangleLeg;

                return Square == newObj.Square && Height == newObj.Height && Width == newObj.Width &&
                        Price == newObj.Price && Length == newObj.Length && Material == newObj.Material;
            }
        }
        public override string ToString()
        {
            return $"Metal rectangle leg {Width}x{Length}x{Height}";
        }
    }
}
