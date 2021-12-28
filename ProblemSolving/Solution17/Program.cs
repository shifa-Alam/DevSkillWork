using System;

namespace Solution17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/133/A

            var inputString = Console.ReadLine();

            if (inputString.Contains("H") || inputString.Contains("Q") || inputString.Contains("9"))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
