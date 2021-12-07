using System.Collections;
using System.Reflection;

namespace Assignment1_objToJson_
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var course = new Course();
            course.Title = "Asp.net";
            course.Fees = 30000;
            course.Topics = new List<Topic>() { new Topic() { Description = "test" } };

            var person = new Person()
            {
                Id = 1,
                Name = "Shifa",
                Address = new Address() { City = "Dhaka", Country = "Bangladesh", Street = "17/A" },
            };
            //var json = Converter.JsonConverter<Person>(person);
            //List<int> abc = new List<int>() { 12, 12, 13 };
            var json = Converter.JsonConverter<Course>(course);
            //var json = Converter.JsonConverter<List<int>>(abc);

        }

    }


}
