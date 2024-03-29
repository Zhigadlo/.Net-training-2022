﻿using Facility.Interfaces;
using Facility.Materials;
using System.Text.Json.Serialization;

namespace Facility.TableDetails
{
    public class RectangleChipboardLeg : IDetail
    {
        [JsonIgnore]
        public double Square { get; }
        public double Height { get; }
        [JsonIgnore]
        public double Price { get; }
        public MaterialType Material { get; }
        public double Width { get; }
        public double Length { get; }
        public double PriceForProcessing { get; }

        public RectangleChipboardLeg(MaterialType material, double height, double width, double length, double priceForProcessing)
        {
            Material = material;
            PriceForProcessing = priceForProcessing;
            Height = height;
            Width = width;
            Length = length;
            Square = width * length;
            Price = Square * Height * (int)material + priceForProcessing;
        }

        public override int GetHashCode() => Square.GetHashCode() + Height.GetHashCode() + Price.GetHashCode() + Material.GetHashCode() + Width.GetHashCode() + Length.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj == null || obj is not RectangleChipboardLeg)
                return false;
            else
            {
                RectangleChipboardLeg newObj = obj as RectangleChipboardLeg;

                return Square == newObj.Square && Height == newObj.Height && Width == newObj.Width &&
                        Price == newObj.Price && Length == newObj.Length && Material == newObj.Material &&
                        PriceForProcessing == newObj.PriceForProcessing;
            }
        }
        public override string ToString()
        {
            return $"Chipboard rectangle leg {Width}x{Length}x{Height}";
        }
    }
}
