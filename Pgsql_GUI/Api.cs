using Npgsql;

namespace Pgsql_GUI
{
    public class Api
    {
        // static string _connString = "Server=localhost;Port=5432;User Id=postgres;Password=12345;Database=companyContracts";
        public NpgsqlConnection Connection;

        public Api(string userId, string password)
        {
            var connString = $"Server=localhost;Port=5432;User Id={userId};Password={password};Database=companyContracts";
            Connection = new NpgsqlConnection(connString);
            Connection.Open();
        }
    }
}