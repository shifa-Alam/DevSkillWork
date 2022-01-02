using System;

namespace Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            var upperCaseCount = 0;
            var lowerCaseCount = 0;
            for (var i = 0; i < inputString.Length; i++)
            {
                if (char.IsUpper(inputString[i])) upperCaseCount++;
                else lowerCaseCount++;
            }
            if (upperCaseCount > lowerCaseCount)
            {
                inputString = inputString.ToUpperInvariant();
            }
            else
            {
                inputString = inputString.ToLowerInvariant();
            }

            Console.WriteLine(inputString);

        }
    }
}
