using FirstDemo.Web.AdoNetData;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Models
{
    public class TestModel
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public IList<IDictionary<string, object>> Courses { get; set; }

        public TestModel()
        {

        }

        internal void DoSomething()
        {
            throw new NotImplementedException();
        }

        internal void InsertData(string connectionString)
        {
            var title = "PHP";
            var fees = 3000;
            var isActive = true;
            var regEndDate = new DateTime(2022, 1, 29);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("@title", title);
            data.Add("@fees", fees);
            data.Add("@isActive", isActive);
            data.Add("@registrationEnd", regEndDate);


            var command = @"Insert into courses (title, fees,isactive,registrationend) 
                values ( @title,@fees,@isActive,@registrationEnd)";
            var dataUtility = new DataUtility(connectionString);
            dataUtility.ExecuteCommand(command, data);
        }
        internal void GetData(string connectionString)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("@isActive", true);
            var command = @"SELECT * FROM courses where isActive=@isActive";
            var dataUtility = new DataUtility(connectionString);
             Courses = dataUtility.GetData(command, data);
        }
    }
}
