using geektrust.Model;

namespace geektrust.Helpers
{
    public interface IInputConverter
    {
        /// <summary>
        /// To convert any request to InputRequest.
        /// </summary>
        /// <returns></returns>
        InputRequest Convert();
    }
}
