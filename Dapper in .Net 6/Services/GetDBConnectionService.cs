using System.Data;
using System.Data.SqlClient;

namespace Dapper_in_.Net_6.Services
{
    public class GetDBConnectionService
    {
        private IConfiguration _configuration;
        private SqlConnection connection;

        public GetDBConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection OpenConnection()
        {
            try
            {
                string connectionString = _configuration.GetConnectionString("MyDBConnection");
                this.connection = new SqlConnection(connectionString);
                this.connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (this.connection.State == ConnectionState.Open)
                {
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
