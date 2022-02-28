using Materials;
using TableDetails;

namespace Machines
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
            if (height <= workPiece.Height)
            {
                workPiece.Width -= width;
                workPiece.Length -= length;
            }
            else
            {
                throw new Exception("Work piece is too small for this detail");
            }

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
            if (height <= workPiece.Height)
            {
                workPiece.Width -= radius * 2;
                workPiece.Length -= radius * 2;
            }
            else
            {
                throw new Exception("Work piece is too small for this detail");
            }

            return new TableLeg(radius * radius, height, workPiece.Material, _priceForSm3);
        }
    }
}
