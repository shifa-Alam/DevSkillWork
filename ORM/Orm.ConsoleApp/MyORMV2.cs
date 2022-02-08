using Microsoft.Extensions.Configuration;
using Orm.ConsoleApp.AdoDotNetCode;
using Orm.ConsoleApp.Entities;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp
{
    public class MyORMV2<T> where T : class
    {
        private string _connectionString;

        List<string> commands;
        List<Dictionary<string, object>> dataList;
       
        public MyORMV2()
        {
            _connectionString = "Server=DESKTOP-EA380EP\\SQLEXPRESS;Database=Assignment4;Trusted_Connection=true";
            commands = new List<string>();
            dataList = new List<Dictionary<string,object>>();

        }
        public void Insert(T item)
        {
            MakeCommandAndDataListForInsert(item);
            var dataUtility = new DataUtility(_connectionString);

            for (int i = commands.Count-1; i >=0 ; i--)
            {
               
                dataUtility.ExecuteCommand(commands[i], dataList[i]);
            }



        }

     
        public void Update(T item)
        {
         
            MakeCommandAndDataListForUpdate(item);

            var dataUtility = new DataUtility(_connectionString);

            for (int i = commands.Count - 1; i >= 0; i--)
            {

                dataUtility.ExecuteCommand(commands[i], dataList[i]);
            }



        }

        public void Delete(T item)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var props = type.GetProperties();
            int id = 0;
            foreach (var prop in props)
            {
                if (prop.Name == "Id")
                    id = (int)prop.GetValue(item);
            }
            if (id > 0)

                Delete((int)id);


            else
            {
                Dictionary<string, object> data = new Dictionary<string, object>();

                var columnUpdates = props.Where(p => p.Name != "Id").Select(p => $"{p.Name} = @{p.Name}");
                var columns = string.Join(" And ", columnUpdates);

                foreach (var prop in props)
                {

                    data.Add($"@{prop.Name}", prop.GetValue(item));
                }

                var sqlCommand = $"Delete from  {tableName} WHERE {columns}";
                var dataUtility = new DataUtility(_connectionString);
                dataUtility.ExecuteCommand(sqlCommand, data);

            }
        }
        public void Delete(int id)
        {
            var type = typeof(T);

            var tableName = type.Name;


            Dictionary<string, object> data = new Dictionary<string, object>();

            var sqlCommand = @$"Delete from  {tableName} Where id={id}";

            var dataUtility = new DataUtility(_connectionString);
            dataUtility.ExecuteCommand(sqlCommand, data);
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




        private void MakeCommandAndDataListForInsert(object item)
        {
            try
            {
                var type = item.GetType();
                bool isList = (type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type));


                if (!isList)
                {
                    var tableName = type.Name;
                    var props = type.GetProperties();
                    StringBuilder keys = new StringBuilder();
                    StringBuilder keyWithAnnotation = new StringBuilder();

                    Dictionary<string, object> data = new Dictionary<string, object>();

                    foreach (var prop in props)
                    {
                        if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Decimal) || prop.PropertyType == typeof(string))
                        {
                            keys.Append(prop.Name + ",");
                            keyWithAnnotation.Append("@" + prop.Name + ",");
                            data.Add($"@{prop.Name}", prop.GetValue(item));
                        }
                        else
                        {
                            MakeCommandAndDataListForInsert(prop.GetValue(item));
                        }


                    }
                    keys.Remove(keys.Length - 1, 1);
                    keyWithAnnotation.Remove(keyWithAnnotation.Length - 1, 1);


                    var command = @$"Insert into {tableName} ({keys}) values ( {keyWithAnnotation})";

                    commands.Add(command);
                    dataList.Add(data);
                }

                else
                {
                    foreach (object? i in (IEnumerable)item)
                    {
                        MakeCommandAndDataListForInsert(i);

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MakeCommandAndDataListForUpdate(object item)
        {
            try
            {
                var type = item.GetType();
                bool isList = (type != typeof(string) && typeof(IEnumerable).IsAssignableFrom(type));
                if (!isList)
                {
                    var tableName = type.Name;
                    var props = type.GetProperties();
                    StringBuilder keys = new StringBuilder();
                    StringBuilder keyWithAnnotation = new StringBuilder();
                    Dictionary<string, object> data = new Dictionary<string, object>();

                    foreach (var prop in props)
                    {
                        if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(Decimal) || prop.PropertyType == typeof(string))
                        {
                           
                            data.Add($"@{prop.Name}", prop.GetValue(item));
                            if (prop.Name=="Id") continue;
                            keys.Append($"{prop.Name} = @{prop.Name},");

                        }
                        else
                        {
                            MakeCommandAndDataListForUpdate(prop.GetValue(item));
                        }


                    }
                   keys.Remove(keys.Length-1,1);
                    var command = $"UPDATE {tableName} SET {keys} WHERE Id = @Id";
                    commands.Add(command);
                    dataList.Add(data);
                }
                else
                {
                    foreach (object? i in (IEnumerable)item)
                    {
                        MakeCommandAndDataListForUpdate(i);

                    }
                }


            }
            catch (Exception e)
            {

                throw;
            }
        }


    }
}
