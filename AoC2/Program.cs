using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace AoC2
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
            LinkedList<int> measurement = new LinkedList<int>();
            for (int i = 0; i < inputArray.Length; i++)
            {
                measurement.AddLast(Int32.Parse(inputArray[i]));
                if (measurement.Count == 3)
                {
                    int value = SumLinkedList(measurement);
                    if (previousValue != 0 && previousValue < value)
                    {
                        counter++;
                    }
                    previousValue = value;
                    measurement.RemoveFirst();
                }
            }
            return counter;
        }


        private static int SumLinkedList(LinkedList<int> measurement)
        {
            int[] array = new int[4];
            measurement.CopyTo(array, 0);
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
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
