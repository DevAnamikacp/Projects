using System.Data.SqlClient;
namespace UserProject.Models.Dal
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
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nextree\OneDrive\Documents\UserDb.mdf;Integrated Security=True;Connect Timeout=30";
                return conn;
            }
        }
    }
}
