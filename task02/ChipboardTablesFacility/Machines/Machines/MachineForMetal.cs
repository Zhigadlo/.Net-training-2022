﻿using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public class MachineForMetal : IMachineForTableLeg
    {
        private int _priceForSm3 = (int)Material.Metal;
        /// <summary>
        /// Method for making a metal leg for table
        /// </summary>
        /// <param name="workPiece"></param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <returns>A table leg</returns>
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int width, int length)
        {
            workPiece.Width -= width;
            workPiece.Length -= length;
            workPiece.Height -= height;

            if (workPiece.Height < height && workPiece.Width < width && workPiece.Length < length)
                throw new Exception("Work piece is too small for this detail");

            return new TableLeg(width * length, height, workPiece.Material, _priceForSm3);
        }

        /// <summary>
        /// Method for making a metal round leg for table
        /// </summary>
        /// <param name="workPiece"></param>
        /// <param name="height"></param>
        /// <param name="radius"></param>
        /// <returns>A table leg</returns>
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int radius)
        {
            var diagonal = 2 * radius;

            if (workPiece.Height < height && workPiece.Width < diagonal && workPiece.Length < diagonal)
                throw new Exception("Work piece is too small for this detail");

            workPiece.Width -= diagonal;
            workPiece.Length -= diagonal;
            workPiece.Height -= height;

            return new TableLeg(Math.PI * radius * radius, height, workPiece.Material, _priceForSm3);
        }
    }
}