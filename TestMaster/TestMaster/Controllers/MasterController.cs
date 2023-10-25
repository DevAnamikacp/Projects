using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestMaster.Models;
using TestMaster.Models.Dal;

namespace TestMaster.Controllers
{
    public class MasterController : Controller
    {
        private readonly IHttpContextAccessor contxt;

        public MasterController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Checked(TestModel i)
        {
            Operation o = new Operation();
            DataTable dt = o.chek(i);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                int z = Convert.ToInt32(dr["TYPE"]);
                int userid = Convert.ToInt32(dr["ID"]);
                // int cid = Convert.ToInt32(dr["CID"]);
                //string usrname = dr["USER_NAME"].ToString();
                //DataTable dt2 = o.SelecTDet(userid);
                //DataRow dr2 = dt2.Rows[0];
                contxt.HttpContext.Session.SetInt32("Id", userid);
                //contxt.HttpContext.Session.SetString("usrname", usrname);
                //contxt.HttpContext.Session.SetString("Country", dr2["COUNTRY_NAME"].ToString());
                //contxt.HttpContext.Session.SetString("State", dr2["STATE_NAME"].ToString());
                //contxt.HttpContext.Session.SetString("District", dr2["DISTRICT_NAME"].ToString());
                //contxt.HttpContext.Session.SetString("City", dr2["CITY_NAME"].ToString());
                //contxt.HttpContext.Session.SetString("Phno", dr2["PHN_NO"].ToString());
                //contxt.HttpContext.Session.SetString("dob", dr2["BIRTH_DATE"].ToString());
                //contxt.HttpContext.Session.SetString("Bloodgrp", dr2["BLOOD_GROUP"].ToString());
                //contxt.HttpContext.Session.SetString("Donner", dr2["DONNER"].ToString());
                o.lastlogin(userid);

                return Json(new { success = true, val = z, userid = userid });
            }
            else
            {
                int z = 0;
                return Json(new { success = false, val = z });
            }

        }
        public async Task<IActionResult> Country(CountryModel i)
        {
            Operation s = new Operation();
            int val = s.country(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> SelectCountry(string x)
        {
            Operation o = new Operation();
            DataTable dt = o.SelCount();
            String op = "";
            String sel;
            op += "<option value >select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";
                }

                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["COUNTRY_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> State(StateModel i)
        {
            Operation s = new Operation();
            int val = s.state(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> SelectState(string x, string id)
        {
            Operation s = new Operation();
            DataTable dt = s.SelState(id);
            String op = "";
            string sel;
            op += "<option value>select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";

                }
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["STATE_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> District(DistrictModel i)
        {
            Operation s = new Operation();
            int val = s.Distr(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> SelectDistrict(string x, string id)
        {
            Operation s = new Operation();
            DataTable dt = s.SelDist(id);
            String op = "";
            string sel;
            op += "<option value>select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";

                }
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["DISTRICT_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> City(CityModel i)
        {
            Operation s = new Operation();
            int val = s.city(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> SelCity(string x, string id)
        {
            Operation s = new Operation();
            DataTable dt = s.Selcity(id);
            String op = "";
            string sel;
            op += "<option value>select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";

                }
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["CITY_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }

        public async Task<IActionResult> CounShow()
        {
            try
            {
                Operation s = new Operation();
                DataTable ds = s.ConShow();
                string mp = "";
                mp += "<table style=\"width:800px\" border=2 class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<th>" + dc + "</th>";
                }
                mp += "</tr>";
                int count = 1;
                foreach (DataRow dr in ds.Rows)
                {
                    string id = dr["ID"].ToString();
                    mp += "<tr><td>" + count++ + "</td>";

                    foreach (DataColumn dc in ds.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            continue;
                        }
                        mp += "<td>" + dr[dc] + "</td>";
                    }
                    mp += "<td><button  class='btn btn-primary' type='button' value='DELETE' onclick='Deleted(" + id + ")'>DELETE</button></td>";

                }
                mp += "</tr></table>";
                return Json(new { success = mp });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> StateShow()
        {
            try
            {
                Operation s = new Operation();
                DataTable ds = s.StaShow();
                string mp = "";
                mp += "<table border=2   class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<th>" + dc + "</th>";
                }
                mp += "</tr>";
                int count = 1;
                foreach (DataRow dr in ds.Rows)
                {
                    string id = dr["ID"].ToString();
                    mp += "<tr><td>" + count++ + "</td>";
                    foreach (DataColumn dc in ds.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            continue;
                        }
                        mp += "<td>" + dr[dc] + "</td>";
                    }
                    mp += "<td><button class='btn btn-primary' type='button' value='DELETE' onclick='Deleted(" + id + ")'>DELETE</button></td>";
                }
                mp += "</tr></table>";
                return Json(new { success = mp });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> DistrictShow()
        {
            try
            {
                Operation s = new Operation();
                DataTable ds = s.DistShow();
                string mp = "";
                mp += "<table border=2  class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<th>" + dc + "</th>";
                }
                mp += "</tr>";
                int count = 1;
                foreach (DataRow dr in ds.Rows)
                {
                    string id = dr["ID"].ToString();
                    mp += "<tr><td>" + count++ + "</td>";

                    foreach (DataColumn dc in ds.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            continue;
                        }
                        mp += "<td>" + dr[dc] + "</td>";
                    }
                    mp += "<td><button class='btn btn-primary' type='button' value='DELETE' onclick='Deleted(" + id + ")'>DELETE</button></td>";
                }
                mp += "</tr></table>";
                return Json(new { success = mp });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> CityShow()
        {
            try
            {
                Operation s = new Operation();
                DataTable ds = s.cityShow();
                string mp = "";
                mp += "<table border=2  class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<th>" + dc + "</th>";
                }
                mp += "</tr>";
                int count = 1;
                foreach (DataRow dr in ds.Rows)
                {
                    string id = dr["ID"].ToString();
                    mp += "<tr><td>" + count++ + "</td>";
                    foreach (DataColumn dc in ds.Columns)
                    {
                        if (dc.ColumnName == "ID")
                        {
                            continue;
                        }
                        mp += "<td>" + dr[dc] + "</td>";
                    }
                    mp += "<td><button class='btn btn-primary' type='button' value='DELETE' onclick='Deleted(" + id + ")'>DELETE</button></td>";
                }
                mp += "</tr></table>";
                return Json(new { success = mp });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.Deleting(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Deleting(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.Deleted(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Delet(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.Delet(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Del(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.Del(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> SelectBldGrp(string x)
        {
            Operation o = new Operation();
            DataTable dt = o.SelBldGrp();
            String op = "";
            string sel;
            op += "<option value >select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";
                }
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["BLOOD_GROUP"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> SignInsert(SignupModel i)
        {
            Operation s = new Operation();
            int val = s.Insertlogin(i);
            contxt.HttpContext.Session.SetInt32("Id", val);
            i.LoginId = val;
            int x = s.Insertsign(i);
            return Json(new { success = true });
        }
        public async Task<IActionResult> selebyid(int id)
        {
            Operation o = new Operation();
            DataTable ds = o.SelecTDet(id);
            DataRow dr = ds.Rows[0];
            string cid = dr["CID"].ToString();
            string sid = dr["SID"].ToString();
            string did = dr["DID"].ToString();
            string citid = dr["DID"].ToString();
            string bldid = dr["BLDID"].ToString();
            DataTable dt = o.SelCount();

            String op = "";
            String sel;
            //  op += "<option value >select</select>";
            foreach (DataRow dr2 in dt.Rows)
            {
                if (dr2["ID"].ToString() == cid)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";
                }

                op += "<option value=" + dr2["ID"] + " " + sel + "> " + dr2["COUNTRY_NAME"] + "</option>";
            }
            DataTable dt1 = o.SelState(cid);
            String op1 = "";
            string sel1;
            foreach (DataRow dr3 in dt1.Rows)
            {
                if (dr3["ID"].ToString() == sid)
                {
                    sel1 = "selected";
                }
                else
                {
                    sel1 = "";

                }
                op1 += "<option value=" + dr3["ID"] + " " + sel1 + "> " + dr3["STATE_NAME"] + "</option>";
            }
            DataTable dt2 = o.SelDist(sid);
            String op2 = "";
            string sel2;
            foreach (DataRow dr4 in dt2.Rows)
            {
                if (dr4["ID"].ToString() == did)
                {
                    sel2 = "selected";
                }
                else
                {
                    sel2 = "";

                }
                op2 += "<option value=" + dr4["ID"] + " " + sel2 + "> " + dr4["DISTRICT_NAME"] + "</option>";
            }
            DataTable dt3 = o.Selcity(did);
            String op3 = "";
            string sel3;
            foreach (DataRow dr5 in dt3.Rows)
            {
                if (dr5["ID"].ToString() == citid)
                {
                    sel3 = "selected";
                }
                else
                {
                    sel3 = "";

                }
                op3 += "<option value=" + dr5["ID"] + " " + sel3 + "> " + dr5["CITY_NAME"] + "</option>";
            }
            DataTable dt4 = o.SelBldGrp();
            String op4 = "";
            string sel4;
            op += "<option value >select</select>";
            foreach (DataRow dr6 in dt4.Rows)
            {
                if (dr6["ID"].ToString() == bldid)
                {
                    sel4 = "selected";
                }
                else
                {
                    sel4 = "";
                }
                op4 += "<option value=" + dr6["ID"] + " " + sel4 + "> " + dr6["BLOOD_GROUP"] + "</option>";
            }
            return Json(new { country = op, state = op1, city = op3, district = op2, phno = dr["PHN_NO"], birthdate = dr["BIRTH_DATE"], blood = op4, donner = dr["DONNER"], name = dr["USER_NAME"] });
        }
        public async Task<IActionResult> show()
        {
            try
            {
                Operation o = new Operation();
                DataTable ds = o.Show();
                string mp = "";
                mp += "<table  class =\"table table-light\"><tr><th>SI NO</th>";
                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    if (dc.ColumnName == "TYPE")
                    {
                        continue;
                    }
                    mp += "<th>" + dc + "</th>";
                }
                mp += "</tr>";
                int count = 1;
                foreach (DataRow dr in ds.Rows)
                {
                    string id = dr["ID"].ToString();
                    string idd = dr["LOGIN_ID"].ToString();
                    string typeid = dr["TYPE"].ToString();
                    mp += "<tr><td>" + count++ + "</td>";

                    foreach (DataColumn dc in ds.Columns)
                    {

                        if (dc.ColumnName == "ID")
                        {
                            continue;
                        }
                        if (dc.ColumnName == "TYPE")
                        {
                            continue;
                        }
                        mp += "<td>" + dr[dc] + "</td>";
                    }
                    //a=Convert.ToInt32(dr["TYPE_ID"]);
                    if (Convert.ToInt32(dr["TYPE"]) == 3)
                    {
                        /*<td><button class='btn btn-primary' type='button' value='DELETE' onclick='Delete(" + id + ")'>DELETE</button></td>*/

                        mp += "<td><button class='btn btn-primary' type='button' value='UNBLOCK' onclick='Unblockusr(" + id + ")'>UNBLOCK</button></td>";
                    }
                    else if (Convert.ToInt32(dr["TYPE"]) == 1)
                    {
                        mp += "<td></td>";
                    }
                    else
                    {
                        mp += "<td><button class='btn btn-primary' type='button' value='BLOCK' onclick='Blockusr(" + id + ")'>BLOCK</button></td>";
                    }
                }
                mp += "</tr></table>";
                return Json(new { success = mp });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> blocked(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.blokk(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Deleted(int idd)
        {
            try
            {
                Operation o = new Operation();
                string val = o.Delete(idd);
                o.Dellog(idd);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> unblocked(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.unblokk(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Update(SignupModel i)
        {
            Operation s = new Operation();
            // int val = s.Updatelogin(i);
            int x = s.Updatesign(i);
            return Json(new { success = true });
        }
        public async Task<IActionResult> CheckName(TestModel i)
        {
            Operation o = new Operation();
            DataTable dt = o.chekname(i);
            int count = Convert.ToInt16(dt.Rows[0]["Username"]);
            if (count > 0)
            {
                //DataRow dr = dt.Rows[0];
                //string d =dr["USER_NAME"].ToString();
                return Json(new { success = true, val = "User already exists" });
            }
            else
            {

                return Json(new { success = false });
            }

        } 
      
        

     
        public async Task<IActionResult> SelectBldType(string x)
        {
            Operation o = new Operation();
            DataTable dt = o.SelBldTyp();
            String op = "";
            string sel;
            op += "<option value >select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    sel = "selected";
                }
                else
                {
                    sel = "";
                }
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["BLOOD_TYPES"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> LastDonatedInsert(SignupModel i)
        {
            Operation s = new Operation();
            int x = s.InsertLastDon(i);
            return Json(new { success = x });
        }
        public async Task<IActionResult> SearchDonner(SignupModel i )
        {
            Operation o = new Operation();
            DataTable dt = o.srchdonr(i);
            string mp = "";
            mp += "<table  class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                mp += "<th>" + dc + "</th>";
            }
            mp += "</tr>";
            int count = 1;
            foreach (DataRow dr in dt.Rows)
            {
               // string id = dr["ID"].ToString();
                mp += "<tr><td>" + count++ + "</td>";

                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<td>" + dr[dc] + "</td>";
                }
            }
            mp += "</tr></table>";
            return Json(new { success = mp });
        }     
        public async Task<IActionResult> UserDetailes(SignupModel i )
        {
            Operation o = new Operation();
            DataTable dt = o.userdet(i);
            string mp = "";
            mp += "<table  class =\"table table-head-fixed text-nowrap\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                mp += "<th>" + dc + "</th>";
            }
            mp += "</tr>";
            int count = 1;
            foreach (DataRow dr in dt.Rows)
            {
               // string id = dr["ID"].ToString();
                mp += "<tr><td>" + count++ + "</td>";

                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<td>" + dr[dc] + "</td>";
                }
            }
            mp += "</tr></table>";
            return Json(new { success = mp });
        }
        public async Task<IActionResult> Change(SignupModel i)
        {
            Operation s = new Operation();
            int val = s.ConfirmPsw(i);
            return Json(new { success = val });
        }     
        public async Task<IActionResult> Status(SignupModel i)
        {
            Operation s = new Operation();
            int val = s.Sstatus(i);
            return Json(new { success = val });
        }
    } 
}
        
 

