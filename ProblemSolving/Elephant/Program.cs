using System;

namespace Elephant
{
    internal class Program
    {
        static void Main(string[] args)
        {
           var input= Convert.ToInt32(Console.ReadLine());
            if (input % 5==0)
            {
                Console.WriteLine(input / 5);
            }
            else { Console.WriteLine(input/5+1); }
        }
    }
}
