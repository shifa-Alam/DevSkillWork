using System;

namespace Soldier_and_Bananas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputStatement = Console.ReadLine();
            var statement = inputStatement.Split(' ');
            var bananaPrice = Convert.ToInt32(statement[0]);
            var hisAmount = Convert.ToInt32(statement[1]);
            var bananaQuantity = Convert.ToInt32(statement[2]);

            var sum = 0;

            for (int i = bananaQuantity; i > 0; i--)
            {
                sum = sum + (bananaPrice * i);
            }
        
            Console.WriteLine(hisAmount > sum? 0:(sum-hisAmount));
        }
    }
}
