using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace TeacherMaster.Models.Dal
{
    public class Mark
    {
        public DataTable SelecTreg(string Treg)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("TeacherPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectreg");
                da.SelectCommand.Parameters.AddWithValue("@teachreg", Treg);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
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
        public DataTable SelSub(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SubjPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectsub");
                //if (id != 0)
                //{
                    da.SelectCommand.Parameters.AddWithValue("@id", id);
                //}
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int insert(MarkModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("MarkPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@Teachid", i.TeachId);
                cmd.Parameters.AddWithValue("@subid", i.SubId);
                cmd.Parameters.AddWithValue("@classid", i.ClassId);
                //cmd.Parameters.AddWithValue("@mark", i.Mark);
                //cmd.Parameters.AddWithValue("@intmark", i.InMark);
                //cmd.Parameters.AddWithValue("@totmark", i.TotMark);
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
        public DataTable Show()
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("MarkPro", conn);
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
                SqlCommand cmd = new SqlCommand("MarkPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "edit");
                da.SelectCommand.Parameters.AddWithValue("@id", id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int update(MarkModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("MarkPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@Teachid", i.TeachId);
                cmd.Parameters.AddWithValue("@subid", i.SubId);
                cmd.Parameters.AddWithValue("@classid", i.ClassId);
                //cmd.Parameters.AddWithValue("@mark", i.Mark);
                //cmd.Parameters.AddWithValue("@intmark", i.InMark);
                //cmd.Parameters.AddWithValue("@totmark", i.TotMark);
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
        public int delete(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("MarkPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "delete");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch (Exception ex) { throw; }
        }
    }
}
