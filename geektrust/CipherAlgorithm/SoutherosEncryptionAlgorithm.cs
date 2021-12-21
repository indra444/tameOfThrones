using System.Linq;

namespace geektrust.CipherAlgorithm
{
    public class SoutherosEncryptionAlgorithm : IEncryption
    {
        private const int SmallLetterAsciiStart = 'a';
        private const int SmallLetterAsciiEnd = 'z';
        private const int CapitalLetterAsciiStart = 'A';
        private const int CapitalLetterAsciiEnd = 'Z';
        private const int TotalAlphabets = 26;

        public bool ValidateCipherText(string emblemName, string cipherText)
        {
            var decipheredText = GetDecipheredText(cipherText, emblemName.Length);
            return ValidateAllCharactersExistsAtleastOnce(emblemName, decipheredText);
        }

        private bool ValidateAllCharactersExistsAtleastOnce(string sourceString, string searchString)
        {
            var sourceDict = sourceString.ToUpperInvariant().ToCharArray().GroupBy(x => x).ToDictionary(gr => gr.Key, y => y.Count());
            var searhDict = searchString.ToUpperInvariant().ToCharArray().GroupBy(x => x).ToDictionary(gr => gr.Key, y => y.Count());

            bool flag = true;
            foreach (var item in sourceDict)
            {
                if (!searhDict.ContainsKey(item.Key) || searhDict[item.Key] < item.Value)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }

        private string GetDecipheredText(string cipherText, int steps)
        {
            string decipheredText = string.Empty;
            foreach (var item in cipherText)
            {
                int ascii = (int)item;                

                if (ascii >= SmallLetterAsciiStart && ascii <= SmallLetterAsciiEnd)
                {
                    decipheredText += GetDecipheredChar(SmallLetterAsciiStart, SmallLetterAsciiEnd, ascii, steps);

                }
                else if (ascii >= CapitalLetterAsciiStart && ascii <= CapitalLetterAsciiEnd)
                {
                    decipheredText += GetDecipheredChar(CapitalLetterAsciiStart, CapitalLetterAsciiEnd, ascii, steps);
                }
                else
                {
                    decipheredText += item;
                }
            }

            return decipheredText;
        }

        private char GetDecipheredChar(int start, int end, int asciivalue, int steps)
        {
            int decriptedAscii = asciivalue - steps;
            return (char)((decriptedAscii < start) ? end + 1 + (decriptedAscii - start) % TotalAlphabets : decriptedAscii);
        }
    }
}
