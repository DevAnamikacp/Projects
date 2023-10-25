using System.Data.SqlClient;
using System.Data;

namespace TeacherMaster.Models.Dal
{
    public class Subj
    {
        public DataTable SelClass()
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("ClassPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectclass");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int insert(SubjectModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SubjPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria","insert");
                cmd.Parameters.AddWithValue("@classid", i.ClassId);
                cmd.Parameters.AddWithValue("@subname", i.SubName);
                cmd.Parameters.AddWithValue("@subcode", i.SubCode);
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
        public DataTable show()
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SubjPro", conn);
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
        public DataTable edited(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter ds = new SqlDataAdapter("SubjPro", conn);
                ds.SelectCommand.CommandType = CommandType.StoredProcedure;
                ds.SelectCommand.Parameters.AddWithValue("@criteria", "edit");
                ds.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                ds.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public int Update(SubjectModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SubjPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@classid", i.ClassId);
                cmd.Parameters.AddWithValue("@subname", i.SubName);
                cmd.Parameters.AddWithValue("@subcode", i.SubCode);
                cmd.Parameters.AddWithValue("@id", i.Id);
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
        public int Delete(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SubjPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "delete");
                cmd.Parameters.AddWithValue("@id", id);
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
    }
}
