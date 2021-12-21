namespace geektrust.CipherAlgorithm
{
    public interface IEncryption
    {
        /// <summary>
        /// To validate a cipher based on some algorith.
        /// </summary>
        /// <param name="emblemName"></param>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        bool ValidateCipherText(string emblemName, string cipherText);
    }
}
