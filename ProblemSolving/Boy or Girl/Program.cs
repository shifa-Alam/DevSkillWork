using System;

namespace Boy_or_Girl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            var s = inputString.ToCharArray();
            Array.Sort(s);
            var count = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                {
                    count++;
                }
            }
            if ((s.Length - count) % 2 == 0) { Console.WriteLine("CHAT WITH HER!"); }
            else { Console.WriteLine("IGNORE HIM!"); }
        }
    }
}
