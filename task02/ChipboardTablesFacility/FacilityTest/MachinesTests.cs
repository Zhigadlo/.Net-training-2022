using Xunit;
using Facility.Machines;
using Facility.Materials;

namespace FacilityTest
{
    public class MachinesTests
    {
        [Theory]
        [InlineData("SpecialChipboard", 2,  1.8, 10, 5, 1.7, 3, 2)]
        [InlineData("GeneralPurposeChipboard", 1.5, 1.3, 5, 6, 1, 2, 2.7)]
        [InlineData("SpecialChipboard", 3, 2.9, 7, 4, 2.9, 3.44, 2)]
        public void MachineForOvalDetailsTest(string typeOfMaterial, double maxHeight, double workPieceHeight, double workPieceWidth, double workPieceLength, double topHeight, double smallRadius, double largeRadius)
        {
            MaterialType materialType = Material.Parse(typeOfMaterial);

            WorkPiece workPiece = new WorkPiece(materialType, workPieceHeight, workPieceWidth, workPieceLength);

            MachineForOvalDetails machine = new MachineForOvalDetails(materialType, maxHeight, 100);

            var top = machine.GetOvalTableTop(workPiece, topHeight, smallRadius, largeRadius);

            Assert.Equal(top.Height, topHeight);
            Assert.Equal(top.LargeRadius, largeRadius);
            Assert.Equal(top.SmallRadius, smallRadius);
            Assert.Equal(top.Material.ToString(), typeOfMaterial);
        }

        [Theory]
        [InlineData("SpecialChipboard", 2, 1.8, 10, 5, 1.7, 8, 3)]
        [InlineData("GeneralPurposeChipboard", 1.5, 1.3, 5, 6, 1, 5, 6)]
        [InlineData("SpecialChipboard", 3, 2.9, 7, 4, 2, 5.9, 2.3333)]
        public void MachineForRectangularDetailsTest1(string typeOfMaterial, double maxHeight, double workPieceHeight, double workPieceWidth, double workPieceLength, double detailHeight, double detailWidth, double detailLength)
        {
            MaterialType materialType = Material.Parse(typeOfMaterial);

            WorkPiece workPiece1 = new WorkPiece(materialType, workPieceHeight, workPieceWidth, workPieceLength);

            MachineForRectangularDetails machine = new MachineForRectangularDetails(materialType, maxHeight, 200);

            var top = machine.GetRectangularTableTop(workPiece1, detailHeight, detailWidth, detailLength);

            Assert.Equal(top.Height, detailHeight);
            Assert.Equal(top.Length, detailLength);
            Assert.Equal(top.Width, detailWidth);
            Assert.Equal(top.Material.ToString(), typeOfMaterial);
        }

        [Theory]
        [InlineData("SpecialChipboard", 2, 1.8, 1, 1, 1.73, 0.4, 0.5)]
        [InlineData("GeneralPurposeChipboard", 1.5, 1, 0.9, 0.3, 1.4, 0.6, 0.3)]
        [InlineData("SpecialChipboard", 3, 2, 1, 0.35, 1.1, 0.917, 0.3)]
        public void MachineForRectangularDetailsTest2(string typeOfMaterial, double maxHeight, double workPieceHeight, double workPieceWidth, double workPieceLength, double detailHeight, double detailWidth, double detailLength)
        {
            MaterialType materialType = Material.Parse(typeOfMaterial);

            WorkPiece workPiece1 = new WorkPiece(materialType, workPieceHeight, workPieceWidth, workPieceLength);

            MachineForRectangularDetails machine = new MachineForRectangularDetails(materialType, maxHeight, 200);

            var leg = machine.GetRectangleLeg(workPiece1, detailHeight, detailWidth, detailLength);

            Assert.Equal(leg.Height, detailHeight);
            Assert.Equal(leg.Length, detailLength);
            Assert.Equal(leg.Width, detailWidth);
            Assert.Equal(leg.Material.ToString(), typeOfMaterial);
        }

        [Theory]
        [InlineData("SpecialChipboard", 1, 0.8, 6, 7, 0.7, 3)]
        [InlineData("GeneralPurposeChipboard", 0.5, 0.3, 3, 2.7, 0.24, 1.33)]
        [InlineData("SpecialChipboard", 0.7, 0.4, 4.3, 3.4, 0.345, 1.7)]
        public void MachineForRoundDetailsTest(string typeOfMaterial, double maxHeight, double workPieceHeight, double workPieceWidth, double workPieceLength, double topHeight, double radius)
        {
            MaterialType materialType = Material.Parse(typeOfMaterial);

            WorkPiece workPiece = new WorkPiece(materialType, workPieceHeight, workPieceWidth, workPieceLength);

            MachineForRoundDetails machine = new MachineForRoundDetails(materialType, maxHeight, 100);

            var top = machine.GetRoundTableTop(workPiece, topHeight, radius);

            Assert.Equal(top.Height, topHeight);
            Assert.Equal(top.Radius, radius);
            Assert.Equal(top.Material.ToString(), typeOfMaterial);
        }
    }
}