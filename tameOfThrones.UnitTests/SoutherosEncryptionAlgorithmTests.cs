using geektrust.CipherAlgorithm;
using Xunit;

namespace geektrust.UnitTests
{
    public class SoutherosEncryptionAlgorithmTests
    {
        private readonly IEncryption _southerosEncryptionAlgorithm;

        public SoutherosEncryptionAlgorithmTests()
        {
            _southerosEncryptionAlgorithm = new SoutherosEncryptionAlgorithm();
        }

        [Theory]
        [InlineData("Owl", "rozo")]
        [InlineData("Panda", "FAIJWJSOOFAMAU")]
        [InlineData("Mammoth", "STHSTSTVSASOS")]
        [InlineData("Panda", "FDIXXSOKKOFBBMU")]
        [InlineData("Mammoth", "MOMAMVTMTMHTM")]
        [InlineData("Dragon", "AJXGAMUTA")]
        [InlineData("Panda", "OFBBMUFDICCSO")]
        [InlineData("Mammoth", "VTBTBHTBBBOBAB")]

        public void ValidateCipherText_HappyPath(string emblemName, string cipherText)
        {
            var result = _southerosEncryptionAlgorithm.ValidateCipherText(emblemName, cipherText);

            Assert.True(result);
        }

        [Theory]

        [InlineData("Mammothasaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaasssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss", "zxdcvxcvxcvcbvcvbcvbcvbcvbzxccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccvbcvbcvbcvSTHSTSTVSASOS")]
        [InlineData("Octopus", "SUMMER IS COMING")]
        [InlineData("Owl", "OWLAOWLBOWLC")]
        public void ValidateCipherText_NegativePath(string emblemName, string cipherText)
        {
            var result = _southerosEncryptionAlgorithm.ValidateCipherText(emblemName, cipherText);

            Assert.False(result);
        }
    }
}
