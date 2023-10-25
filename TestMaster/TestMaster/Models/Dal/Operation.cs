using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace TestMaster.Models.Dal
{
    public class Operation
    {
        public DataTable chek(TestModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("LoginPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "check");
                da.SelectCommand.Parameters.AddWithValue("@username", i.UserName);
                da.SelectCommand.Parameters.AddWithValue("@password", i.Password);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int country(CountryModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("CountryPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insert");
                cmd.Parameters.AddWithValue("@country", i.Country);
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
        public DataTable SelCount()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("CountryPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "countrysel");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public int state(StateModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("StatePro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertstate");
                cmd.Parameters.AddWithValue("@countrytype", i.CountryType);
                cmd.Parameters.AddWithValue("@state", i.State);
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
        public DataTable SelState(string id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("DistrictPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "StateSel");
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
        public int Distr(DistrictModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("DistrictPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertdistrict");
                cmd.Parameters.AddWithValue("@statetype", i.StateType);
                cmd.Parameters.AddWithValue("@district", i.District);
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
        public DataTable SelDist(string id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("CityPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "DistrictSel");
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
        public int city(CityModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("CityPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertcity");
                cmd.Parameters.AddWithValue("@districtype", i.DistrictType);
                cmd.Parameters.AddWithValue("@city", i.City);
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
        public DataTable Selcity(string id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignupPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "CitySel");
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
        public int lastlogin(int userid)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LoginPro", conn);
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
        public DataTable ConShow()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("CountryPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "showcountry");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable StaShow()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("StatePro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "ShowState");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public DataTable DistShow()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("DistrictPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "ShowDistrict");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public DataTable cityShow()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("CityPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "ShowCity");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string Deleting(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("CityPro", conn);
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
        public string Deleted(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("DistrictPro", conn);
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
        public string Delet(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("StatePro", conn);
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
        public string Del(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("CountryPro", conn);
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
        public DataTable SelBldGrp()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignupPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "bldgrpsel");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        } 
      
        public int Insertsign(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertsigndet");
                cmd.Parameters.AddWithValue("@countrytype", i.CountryType);
                cmd.Parameters.AddWithValue("@statetype", i.StateType);
                cmd.Parameters.AddWithValue("@districtype", i.DistrictType);
                cmd.Parameters.AddWithValue("@citytype", i.CityType);
                cmd.Parameters.AddWithValue("@phnno", i.PhnNo);
                cmd.Parameters.AddWithValue("@bloodtype", i.BloodType);
                cmd.Parameters.AddWithValue("@dob", i.DoB);
                cmd.Parameters.AddWithValue("@donnate", i.Donnated);
                cmd.Parameters.AddWithValue("@loginid", i.LoginId);
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
        public int Insertlogin(SignupModel a)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LoginPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertlogin");
                cmd.Parameters.AddWithValue("@username", a.UserName);
                cmd.Parameters.AddWithValue("@password", a.Password);
                cmd.Parameters.AddWithValue("@type", 2);
                cmd.Parameters.Add(new SqlParameter("@NewID", SqlDbType.BigInt, 16, ParameterDirection.InputOutput, 0, 0, "", DataRowVersion.Original, false, null, "", "", ""));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                int LogID = Convert.ToInt32(cmd.Parameters["@NewID"].Value);
                return LogID;
            }
            catch
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
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "selctdet");
                da.SelectCommand.Parameters.AddWithValue("@loginid", id);
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
                SqlDataAdapter da = new SqlDataAdapter("SignupPro", conn);
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
        public string blokk(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "block");
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
        public string unblokk(int id)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
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
        public string Delete(int idd)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "deletesign");
                cmd.Parameters.AddWithValue("@id", idd);
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
        public string Dellog(int idd)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "deletelog");
                cmd.Parameters.AddWithValue("@id", idd);
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
        public int Updatesign(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("SignupPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "updatesigndet");
                cmd.Parameters.AddWithValue("@countrytype", i.CountryType);
                cmd.Parameters.AddWithValue("@statetype", i.StateType);
                cmd.Parameters.AddWithValue("@districtype", i.DistrictType);
                cmd.Parameters.AddWithValue("@citytype", i.CityType);
                cmd.Parameters.AddWithValue("@phnno", i.PhnNo);
                cmd.Parameters.AddWithValue("@bloodtype", i.BloodType);
                cmd.Parameters.AddWithValue("@dob", i.DoB);
                cmd.Parameters.AddWithValue("@donnate", i.Donnated);
                //  cmd.Parameters.AddWithValue("@id", i.Id);
                cmd.Parameters.AddWithValue("@loginid", i.LoginId);
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
        public int Updatelogin(SignupModel a)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LoginPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "updatelogin");
                cmd.Parameters.AddWithValue("@username", a.UserName);
                //  cmd.Parameters.AddWithValue("@password", a.Password);
                cmd.Parameters.AddWithValue("@id", a.Id);
                cmd.Parameters.AddWithValue("@type", 2);
                conn.Open();
                int ab = cmd.ExecuteNonQuery();
                conn.Close();
                return ab;
            }
            catch
            {
                throw;
            }
        }
        public DataTable chekname(TestModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("LoginPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "checkname");
                da.SelectCommand.Parameters.AddWithValue("@username", i.UserName);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable SelBldTyp()
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("LastDonatePro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "blddonatedsel");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
      
        public int InsertLastDon(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LastDonatePro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "insertlastdon");
                cmd.Parameters.AddWithValue("@PatientName", i.PatientName);
                cmd.Parameters.AddWithValue("@hostital", i.Hospital);
                cmd.Parameters.AddWithValue("@location", i.Location);
                cmd.Parameters.AddWithValue("@blooddonatedtype", i.BloodDonatedType);
                cmd.Parameters.AddWithValue("@date", i.Date);
                cmd.Parameters.AddWithValue("@loginid", i.LoginId);
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
        public DataTable srchdonr(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("SignupPro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "searchDonr");
                da.SelectCommand.Parameters.AddWithValue("@countrytype", i.CountryType);
                da.SelectCommand.Parameters.AddWithValue("@statetype", i.StateType);
                da.SelectCommand.Parameters.AddWithValue("@districtype", i.DistrictType);
                da.SelectCommand.Parameters.AddWithValue("@citytype", i.CityType);
                da.SelectCommand.Parameters.AddWithValue("@bloodtype", i.BloodType);
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch
            {
                throw;
            }
        }    
        public DataTable userdet(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlDataAdapter da = new SqlDataAdapter("LastDonatePro", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@criteria", "donnatrs");
                DataTable ds = new DataTable();
                da.Fill(ds);
                return ds;
            }
            catch
            {
                throw;
            }
        }
        public int ConfirmPsw(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LoginPro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria","change");
                cmd.Parameters.AddWithValue("@username", i.UserName);
                cmd.Parameters.AddWithValue("@password", i.Password);
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
        public int Sstatus(SignupModel i)
        {
            try
            {
                Dbconnection db = new Dbconnection();
                SqlConnection conn = db.connection();
                SqlCommand cmd = new SqlCommand("LastDonatePro", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@criteria", "status");
                cmd.Parameters.AddWithValue("@status", i.Status);
                cmd.Parameters.AddWithValue("@loginid", i.LoginId);
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
