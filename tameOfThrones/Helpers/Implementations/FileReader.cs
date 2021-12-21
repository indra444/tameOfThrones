using geektrust.Exceptions;
using System.IO;

namespace geektrust.Helpers
{
    public class FileReader : IInputReader
    {
        private readonly string _filePath;

        public FileReader(string filepath)
        {
            _filePath = filepath;
        }

        public string Read()
        {
            try
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
            catch (IOException e)
            {
                throw new InputFileReadValidationException(e.Message);
            }
        }
    }
}
