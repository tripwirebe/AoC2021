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
            // initialize the fishes array
            foreach (var i in input)
            {
                fishes[Int32.Parse(i)]++;
            }
            
            for (int i = 0; i < numDays; i++)
            {
                // cycle every day
                // the fishes that are giving birth get separated
                long givingBirth = fishes[0];
                //shift the array to the left and overwrite value 0
                Array.Copy(fishes,1,fishes,0,8);
                //fishes = giving brith = new youngsters
                fishes[8]=givingBirth;
                //fishes that gave brith get added to the next cycle
                fishes[6]=fishes[6]+givingBirth;
            }
            // sum of the array is the total amount of fishes
            long sum = fishes.Sum();
            Console.WriteLine(sum);
            long memory = GC.GetTotalMemory(true);
            Console.WriteLine(memory);
        }
    }
}
