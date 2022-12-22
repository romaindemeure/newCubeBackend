using MySql.Data.MySqlClient;

namespace newCubeBackend.Connection
{
    public class DBConnect
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "cubeSQL";
            string username = "cubeUser";
            string password = "rWjo0jpFuSpQwTQRM5n7Kg";

            // Connection String.
            string connString = "Server=" + host + ";Database=" + database
                                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
