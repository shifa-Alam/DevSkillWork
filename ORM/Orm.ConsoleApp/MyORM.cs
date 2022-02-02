using Microsoft.Extensions.Configuration;
using Orm.ConsoleApp.AdoDotNetCode;
using Orm.ConsoleApp.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp
{
    public class MyORM<T> where T : class
    {
        private string _connectionString;

        public MyORM(string connectionString)
        {
            _connectionString = connectionString;

        }
        public void Insert(T item)
        {

            //var title = "PHP";
            //var fees = 3000;
            //var isActive = true;
            //var regEndDate = new DateTime(2022, 1, 29);

            //Dictionary<string, object> data = new Dictionary<string, object>();
            ////data.Add("@title", title);
            ////data.Add("@fees", fees);
            ////data.Add("@isActive", isActive);
            ////data.Add("@registrationEnd", regEndDate);


            //var command = @"Insert into courses (title, fees,isactive,registrationend) 
            //    values ( @title,@fees,@isActive,@registrationEnd)";

            //var dataUtility = new DataUtility(_connectionString);
            //dataUtility.ExecuteCommand(command, data);
        }
        public void Update(T item)
        {

        }
        public void Delete(T item)
        {

        }
        public void Delete(int id)
        {

        }
        public T GetById(int id)
        {

            return null;
        }
        public List<T> GetAll()
        {
            var type = typeof(T);


            var tableName = type.Name;
            var props = type.GetProperties();

            Dictionary<string, object> data = new Dictionary<string, object>();

            var command = @$"SELECT * FROM {tableName};";

            var dataUtility = new DataUtility(_connectionString);
            var Dbresult = dataUtility.GetData(command, data);

            List<T> result = new List<T>();
            foreach (var item in Dbresult)
            {
                bool isArray = typeof(IEnumerable).IsAssignableFrom(type?.GetType()) ? true : false;
                var instance = Activator.CreateInstance(typeof(T)) as T;

                foreach (var a in item)
                {

                    var prop = props.FirstOrDefault(p => p.Name.ToLower() == a.Key.ToLower());
                    if (prop != null)
                    {
                        prop.SetValue(instance, a.Value, null);
                    }


                }



                result.Add(instance);
            }

            return result;

        }


    }
}
