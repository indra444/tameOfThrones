using geektrust;
using System;
using Xunit;

namespace geektrust.UnitTests
{
    /// <summary>
    /// This test is not required in my opinion.
    /// Just for the sake of completeness.
    /// </summary>
    public class ProgramTests
    {
        [Fact]
        public void MainTests_UnknownFilePath_NoExceptionRaised()
        {

            Program.Main(new string[1] { "UnknownFile" });

            //No exception raised
        }

        [Fact]
        public void MainTests_NoFilePathProvided_NoExceptionRaised()
        {

            Program.Main(Array.Empty<string>());

            //No exception raised
        }
    }
}
