using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

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
            foreach (var pw in passwords)
            {
                Console.WriteLine($"Min: {pw.Min} Max: {pw.Max} Value: {pw.Value} PW: {pw.PW}");
            }
        }

        public static int findMatchCount()
        {
            int Totalcount = 0;
            foreach (var password in passwords)
            {
                int count = password.PW.Count(p => p == password.Value);
                if (count >= password.Min && count <= password.Max)
                {
                    Totalcount += 1;
                }
            }
            return Totalcount;
        }


    }


    public class Password
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public char Value { get; private set; }
        public string PW { get; private set; }

        public Password(string input)
        {    
            //gets the min and max range from the input value
            Regex minMaxRegex = new Regex(@"\d?\d-\d\d?");
            Match m = minMaxRegex.Match(input);
            string[] a = m.ToString().Split("-");
            Min = Int32.Parse(a[0]);
            Max = Int32.Parse(a[1]);
            
            //Get the character to test against. 
            //EX: "7-10 v: gpvgmqkvxgbvs" would return v
            Regex valueRegex = new Regex(@" .:");
            Match vm = valueRegex.Match(input);
            Value = Convert.ToChar(vm.ToString().TrimEnd(':').TrimStart(' '));
            
            //Get the password to check, and then trip off the ": "
            //EX: "7-10 v: gpvgmqkvxgbvs" would return gpvgmqkvxgbvs
            Regex pwRegex = new Regex(@"\:\s(.*)");
            Match pwm = pwRegex.Match(input);
            PW = pwm.ToString().TrimStart(':').Trim();
        }
        
    }
}
