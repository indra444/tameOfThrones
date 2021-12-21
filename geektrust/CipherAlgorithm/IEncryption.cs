namespace geektrust.CipherAlgorithm
{
    public interface IEncryption
    {
        bool ValidateCipherText(string emblemName, string cipherText);
    }
}
