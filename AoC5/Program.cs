using System;
using AoC.Common;
using System.Collections.Generic;

namespace AoC5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Common.ReadInput(@"input\input.txt");
            string[] rawParsedInput = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
            string[] luckyNumbers = rawParsedInput[0].Split(',');
            string[] rawBoards = new string[rawParsedInput.Length - 1];
            Array.Copy(rawParsedInput, 1, rawBoards, 0, rawParsedInput.Length - 1);
            BingoBoard[] boards = GenerateBoards(rawBoards);
            int completedBoards = 0;
            int answer = 0;
            foreach (var number in luckyNumbers)
            {
                for (int i = 0; i < boards.Length; i++)
                {
                    if (boards[i].Board.ContainsKey(number))
                    {
                        boards[i].Board[number] = true;
                        if (!boards[i].Won && boards[i].CheckForWin())
                        {
                            completedBoards++;
                            boards[i].Won = true;
                            // answer = boards[i].GetSumUnmarkedNumbers() * Int32.Parse(number);
                        }
                    }
                    if (completedBoards == 100)
                    {
                        answer = boards[i].GetSumUnmarkedNumbers() * Int32.Parse(number);
                        break;
                    }
                }

                if (answer != 0)
                {
                    break;
                }
            }
            Console.WriteLine(answer);
        }

        private static BingoBoard[] GenerateBoards(string[] rawBoards)
        {
            BingoBoard[] boards= new BingoBoard[rawBoards.Length];
            for (int i = 0; i < boards.Length; i++)
            {
                boards[i] = new BingoBoard(rawBoards[i]);
            }
            return boards;
        }

        public class BingoBoard
        {
            public bool Won{get;set;}
            public Dictionary<string, bool> Board { get; set; }
            public BingoBoard(string input)
            {
                Board = new Dictionary<string, bool>();
                input = input.Replace("\n", " ");
                string[] inputArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var inputLine in inputArray)
                {
                    Board.Add(inputLine, false);
                }
            }

            public int GetSumUnmarkedNumbers()
            {
                int value = 0;
                foreach (var key in this.Board.Keys)
                {
                    if (!this.Board[key])
                    {
                        value += Int32.Parse(key);
                    }
                }
                return value;
            }

            public bool CheckForWin()
            {
                bool[] boardValues = new bool[this.Board.Values.Count];
                this.Board.Values.CopyTo(boardValues, 0);
                bool[,] boardArray = new bool[5, 5];
                for (int i = 0; i < boardValues.Length; i++)
                {
                    boardArray[i / 5, i % 5] = boardValues[i];
                }
                return CheckRows(boardArray) || CheckCols(boardArray);
            }

            private bool CheckRows(bool[,] boardArray)
            {
                bool win = false;
                for (int i = 0; i < 5; i++)
                {
                    int counter = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (boardArray[i, j])
                        {
                            ++counter;
                        }
                        if (counter == 5)
                        {
                            win = true;
                            break;
                        }
                    }
                }
                return win;
            }
            private bool CheckCols(bool[,] boardArray)
            {
                bool win = false;
                for (int i = 0; i < 5; i++)
                {
                    int counter = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        if (boardArray[j, i])
                        {
                            ++counter;
                        }
                        if (counter == 5)
                        {
                            win = true;
                            break;
                        }
                    }
                }
                return win;
            }
        }
    }
}
