
namespace Assignment2CodeForceProblemSolving
{
    public class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Enter number");
            var count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string inputText = Console.ReadLine();
                if (inputText?.Length > 10)
                {
                    Console.WriteLine($"{inputText[0]}{inputText.Length - 2}{inputText[inputText.Length - 1]}");
                }
                else
                {
                    Console.WriteLine(inputText);
                }
            }

        }
    }
}