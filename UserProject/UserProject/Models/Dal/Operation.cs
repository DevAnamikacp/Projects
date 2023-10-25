using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace UserProject.Models.Dal
{
    public class Operation
    {
        public DataTable Selctuser()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("UserPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectusrtype");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int insert(SigninModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@fname", i.Fname);
                cmd.Parameters.AddWithValue("@lname", i.Lname);
                cmd.Parameters.AddWithValue("@email", i.Email);
                cmd.Parameters.AddWithValue("@typeid", i.TypeId);
                cmd.Parameters.AddWithValue("@phno", i.PhnNo);
                cmd.Parameters.AddWithValue("@gender", i.Gender);
                cmd.Parameters.AddWithValue("@password", i.Pswrd);
                cmd.Parameters.AddWithValue("@username", i.Email);
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
            catch
            {
                throw;
            }
        }
        public DataTable chekk(SigninModel obj)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "checks");
                da.SelectCommand.Parameters.AddWithValue("@password", obj.Pswrd);
                da.SelectCommand.Parameters.AddWithValue("@username", obj.Email);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable Show()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "show");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable UShow( int userid)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "supersho");
                da.SelectCommand.Parameters.AddWithValue("@id", userid);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable SelecTDet(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectbyid");
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string blokk(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria","block");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int a=cmd.ExecuteNonQuery();
                conn.Close();
                return a.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public string unblokk(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "unblok");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                conn.Close();
                return a.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        public string Delete(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "delete");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                conn.Close();
                return a.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int lastlog(int userid)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "lastlog");
                cmd.Parameters.AddWithValue("@lastlogin", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", userid);
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
            catch
            {
                throw;
            }
        }
        public int updated(SigninModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@fname", i.Fname);
                cmd.Parameters.AddWithValue("@lname", i.Lname);
                cmd.Parameters.AddWithValue("@email", i.Email);
                cmd.Parameters.AddWithValue("@phno", i.PhnNo);
                cmd.Parameters.AddWithValue("@gender", i.Gender);
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Showusr()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "showusr");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    
}
