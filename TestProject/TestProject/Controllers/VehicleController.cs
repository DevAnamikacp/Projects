using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestProject.Models;
using TestProject.Models.Dal;

namespace TestProject.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>Reg(string reg)
        {
            Save s = new Save();
            DataTable ds = s.SelectbyReg(reg);
            DataRow dr = ds.Rows[0];
            return Json(new { regname = dr["REG_NAME"], addres = dr["ADDRESS"], phon = dr["PHN_NO"], eml = dr["EMAIL"] });
        }
        public async Task<IActionResult> voilatio(string reg, string x)
        {
            Save s=new Save();
            DataTable dt=s.Selectbyvoi(reg);
            string op = "";
            op += "<option>select</option>";
            string selected = "";
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["ID"].ToString() == x)
                {
                    selected = "selected";
                }
                else
                {
                    selected = "";
                }
                op += "<option value='" + dr["ID"] + "'"+selected+">" + dr["voilation"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> finamount(int id)
        {
            Save s = new Save();
            DataTable dt = s.fineamou(id);
            DataRow dr = dt.Rows[0];            
            string mp = dr["FINE"].ToString();
            return Json(new { success = mp });
        }
        public async Task<IActionResult> Insert(FineModdel i)
        {
            Save s = new Save();
            int val =s.insert(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> update(FineModdel i)
        {
            try
            {
                Save s = new Save();
                string val = s.uPdate(i);
                return Json(new { success = val });
            } 
        
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> edit(int id)
        {
            Save s = new Save();
            DataTable dt = s.edited(id);
            DataRow dr1 = dt.Rows[0];           
            return Json(new { id=dr1["ID"],regno = dr1["REG_NO"], fine = dr1["FINE_ID"], finamo = dr1["FINE"], date = dr1["DATE"], locat = dr1["LOCATION"], polna = dr1["POLICE_IN_CHARGE"], polid = dr1["POLICE_ID"] });

        }
        public async Task<IActionResult> show()
        {
            Save s = new Save();
            DataTable ds = s.Show();
            string mp = "";
            mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
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
                mp += "<tr ondblclick=Edit(" + id + ")><td>" + count++ + "</td>";

                foreach (DataColumn dc in ds.Columns)
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
        public async Task<IActionResult> Delete(int id)
        {
            Save s = new Save();
            int x=s.delete(id);
            return Json(new {success=x});


        }
    }
}