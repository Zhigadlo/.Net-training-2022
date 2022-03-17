using Facility.Tables;
using Facility.Interfaces;
using Facility.TableDetails;
using Facility.Materials;
using Facility.Machines;
using System;


namespace Facility
{
    public class FacilityMethods
    {
        public static ITable<IDetail, IDetail> FindTableByChipboardComsuption(double chipboardComsuption, List<ITable<IDetail, IDetail>> tables)
        {
            foreach (var table in tables)
            {
                if (chipboardComsuption == table.GetChipboardConsumption())
                {
                    return table;
                }
            }

            throw new Exception("There is no table with this consuption of chipboard");
        }

        public static WorkPiece FindWorkPieceWithMinLossOfMaterial(IDetail detail, List<WorkPiece> workPieces)
        {
            WorkPiece requiredWorkPiece = workPieces[0];

            double heightLoss = detail.Height - workPieces[0].Height;
            double squareLoss = detail.Square - workPieces[0].Square;

            foreach (WorkPiece workPiece in workPieces)
            {
                if (detail.Height - workPiece.Height <= heightLoss && detail.Square - workPiece.Length * workPiece.Width <= squareLoss)
                {
                    heightLoss = detail.Height - workPiece.Height;
                    squareLoss = detail.Square - workPiece.Width * workPiece.Length;
                    requiredWorkPiece = workPiece;
                }
            }
            workPieces.Remove(requiredWorkPiece);
            return requiredWorkPiece;
        }

    }
}
