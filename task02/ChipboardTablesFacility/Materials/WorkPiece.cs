﻿namespace Materials
{
    public class WorkPiece
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public int PriceForSm3 { get; private set; }
        public Material Material { get; private set; }

        public WorkPiece(int width, int height, int length, Material material)
        {
            Width = width;
            Height = height;
            Length = length;
            Material = material;
            PriceForSm3 = (int)material;
        }
    }
}
