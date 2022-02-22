using Materials;
using TableDetails;

namespace Machines
{
    public class MachineForMetal : IMachineForTableLeg
    {
        private int _priceForSm3 = 6;
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
            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

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
            workPiece.Height -= height;
            workPiece.Width -= radius * 2;
            workPiece.Length -= radius * 2;

            return new TableLeg(radius * radius, height, workPiece.Material, _priceForSm3);
        }
    }
}
