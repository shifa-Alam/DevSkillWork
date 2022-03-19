namespace Task2
{

    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine();
            var rotationCount =Convert.ToInt64(Console.ReadLine());
            inputString = inputString.Trim();
            for (int i = 0; i < rotationCount; i++)
            {
                var lastItem =inputString[inputString.Length-1];

                Console.WriteLine(lastItem);
                inputString= inputString.Remove(inputString.Length - 1, 1);
                inputString = lastItem+inputString;
               


            }
            Console.WriteLine(inputString);

        }


    }
}

