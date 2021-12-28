using System;
using System.Linq;

namespace Solution6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/339/A

            var inputString = Console.ReadLine();
            var splitString = inputString.Split('+');
            var outputString = string.Empty;

            splitString = splitString.OrderBy(d => d).ToArray();
            for (int i = 0; i < splitString.Length; i++)
            {
                outputString = outputString + splitString[i] + "+";
            }
            outputString= outputString.Remove(outputString.Length - 1, 1);
            Console.WriteLine(outputString);
        }
    }
}
