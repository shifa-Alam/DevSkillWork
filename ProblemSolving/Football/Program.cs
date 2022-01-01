using System;

namespace Football
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var playerPosition = Console.ReadLine();
            var count = 0;
            for (int i = 0; i < playerPosition.Length-1; i++)
            {
                if(playerPosition[i] == playerPosition[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count == 6)
                break;
            }

            if (count == 6) Console.WriteLine("YES");
            else Console.WriteLine("NO");

        }
    }
}
