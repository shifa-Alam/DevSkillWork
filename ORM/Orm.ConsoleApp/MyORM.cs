using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp
{
    public  class MyORM<T> where T : class
    {
        private string _connectionString;
        public MyORM(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("default");
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
        public IList<T> GetAll()
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand($"Select * from Rooms;", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                //while (rdr.Read())
                //{
                //    IList<T>.Add(new CountryModel
                //    {
                //        Id = Convert.ToInt32(rdr[0]),
                //        Country = rdr[1].ToString(),
                //        Active = Convert.ToBoolean(rdr[2])
                //    });
                //}
            }
            return null;
        }

    }
}
