using System;

namespace Wrong_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://codeforces.com/problemset/problem/977/A

            var inputParam = Console.ReadLine();
            var formaterParam = inputParam.Split(' ');
            var numberOfSubtraction = Convert.ToInt32(formaterParam[1]);
            var number = formaterParam[0];
            //var result = 0;
            for (int i = 0; i < numberOfSubtraction; i++)
            {
                if (number[number.Length - 1] == '0')
                {
                    number = number.Remove(number.Length - 1);
                }
                else
                {
                    number =  (Convert.ToInt32(number)-1).ToString();
                }
            }
            Console.WriteLine(number);
        }
    }
}
