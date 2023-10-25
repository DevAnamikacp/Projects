using System.Data.SqlClient;
namespace TeacherMaster.Models.Dal
{
    public class DbConnection
    {
        public SqlConnection connection()
        {
            return new SqlConnection(ConnectionString);

        }
        public string ConnectionString
        {
            get
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nextree\OneDrive\Documents\TeacherDb.mdf;Integrated Security=True;Connect Timeout=30";
                return conn;
            }
        }
    }
}
