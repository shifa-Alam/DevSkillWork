using Orm.ConsoleApp.Entities;

namespace Orm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var con = "Server=DESKTOP-EA380EP\\SQLEXPRESS;Database=Assignment4;Trusted_Connection=true";

            Rooms room = new Rooms
            {
                
                Rent=3400,
                HouseId=1
            };
            

            var orm = new MyORM<Rooms>(con);
            orm.Delete(2);
            var getData =orm.GetById(1);

            orm.Insert(room);

            var result = orm.GetAll();
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }

            Console.WriteLine("Hello World!");
        }
    }
}