namespace Task4
{

   class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            var modifiedString = inputString.Split(' ');
            if (modifiedString.Length > 0 && modifiedString[1] == "pm")
            {
                var firstPart = modifiedString[0].Split(':');
                var inNumber = Convert.ToInt64(firstPart[0]);
                if (firstPart.Length > 0 && inNumber < 12)
                {
                    inNumber = inNumber + 12;
                }
                Console.WriteLine($"{inNumber.ToString()} : {firstPart[1]}");
            }
            else
            {
                inputString = inputString.Replace('a', ' ');
                inputString = inputString.Replace('m', ' ');
                inputString = inputString.Replace('p', ' ');
                
                Console.WriteLine(inputString);
                
            }

        }


    }
}

