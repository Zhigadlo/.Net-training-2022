using Facility.Materials;
using Facility.TableDetails;

namespace Facility.Machines
{
    public class MachineForChipboard : IMachineForTableLeg, IMachineForTableTop
    {
        private int _priceForSm3 = (int)Material.Chipboard;
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int width, int length)
        {
            if (workPiece.Height < height && workPiece.Width < width && workPiece.Length < length)
                throw new Exception("Work piece is too small for this detail");

            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new TableLeg(width * length, height, workPiece.Material, _priceForSm3);
        }

        public TableTop GetTableTop(WorkPiece workPiece, int height, int width, int length)
        {
            if (workPiece.Height < height && workPiece.Width < width && workPiece.Length < length)
                throw new Exception("Work piece is too small for this detail");

            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new TableTop(width * length, height, workPiece.Material, _priceForSm3);
        }
    }
}
