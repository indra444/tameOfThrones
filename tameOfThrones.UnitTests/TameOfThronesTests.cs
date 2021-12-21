using geektrust.CipherAlgorithm;
using geektrust.Constants;
using geektrust.Helpers;
using geektrust.Model;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace geektrust.UnitTests
{
    public class TameOfThronesTests
    {
        private readonly TameOfThrones _target;
        private readonly Mock<IEncryption> _mockEncryptionHelper;
        private readonly Mock<IDataHelper> _mockDataHelper;

        public TameOfThronesTests()
        {
            _mockDataHelper = new Mock<IDataHelper>();
            _mockEncryptionHelper = new Mock<IEncryption>();

            _target = new TameOfThrones(_mockEncryptionHelper.Object, _mockDataHelper.Object);
        }

        [Fact]
        public void GetResult_HappyPath()
        {
            //Arange
            InputRequest request = new InputRequest(
                new List<Request> 
                { 
                    new Request(Kingdom.AIR, "ROZO"),
                    new Request(Kingdom.LAND, "FAIJWJSOOFAMAU"),
                    new Request(Kingdom.ICE, "FAIJWJSOOFAMAU"),
                });

            _mockEncryptionHelper.Setup(x => x.ValidateCipherText(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _mockDataHelper.Setup(x => x.GetEmblemForAKingdom(It.IsAny<Kingdom>())).Returns<Kingdom>(x => (Emblem)((int)x));

            //Act
            var results = _target.GetResult(request);

            //Assert
            Assert.Equal("SPACE AIR LAND ICE", results);
        }

        [Fact]
        public void GetResult_NegativePath()
        {
            //Arange
            InputRequest request = new InputRequest(
                new List<Request>
                {
                    new Request(Kingdom.AIR, "ROZO"),
                    new Request(Kingdom.LAND, "xcvxcv"),
                    new Request(Kingdom.ICE, "xcvxcv"),
                });

            _mockEncryptionHelper.Setup(x => x.ValidateCipherText(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            _mockDataHelper.Setup(x => x.GetEmblemForAKingdom(It.IsAny<Kingdom>())).Returns<Kingdom>(x => (Emblem)((int)x));

            //Act
            var results = _target.GetResult(request);

            //Assert
            Assert.Equal(TameOfThroneMessage.None, results);
        }
    }
}
