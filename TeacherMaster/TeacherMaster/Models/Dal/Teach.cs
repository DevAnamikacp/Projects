using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace TeacherMaster.Models.Dal
{
    public class Teach : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public int inserted(TeacherModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("TeacherPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@teachreg", i.Treg);
                cmd.Parameters.AddWithValue("@teachname", i.TName);
                cmd.Parameters.AddWithValue("@email", i.Email);
                cmd.Parameters.AddWithValue("@phnno", i.Phno);
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

        public DataTable ShoW()
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("TeacherPro", conn);
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
                SqlCommand cmd = new SqlCommand("TeacherPro", conn);
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
        public int Updat(TeacherModel i)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("TeacherPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "update");
                cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@teachreg", i.Treg);
                cmd.Parameters.AddWithValue("@teachname", i.TName);
                cmd.Parameters.AddWithValue("@email", i.Email);
                cmd.Parameters.AddWithValue("@phnno", i.Phno);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public int del(int id)
        {
            try
            {
                DbConnection db = new DbConnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("TeacherPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "delete");
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                conn.Close();
                return x;
            }
            catch (Exception ex) 
            { 
                throw; 
            }
        }

    }
}
