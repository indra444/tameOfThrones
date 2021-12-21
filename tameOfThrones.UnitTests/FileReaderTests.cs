using geektrust.Exceptions;
using geektrust.Helpers;
using System;
using Xunit;

namespace geektrust.UnitTests
{
    /// <summary>
    /// This test is infact integration tests.
    /// Added here for sake of simplicity.
    /// </summary>
    [Collection("Integration Tests")]
    public class FileReaderTests
    {
        private IInputReader _fileReader;

        public FileReaderTests()
        {
            string filepath = $"{Environment.CurrentDirectory}\\TestFile\\File.txt";
            _fileReader = new FileReader(filepath);
        }

        [Fact]
        public void ValidFile_ReadFileCorrectly()
        {
            var result = _fileReader.Read();

            var expected = "AIR ROZO";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void InvalidFile_ThrowException()
        {
            _fileReader = new FileReader("InvalidFilePath");

            Assert.Throws<InputFileReadValidationException>(() => _fileReader.Read());
        }
    }
}
