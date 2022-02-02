using Orm.ConsoleApp.Entities;

namespace Orm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = "Server=DESKTOP-EA380EP\\SQLEXPRESS;Database=Assignment4;Trusted_Connection=true";

            var orm = new MyORM<Houses>(con);
            var result = orm.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }

            Console.WriteLine("Hello World!");
        }
    }
}