using Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDetails;

namespace Machines
{
    public class MachineForChipboard : IMachineForTableLeg, IMachineForTableTop
    {
        private int _priceForSm3 = (int)Material.Chipboard;
        public TableLeg GetTableLeg(WorkPiece workPiece, int height, int width, int length)
        {
            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new TableLeg(width * length, height, workPiece.Material, _priceForSm3);
        }

        public TableTop GetTableTop(WorkPiece workPiece, int height, int width, int length)
        {
            workPiece.Height -= height;
            workPiece.Width -= width;
            workPiece.Length -= length;

            return new TableTop(width * length, height, workPiece.Material, _priceForSm3);
        }
    }
}
