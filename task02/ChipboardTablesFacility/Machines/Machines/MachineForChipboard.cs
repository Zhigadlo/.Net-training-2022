using Facility.Interfaces;
using Facility.Materials;

namespace Facility.Machines
{
    public class MachineForChipboard : IMachineForTableLeg, IMachineForTableTop
    {
        private int _priceForSm3 = (int)Materials.MaterialType.Chipboard;
        public ITableLeg GetTableLeg(WorkPiece workPiece, double height, double width, double length)
        {
            if (workPiece.Height < height && workPiece.Width < width && workPiece.Length < length)
                throw new Exception("Work piece is too small for this detail");

            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new TableLeg(width * length, height, workPiece.Material, _priceForSm3);
        }

        public ITableTop GetTableTop(WorkPiece workPiece, double height, double width, double length)
        {
            if (workPiece.Height < height && workPiece.Width < width && workPiece.Length < length)
                throw new Exception("Work piece is too small for this detail");

            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new ITableTop(width * length, height, workPiece.Material, _priceForSm3);
        }
    }
}
