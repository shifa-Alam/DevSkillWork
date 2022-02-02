using Microsoft.Extensions.Configuration;
using Orm.ConsoleApp.AdoDotNetCode;
using Orm.ConsoleApp.Entities;
using System;
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
            //_connectionString = configuration.GetConnectionString("default");
        }
        public void Insert(T item)
        {

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

            //IList<T> result = new List<T>();
            //using (SqlConnection con = new SqlConnection(_connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand($"Select * from {typeof(T)};", con);
            //    con.Open();
            //    SqlDataReader dataReader = cmd.ExecuteReader();


            //    T room = (T)Activator.CreateInstance(typeof(T));

            //    if (dataReader.HasRows)
            //    {
            //        while (dataReader.Read())
            //        {


            //            room.pr[0] = Convert.ToInt32(dataReader[0]);
            //            room.Rent = Convert.ToDouble(dataReader[1]);
            //            room.HouseId = Convert.ToInt32(dataReader[2]);

            //            result.Add(room);
            //        }
            //    }


            //}
            //return result;

            Dictionary<string, object> data = new Dictionary<string, object>();

            var command = @$"SELECT * FROM {tableName};";
            var dataUtility = new DataUtility(_connectionString);
            var Dbresult = dataUtility.GetData(command, data);

            List<T> result = new List<T>();
            foreach (var item in Dbresult)
            {
                //result.Add(item.k)
                var instance = (T)Activator.CreateInstance(typeof(T));
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
