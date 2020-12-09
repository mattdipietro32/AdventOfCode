using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace AdventOfCode._2020.Inputs
{
    public class Day2
    {
        static List<Password> passwords = new List<Password>();

        public static void ReadFile()
        {
            string[] inputs = File.ReadAllLines(@"C:\Users\mttdp\Desktop\AdventOfCode\2020\Inputs\Day2input.txt");
            foreach (var input in inputs)
            {
                passwords.Add(new Password(input));
            }
            
        }

        public static void PrintContents()
        {
            passwords.ForEach(pw => { Console.Write(pw); });
        }

        //Solves for Day 2 - Part 1
        public static int ValidatePart1()
        {
            int totalCount = 0;
            foreach (var password in passwords)
            {
                int count = password.PW.Count(p => p == password.Value);
                if (count >= password.Min && count <= password.Max)
                {
                    totalCount += 1;
                }
            }
            return totalCount;
        }

        public int ValidatePart2() =>
            passwords.Count(x => IsPassWordValid2(x));

        public bool IsPassWordValid2(Password pw) =>
            pw.PW[pw.Min - 1] == pw.Value ^ pw.PW[pw.Max - 1] == pw.Value;
    }

    public class Password
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public char Value { get; private set; }
        public string PW { get; private set; }

        public Password(string input)
        { 
            var matches  = new Regex(@"(\d*)-(\d*) (\w): (.*)").Match(input);
            Min = matches.GetGroupValue<int>(1);
            Max = matches.GetGroupValue<int>(2);
            Value = matches.GetGroupValue<char>(3);
            PW = matches.GetGroupValue<string>(4);
            
        }

        public override string ToString()
        {
            return $"_________\n Min: {this.Min}\n Max: {this.Max}\n Value: {this.Value}\n PW: {this.PW}\n_________";
        }
        
    }
}
