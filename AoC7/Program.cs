using System;
using System.Collections.Generic;
using AoC.Common;

namespace AoC7
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfDays = 80;
            // string []input = "3,4,3,1,2".Split(',',StringSplitOptions.RemoveEmptyEntries);
            string[]input = Common.ReadInput(@"input\input.txt").Split(',',StringSplitOptions.RemoveEmptyEntries);
            List<LanterFish> school = new List<LanterFish>();
            for (int i = 0; i < input.Length; i++)
            {
                school.Add(new LanterFish(Int32.Parse(input[i])));
            }
            for (int i = 0; i < numberOfDays; i++)
            {
                school = Tick(school);
                Console.WriteLine(school.Count);
            }
            long memory = GC.GetTotalMemory(true);
            Console.WriteLine(memory);
        }

        private static void printSchool(List<LanterFish> school)
        {
            string output = string.Empty;
            foreach (var fish in school)
            {
                output+=fish.Counter.ToString()+",";
            }
            Console.WriteLine(output);
        }

        private static List<LanterFish> Tick(List<LanterFish> school)
        {
            List<LanterFish> youngSchool = new List<LanterFish>();
            foreach (var lanterfish in school)
            {
                lanterfish.Counter--;
                if(lanterfish.Counter<0){
                    youngSchool.Add(new LanterFish());
                    lanterfish.Counter=6;
                }
            }
            school.AddRange(youngSchool);
            return school;
        }
    }
    internal class LanterFish
    {
        internal int Counter{get;set;}
        public LanterFish(){
            this.Counter=8;
        }
        public LanterFish(int input){
            this.Counter = input;
        }

    }
}
