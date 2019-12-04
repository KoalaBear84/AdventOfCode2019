using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day02
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string title = "AdventOfCode2019 - Day 02";
            Console.Title = title;
            ConsoleEx.WriteLine(title, ConsoleColor.Green);

            List<int> inputLines = (await File.ReadAllTextAsync("input.txt")).Split(',').Select(l => int.Parse(l)).ToList();
            int noun = 12;
            int verb = 2;

            inputLines[1] = noun;
            inputLines[2] = verb;

            Stopwatch stopwatch = Stopwatch.StartNew();

            int answer1 = Process(inputLines, star: 1);

            stopwatch.Stop();
            // Answer: 4690667
            ConsoleEx.WriteLine($"Star 1. {stopwatch.ElapsedMilliseconds}ms. Answer: {answer1}", ConsoleColor.Yellow);

            stopwatch.Restart();

            int checksum = 19690720;
            string answer2 = string.Empty;
            int calculatedChecksum = 0;

            for (int star2Noun = 0; star2Noun <= 99; star2Noun++)
            {
                for (int star2Verb = 0; star2Verb <= 99; star2Verb++)
                {
                    inputLines[1] = star2Noun;
                    inputLines[2] = star2Verb;

                    calculatedChecksum = Process(inputLines, star: 2);

                    if (calculatedChecksum == checksum)
                    {
                        answer2 = $"{star2Noun} {star2Verb}";
                        break;
                    }
                }
            }

            stopwatch.Stop();
            // Answer: 6255
            ConsoleEx.WriteLine($"Star 2. {stopwatch.ElapsedMilliseconds}ms. Answer: {answer2}", ConsoleColor.Yellow);

            ConsoleEx.WriteLine("END", ConsoleColor.Green);
            Console.ReadKey();
        }

        private static int Process(List<int> inputLines, int star)
        {
            List<int> memory = inputLines.Clone<List<int>>();
            int addressBasePointer = 0;

            while (true)
            {
                int instruction = memory[addressBasePointer];

                if (instruction != 1 && instruction != 2)
                {
                    break;
                }

                int inputPosition1 = memory[addressBasePointer + 1];
                int inputPosition2 = memory[addressBasePointer + 2];
                int outputPosition = memory[addressBasePointer + 3];

                int input1 = memory[inputPosition1];
                int input2 = memory[inputPosition2];

                if (instruction == 1)
                {
                    memory[outputPosition] = input1 + input2;
                    addressBasePointer += 4;
                }

                if (instruction == 2)
                {
                    memory[outputPosition] = input1 * input2;
                    addressBasePointer += 4;
                }
            }

            return memory[0];
        }
    }
}
