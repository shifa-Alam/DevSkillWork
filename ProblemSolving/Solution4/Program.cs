using System;

namespace Solution4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/112/A

            var string1 = Console.ReadLine();
            var string2 = Console.ReadLine();
           
            Console.WriteLine( string.Compare(string1.ToUpper(), string2.ToUpper()).ToString() );  
        }
    }
}
