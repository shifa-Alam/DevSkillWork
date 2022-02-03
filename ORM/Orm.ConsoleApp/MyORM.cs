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
            var type = typeof(T);

            var tableName = type.Name;
            var props = type.GetProperties();
            StringBuilder keys = new StringBuilder();
            StringBuilder keyWithAnnotation = new StringBuilder();

            Dictionary<string, object> data = new Dictionary<string, object>();

            foreach (var prop in props)
            {
                if (prop.Name.Equals("Id")) continue;
                keys.Append(prop.Name + ",");
                keyWithAnnotation.Append("@" + prop.Name + ",");
                data.Add($"@{prop.Name}", prop.GetValue(item));
            }
            keys.Remove(keys.Length - 1, 1);
            keyWithAnnotation.Remove(keyWithAnnotation.Length - 1, 1);


            var command = @$"Insert into {tableName} ({keys}) 
                values ( {keyWithAnnotation})";

            var dataUtility = new DataUtility(_connectionString);
            dataUtility.ExecuteCommand(command, data);

        }
        public void Update(T item)
        {

        }
        public void Delete(T item)
        {

        }
        public void Delete(int id)
        {
            var type = typeof(T);

            var tableName = type.Name;
            

            Dictionary<string, object> data = new Dictionary<string, object>();

            var command = @$"Delete from  {tableName} Where id={id}";

            var dataUtility = new DataUtility(_connectionString);
            dataUtility.ExecuteCommand(command, data);
        }
        public T GetById(int id)
        {
            var type = typeof(T);

            var tableName = type.Name;
            var props = type.GetProperties();

            Dictionary<string, object> data = new Dictionary<string, object>();

            var command = @$"SELECT * FROM {tableName} where id={id};";

            var dataUtility = new DataUtility(_connectionString);
            var Dbresult = dataUtility.GetData(command, data);


            var instance = Activator.CreateInstance(typeof(T)) as T;
            foreach (var item in Dbresult)
            {
             
                foreach (var a in item)
                {

                    var prop = props.FirstOrDefault(p => p.Name.ToLower() == a.Key.ToLower());
                   
                    if (prop != null)
                    {
                        prop.SetValue(instance, a.Value, null);
                    }

                }

              
            }

            return instance;

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
