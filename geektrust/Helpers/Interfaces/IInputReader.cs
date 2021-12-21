using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geektrust.Helpers
{
    public interface IInputReader
    {
        /// <summary>
        /// To read from any sources and return string.
        /// </summary>
        /// <returns></returns>
        string Read();
    }
}
