using System;
using System.IO;

namespace AoC1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ReadInput(@"Input\input.txt");
            string[] inputArray = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            int result = HowManyEntriesAreGreater(inputArray);
            Console.WriteLine(result.ToString());
        }

        private static int HowManyEntriesAreGreater(string[] inputArray)
        {
            int previousValue = 0;
            int counter = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                int value = Int32.Parse(inputArray[i]);
                if ((previousValue < value) && (i != 0))
                {
                    counter++;
                }
                previousValue = value;
            }
            return counter;
        }

        private static string ReadInput(string fileLocation)
        {
            string output = string.Empty;
            try
            {
                var sr = new StreamReader(fileLocation);
                output = sr.ReadToEnd();
            }
            catch (System.Exception)
            {

                throw;
            }

            return output;
        }
    }
}
