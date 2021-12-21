using geektrust.Constants;

namespace geektrust.Helpers
{
    public class DataHelper : IDataHelper
    {
        public Emblem GetEmblemForAKingdom(Kingdom kingdom) => (Emblem)((int)kingdom);
    }
}
