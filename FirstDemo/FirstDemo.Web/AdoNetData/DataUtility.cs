using Microsoft.Data.SqlClient;

namespace FirstDemo.Web.AdoNetData
{
    public class DataUtility
    {
        private readonly string _connectionString;
        public DataUtility(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ExecuteCommand(string sqlCommand, IList<(string key, object value)> parameters)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlCommand;

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(new SqlParameter(parameter.key, parameter.value));
                }
            }


            connection.Open();
            command.ExecuteNonQuery();

        }
    }
}
