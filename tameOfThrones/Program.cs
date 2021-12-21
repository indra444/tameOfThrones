using geektrust.CipherAlgorithm;
using geektrust.Exceptions;
using geektrust.Helpers;
using System;

namespace geektrust
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if(args.Length == 0 || string.IsNullOrEmpty(args[0]))
                {
                    Console.WriteLine("Please specify filepath");
                    return;
                }

                IInputReader inputReader = new FileReader(args[0]);
                IInputConverter inputConverter = new InputConverter(inputReader);
                IEncryption encryptionHelper = new SoutherosEncryptionAlgorithm();
                IDataHelper dataHelper = new DataHelper();

                var input = inputConverter.Convert();

                var tameOfThrones = new TameOfThrones(encryptionHelper, dataHelper);
                var result = tameOfThrones.GetResult(input);

                Console.WriteLine(result);
            }
            catch (InputFileReadValidationException messaage)
            {

                Console.WriteLine(messaage.Message);
            }
        }
    }
}
