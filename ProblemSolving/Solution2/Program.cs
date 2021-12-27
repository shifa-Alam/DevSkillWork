using System;

namespace Solution2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // https://codeforces.com/problemset/problem/282/A
            var x = 0;
            var count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var text = Console.ReadLine();
                if (text == "X++" || text == "++X")
                {
                    x = x + 1;
                }
                else if (text == "X--" || text == "--X")
                {
                    x = x - 1;
                }
            }
            Console.WriteLine(x);
        }
    }
}
