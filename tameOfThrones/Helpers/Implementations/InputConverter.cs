using geektrust.Constants;
using geektrust.Exceptions;
using geektrust.Model;
using System;
using System.Collections.Generic;

namespace geektrust.Helpers
{
    public class InputConverter : IInputConverter
    {
        private readonly IInputReader _inputReader;

        public InputConverter(IInputReader inputReader)
        {
            _inputReader = inputReader;
        }

        public InputRequest Convert()
        {
            var request = new List<Request>();

            try
            {
                var fileString = _inputReader.Read(); ;
                var lines = fileString.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var input = line.Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);
                    if (input.Length < 2)
                    {
                        throw new TameOfThronesException("Less than two words encountered in a line");
                    }
                    else if (Enum.TryParse(input[0], true, out Kingdom kingdom))
                    {
                        var req = new Request(kingdom, input[1]);
                        request.Add(req);
                    }
                    else
                    {
                        throw new TameOfThronesException("Invalid Text in the given file");
                    }
                }

                return new InputRequest(request);
            }
            catch (Exception e)
            {
                throw new TameOfThronesException(e.Message);
            }
        }
    }
}
