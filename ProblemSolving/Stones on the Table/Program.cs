using System;

namespace Stones_on_the_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var inputNumber = Convert.ToInt32(Console.ReadLine());
            var inputString = Console.ReadLine();
            var count = 0;
            if (inputString.Length == inputNumber)
            {
                for (int i = 0; i < inputNumber-1; i++)
                {
                    if(inputString[i] == inputString[i + 1])
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
            }
        }
    }
}
