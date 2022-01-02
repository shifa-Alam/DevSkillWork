using System;

namespace Bear_and_Big_Brother
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // https://codeforces.com/problemset/problem/791/A

            var inputString = Console.ReadLine();
            var weights =inputString.Split(' ');
            var limakWeight = Convert.ToInt32(weights[0]);
            var hisBrotherWeight = Convert.ToInt32(weights[1]);
            var years = 0;
            while (limakWeight<=hisBrotherWeight)
            {
                limakWeight =limakWeight * 3;
                hisBrotherWeight=hisBrotherWeight * 2;
                years++;
            }
            Console.WriteLine(years);
        }
    }
}
