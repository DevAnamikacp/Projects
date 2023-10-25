using System.Data;
using System.Data.SqlClient;

namespace TestProject.Models.Dal
{
    public class Save
    {
        public DataTable SelectbyReg(string reg)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("vDetailPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectbyre");
                da.SelectCommand.Parameters.AddWithValue("@regno", reg);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int insert(FineModdel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("FineDetaPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@RegNo", i.RegNo);
                cmd.Parameters.AddWithValue("@FineId", i.FineId);
                cmd.Parameters.AddWithValue("@FineAmount", i.FineAmount);
                cmd.Parameters.AddWithValue("@PoliceId", i.PoliceId);
                cmd.Parameters.AddWithValue("@PoliceInCharge", i.PoliceInCharge);
                cmd.Parameters.AddWithValue("@Location", i.Location);
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
        public string uPdate(FineModdel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("FineDetaPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@RegNo", i.RegNo);
                cmd.Parameters.AddWithValue("@FineId", i.FineId);
                cmd.Parameters.AddWithValue("@FineAmount", i.FineAmount);
                cmd.Parameters.AddWithValue("@PoliceId", i.PoliceId);
                cmd.Parameters.AddWithValue("@PoliceInCharge", i.PoliceInCharge);
                cmd.Parameters.AddWithValue("@Location", i.Location);
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public DataTable Selectbyvoi(string reg)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("VfinePro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selectviol");
                da.SelectCommand.Parameters.AddWithValue("@regno", reg);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable fineamou(int id)
        {
            Dbconnection db = new Dbconnection();
            SqlConnection conn = db.connection();
            SqlCommand cmd = new SqlCommand("VfinePro",conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@criteria", "selectfine");
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable Show()
        {
            Dbconnection db = new Dbconnection();
            SqlConnection conn = db.connection();
            SqlCommand cmd = new SqlCommand("FineDetaPro", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@criteria", "show");
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public DataTable edited(int id)
        {
            Dbconnection db = new Dbconnection();
            SqlConnection conn = db.connection();
            SqlCommand cmd = new SqlCommand("FineDetaPro", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@criteria", "edit");
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int delete(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("FineDetaPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "delete");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch(Exception ex) { throw; }
        }

    }
}

