using System;
using System.Linq;
using AoC.Common;

namespace AoC7b
{
    class Program
    {
        static void Main(string[] args)
        {
            //int numDays = 80;
            int numDays = 256;
            string [] input = Common.ReadInput(@"Input\input.txt").Split(',',StringSplitOptions.RemoveEmptyEntries);
            long[]fishes = new long[9];
            foreach (var i in input)
            {
                fishes[Int32.Parse(i)]++;
            }
            for (int i = 0; i < numDays; i++)
            {
                long givingBirth = fishes[0];
                Array.Copy(fishes,1,fishes,0,8);
                fishes[8]=givingBirth;
                fishes[6]=fishes[6]+givingBirth;
            }
            long sum = fishes.Sum();
            Console.WriteLine(sum);
        }
    }
}
