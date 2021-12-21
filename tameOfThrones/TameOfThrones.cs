using geektrust.CipherAlgorithm;
using geektrust.Constants;
using geektrust.Helpers;
using geektrust.Model;

namespace geektrust
{
    public class TameOfThrones
    {
        private readonly IEncryption _encryptionHelper;
        private readonly IDataHelper _dataHelper;

        public TameOfThrones(IEncryption encryptionHelper, IDataHelper dataHelper)
        {
            _encryptionHelper = encryptionHelper;
            _dataHelper = dataHelper;
        }

        public string GetResult(InputRequest inputRequest)
        {
            string result = Kingdom.SPACE.ToString();

            int count = 0;
            foreach (var request in inputRequest.Requests)
            {
                var emblemName = _dataHelper.GetEmblemForAKingdom(request.Kingdom);
                var isAllies = _encryptionHelper.ValidateCipherText(emblemName.ToString(), request.CipherText);

                if (isAllies)
                {
                    result += " " + request.Kingdom.ToString();
                    count++;
                }
            }

            return count >= 3 ? result : TameOfThroneMessage.None; 
        }
    }
}
