using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2CodeForceProblemSolving
{
    public  class Problem1
    {
        public static void Print()
        {
            var count= Convert.ToInt32(Console.ReadLine());
            for (int i=0; i<count; i++)
            {
                string inputText =Console.ReadLine();
                if (inputText?.Length > 10)
                {
                    Console.WriteLine($"{inputText[0]}{inputText.Length-2}{inputText[inputText.Length-1]}");
                }
                else
                {
                    Console.WriteLine(inputText);
                }
            }
        }
    }
}
