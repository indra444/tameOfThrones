using geektrust.Constants;
using geektrust.Helpers;
using Xunit;

namespace geektrust.UnitTests
{
    public class DataHelperTests
    {
        private readonly DataHelper _dataHalper;

        public DataHelperTests()
        {
            _dataHalper = new DataHelper();
        }

        [Fact]
        public void GetEmblemForAKingdom_ReturnCorrectValue()
        {
            var emblem = _dataHalper.GetEmblemForAKingdom(Kingdom.ICE);

            Assert.Equal(Emblem.Mammoth, emblem);
        }
    }
}
