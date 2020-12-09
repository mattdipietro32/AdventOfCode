using System;
using AdventOfCode._2020.Inputs;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day2.ReadFile();
            Console.WriteLine(Day2.ValidatePart1());
            Day2 d = new Day2();
            Console.WriteLine(d.ValidatePart2());
            
            //805 too high
            //200 too low
        }
    }
}
