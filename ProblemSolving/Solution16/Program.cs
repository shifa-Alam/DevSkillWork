using System;

namespace Solution16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/58/A

            var inputString = Console.ReadLine();
            string a = "hello";
            var x = 0;
            var y = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == a[x])
                {
                    x++;
                    y++;
                }
                if (y >= a.Length)
                {
                    break;
                }
              
            }
            if (y == a.Length) Console.WriteLine("YES");
            else Console.WriteLine("NO");
            
            
        }
    }
}
