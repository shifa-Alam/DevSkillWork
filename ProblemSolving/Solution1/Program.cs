using System;

namespace Solution1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/71/A


            var inputLength = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < inputLength; i++)
            {
                var text = Console.ReadLine();
                if (text.Length > 10)
                {
                    Console.WriteLine($"{text[0]}{text.Length - 2}{text[text.Length - 1]}");
                }
                else
                {
                    Console.WriteLine(text);
                }
            }
        }
    }
}
