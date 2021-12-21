using geektrust.Constants;

namespace geektrust.Helpers
{
    public interface IDataHelper
    {
        /// <summary>
        /// Get corresponding emblem for a kingdom.
        /// </summary>
        /// <param name="kingdom"></param>
        /// <returns></returns>
        Emblem GetEmblemForAKingdom(Kingdom kingdom);
    }
}