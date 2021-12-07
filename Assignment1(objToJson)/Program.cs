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
                //Marks = new List<double> { 35.5, 30, 10 },
                Fees =30000
            };
            //var json = Converter.JsonConverter<Person>(person);
            var json = Converter.JsonConverter<Course>(course);

           

        }

    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address  Address { get; set; }
        public List<double> Marks { get; set;}
        public double Fees { get; set; }

    }


    public class Course
    {
     
        public string Title { get; set; }
        public Instructor Teacher { get; set; }
        public List<Topic> Topics { get; set; }
        public double Fees { get; set; }
        public List<AdmissionTest> Tests { get; set; }
    }

    public class AdmissionTest
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double TestFees { get; set; }
    }

    public class Topic
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
    }

    public class Session
    {
        public int DurationInHour { get; set; }
        public string LearningObjective { get; set; }
    }
    public class Instructor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address PresentAddress { get; set; }
        public Address PermanentAddress { get; set; }
        public List<Phone> PhoneNumbers { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Phone
    {
        public string Number { get; set; }
        public string Extension { get; set; }
        public string CountryCode { get; set; }
    }


}
