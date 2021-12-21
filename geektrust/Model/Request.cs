using geektrust.Constants;

namespace geektrust.Model
{
    public class Request
    {
        public readonly Kingdom Kingdom;
        public readonly string CipherText;

        public Request(Kingdom kingdom, string ciphertext) => (Kingdom, CipherText) = (kingdom, ciphertext);
    }
}
