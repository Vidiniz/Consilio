using System.Data.SqlClient;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessContext
{
    public class DataSQLConnection
    {
        private DataSQLConnection()
        {
        }

        private const string ConnectionString = "Server=localhost\\SQLExpress; Database=DBConsilio;Trusted_Connection = True";

        private static SqlConnection _connection;

        public static SqlConnection GetConnection()
        {
            if (_connection.Equals(null))
                return _connection = new SqlConnection(ConnectionString);
            else
                return _connection;
        }
    }
}
