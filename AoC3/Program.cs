using System;
using System.IO;
using AoC.Common;

namespace AoC3
{
    class Program
    {

        static void Main(string[] args)
        {
            Submarine sub = new Submarine();
            string input = Common.ReadInput(@"input\input.txt");
            string[] inputArray = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            SubmarineAction[] actions = new SubmarineAction[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                string[] actionArray = inputArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                actions[i] = new SubmarineAction() { ActionType = actionArray[0], Value = Int32.Parse(actionArray[1]) };
            }
            sub.ExecuteActions(actions);
            int position = sub.GetPosition2D();
            Console.WriteLine(position);
        }
   }

    public class SubmarineAction
    {
        public string ActionType;
        public int Value;
    }
    public class Submarine
    {
        int X { get; set; }
        int Y { get; set; }
        int Aim { get; set; }
        public Submarine()
        {
            this.X = 0;
            this.Y = 0;
            this.Aim = 0;
        }
        public void ExecuteActions(SubmarineAction[] actions)
        {
            for (int i = 0; i < actions.Length; i++)
            {
                switch (actions[i].ActionType)
                {
                    case "forward": this.X += actions[i].Value; this.Y += this.Aim * actions[i].Value; break;
                    case "up": this.Aim -= actions[i].Value; break;
                    case "down": this.Aim += actions[i].Value; break;
                    default:; break;
                }
            }
        }
        public int GetPosition2D()
        {
            return this.X * this.Y;
        }
    }
}
