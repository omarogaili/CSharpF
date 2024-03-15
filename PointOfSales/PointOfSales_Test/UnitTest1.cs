using PointOfSales;
using Xunit;
namespace PointOfSales_Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData ("12345", "$7.25")]
        [InlineData ("23456", "$12.50")]
        [InlineData ("99999", "Error: vara existerar ej")]

        //Gavin_When_than
        public void GetTheBarCodeScaned_Contians_ASting(string barCode, string expectedResult)
        {
            //arrange
            ScaningABar sut = new ScaningABar(barCode);
            //act 
            var result= sut.GetTheBarCodeScaned();
            //Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}