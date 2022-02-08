using Orm.ConsoleApp.Entities;

namespace Orm.ConsoleApp
{
    class Program
    {
        private static string connectionString = "Server=DESKTOP-EA380EP\\SQLEXPRESS;Database=Assignment4;Trusted_Connection=true";

        static void Main(string[] args)
        {

            //Insert();
            Update();
            //Delete();
            //DeleteById();
            //GetById();
            //GetAll();
        }

        private static void Insert()
        {
            var orm = new MyORMV2<Villages>();

            var village = new Villages
            {
                Id = 3,
                Name = "KKLL",
                houses = new List<Houses>{
                                     new Houses {
                                        Id = 195,
                                        Name = "test",
                                        VillageId=3,
                                        Rooms = new List<Rooms> {
                                                new Rooms {
                                                    Id = 900,
                                                    Rent = 900,
                                                    HouseId = 195
                                                }
                                            }
                                        }
                            }
            };


            orm.Insert(village);
            //for (int i = 1; i <= 10; i++)
            //{
            //    Rooms room = new Rooms {Id=i, Rent = 9000+(i*1000) ,HouseId=1};
            //    orm.Insert();
            //}
        }

        private static void Update()
        {
            var orm = new MyORMV2<Villages>();

            var village = new Villages
            {
                Id = 3,
                Name = "Shewrapara",
                houses = new List<Houses>{
                                     new Houses {
                                        Id = 195,
                                        Name = "Japani",
                                        VillageId=3,
                                        Rooms = new List<Rooms> {
                                                new Rooms {
                                                    Id = 900,
                                                    Rent = 45000,
                                                    HouseId = 195
                                                }
                                            }
                                        }
                            }
            };


            orm.Update(village);
        }

        private static void Delete()
        {
            Rooms room = new Rooms
            {
                //Rent = 10000,
                //HouseId = 1,
                Id = 40,
            };
            var orm = new MyORM<Rooms>(connectionString);
            orm.Delete(room);
        }

        private static void DeleteById()
        {
            var orm = new MyORM<Rooms>(connectionString);
            orm.Delete(2);
        }

        private static void GetById()
        {
            var orm = new MyORM<Rooms>(connectionString);
            orm.GetById(2);
        }


        private static void GetAll()
        {
            var orm = new MyORM<Rooms>(connectionString);
            var dbRecords = orm.GetAll();
            if (dbRecords.Count() == 0) Console.WriteLine("NO RECORD'S FOUND!");
            foreach (var item in dbRecords)
            {
                Console.WriteLine($"Id : {item.Id} Rent : {item.Rent} HouseId : {item.HouseId}");
            }
        }

    }
}