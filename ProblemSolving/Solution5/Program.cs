using System;
using System.Linq;

namespace Solution5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //https://codeforces.com/problemset/problem/118/A


            string inputString = Console.ReadLine();

            string output = inputString.Replace("a", string.Empty, StringComparison.InvariantCultureIgnoreCase)
               .Replace("e", string.Empty, StringComparison.InvariantCultureIgnoreCase)
               .Replace("i", string.Empty, StringComparison.InvariantCultureIgnoreCase)
               .Replace("o", string.Empty, StringComparison.InvariantCultureIgnoreCase)
               .Replace("u", string.Empty, StringComparison.InvariantCultureIgnoreCase)
               .Replace("y", string.Empty, StringComparison.InvariantCultureIgnoreCase);


            string addDot = string.Empty;

            for (int i = 0; i < output.Length; i++)
            {
                addDot = addDot + "." + output[i].ToString().ToLower();
            }
            Console.WriteLine(addDot);

        }
    }
}
