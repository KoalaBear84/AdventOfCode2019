using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day01
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string title = "AdventOfCode2019 - Day 01";
            Console.Title = title;
            ConsoleEx.WriteLine(title, ConsoleColor.Green);

            List<string> inputLines = (await File.ReadAllLinesAsync("input.txt")).ToList();

            Stopwatch stopwatch = Stopwatch.StartNew();

            (int totalFuel1, int totalExtraFuel1) = GetTotalFuel(inputLines, star: 1);

            stopwatch.Stop();
            // Answer: 3323874
            ConsoleEx.WriteLine($"Star 1. {stopwatch.ElapsedMilliseconds}ms. Answer: {totalFuel1}", ConsoleColor.Yellow);

            stopwatch.Restart();

            (int totalFuel2, int totalExtraFuel2) = GetTotalFuel(inputLines, star: 2);

            // Answer: 4982961
            ConsoleEx.WriteLine($"Star 2. {stopwatch.ElapsedMilliseconds}ms. Answer: {totalFuel2 + totalExtraFuel2}", ConsoleColor.Yellow);

            ConsoleEx.WriteLine("END", ConsoleColor.Green);
            Console.ReadKey();
        }

        private static (int totalFuel, int totalExtraFuel) GetTotalFuel(List<string> inputLines, int star)
        {
            int totalFuel = 0;
            int totalExtraFuel = 0;

            foreach (string inputLine in inputLines)
            {
                int newFuel = GetFuel(int.Parse(inputLine));
                totalFuel += newFuel;

                if (star == 2)
                {
                    int extraFuel = newFuel;

                    do
                    {
                        extraFuel = GetFuel(extraFuel);

                        if (extraFuel > 0)
                        {
                            totalExtraFuel += Math.Max(extraFuel, 0);
                        }
                    } while (extraFuel > 0);
                }
            }

            return (totalFuel, totalExtraFuel);
        }

        private static int GetFuel(double mass)
        {
            mass /= 3;
            mass = Math.Floor(mass);
            mass -= 2;

            return (int)mass;
        }
    }
}
