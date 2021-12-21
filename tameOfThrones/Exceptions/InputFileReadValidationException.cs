using System;

namespace geektrust.Exceptions
{
    public class InputFileReadValidationException : Exception
    {
        public InputFileReadValidationException(string message) : base($"InputFileReadException: {message}")
        {
        }
    }
}
