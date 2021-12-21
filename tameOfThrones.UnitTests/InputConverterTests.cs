using geektrust.Constants;
using geektrust.Exceptions;
using geektrust.Helpers;
using Moq;
using System.IO;
using System.Linq;
using Xunit;

namespace geektrust.UnitTests
{
    public class InputConverterTests
    {
        private readonly Mock<IInputReader> _mockInputReader;
        private readonly IInputConverter _target;

        public InputConverterTests()
        {
            _mockInputReader = new Mock<IInputReader>();
            _target = new InputConverter(_mockInputReader.Object);
        }

        [Fact]
        public void ReadUserInput_HappyPath()
        {
            _mockInputReader.Setup(x => x.Read()).Returns("AIR Hello World\r\nSPACE Goodevening");

            var result =_target.Convert();

            Assert.NotNull(result);
            Assert.Equal(2, result.Requests.Count);
            Assert.Equal(Kingdom.AIR, result.Requests.First().Kingdom);
            Assert.Equal("Hello World", result.Requests.First().CipherText);
            Assert.Equal(Kingdom.SPACE, result.Requests.Last().Kingdom);
            Assert.Equal("Goodevening", result.Requests.Last().CipherText);
        }

        [Fact]
        public void ReadUserInput_OnlyOneWordInLine_ExceptionRaised()
        {
            _mockInputReader.Setup(x => x.Read()).Returns("AIR Hello World\r\nSPACEGoodevening");

            Assert.Throws<TameOfThronesException>(() => _target.Convert());
        }

        [Fact]
        public void ReadUserInput_InvalidText_ExceptionRaised()
        {
            _mockInputReader.Setup(x => x.Read()).Returns("AIR Hello World\r\nUniverse Goodevening");

            Assert.Throws<TameOfThronesException>(() => _target.Convert());
        }

        [Fact]
        public void ReadUserInput_GeneralIssue_ExceptionRaised()
        {
            _mockInputReader.Setup(x => x.Read()).Throws(new System.Exception());

            Assert.Throws<TameOfThronesException>(() => _target.Convert());
        }
    }
}
