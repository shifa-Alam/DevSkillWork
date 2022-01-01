using System;

namespace Tram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stationNumber = Convert.ToInt32(Console.ReadLine());
            int p = 0, max = 0;

            for (int i = 0; i < stationNumber; i++)
            {
                var inputNumbers = Console.ReadLine();
                var numbers = inputNumbers.Split(' ');
                p = Convert.ToInt32(numbers[1]) - Convert.ToInt32(numbers[0]) + p;
                if (max < p)
                {
                    max = p;
                }

            }
            Console.WriteLine(max);
        }
    }
}
