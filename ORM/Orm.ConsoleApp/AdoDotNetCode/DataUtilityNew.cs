﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orm.ConsoleApp.AdoDotNetCode
{
    public class DataUtilityNew
    {
        private readonly string _connectionString;

        public DataUtilityNew(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ExecuteCommand(string sqlCommand, IDictionary<string, object> parameters)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
            }


            connection.Open();
            command.ExecuteNonQuery();

        }
        public IEnumerable<IDictionary<string, object>> GetData(string sqlCommand, IDictionary<string, object> parameters)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;

            if (parameters != null)
            {

                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
            }


            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            List<IDictionary<string, object>> data = new List<IDictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                foreach (var col in reader.GetColumnSchema())
                {
                    row.Add(col.ColumnName, reader[col.ColumnName]);
                }
                data.Add(row);
            }

            return data;
        }
    }
}
