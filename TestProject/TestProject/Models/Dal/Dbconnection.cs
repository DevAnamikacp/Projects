using System.Data.SqlClient;
namespace TestProject.Models.Dal
{
    public class Dbconnection
    {
        public SqlConnection connection()
        {
            return new SqlConnection(ConnectionString);
        }
        public string ConnectionString
        {
            get
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nextree\OneDrive\Documents\VtypeDb.mdf;Integrated Security=True;Connect Timeout=30";
                return conn;
            }
        }
    }
}
