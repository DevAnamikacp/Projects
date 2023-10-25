using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace TeacherMaster.Models.Dal
{
    public class Save : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public int insert(ClassModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("ClassPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@class", i.Class);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
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
                SqlDataAdapter da = new SqlDataAdapter("ClassPro", conn);
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
        public DataTable edit(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("ClassPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria","edit");
                da.SelectCommand.Parameters.AddWithValue("@id",id);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(Exception ex) 
            {
                throw;
            }
            
        }
        public int Updat(ClassModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("ClassPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@class", i.Class);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch(Exception ex) 
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
                SqlCommand cmd = new SqlCommand("ClassPro", conn);
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
