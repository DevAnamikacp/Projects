using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeacherMaster.Models;
using TeacherMaster.Models.Dal;

namespace TeacherMaster.Controllers
{
    public class MarkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Teachreg(string Treg)
        {
            Mark s = new Mark();
            DataTable ds = s.SelecTreg(Treg);
            DataRow dr = ds.Rows[0];
            return Json(new { tname = dr["TEACHER_NAME"], email = dr["EMAIL"], id = dr["ID"] });
        }
        public async Task<IActionResult> selCtlass(string x)
        {
            Mark s = new Mark();
            DataTable dt = s.SelClass();
            String op = "";
            string sel;

            //op += "<option value=''>select</option>";
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
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["CLASS"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> selCtsub(string x,int id)
        {
            Mark s = new Mark();
            DataTable dt = s.SelSub(id);
            String op = "";
            string sel;

            //op += "<option value=''>select</option>";
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
                op += "<option value=" + dr["ID"] + " " + sel + "> " + dr["SUB_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> Insert(MarkModel i)
        {
            Mark s = new Mark();
            int val = s.insert(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> show()
        {
            try
            {
                Mark s = new Mark();
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
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> edite(int id)
        {
            try
            {
                Mark s = new Mark();
                DataTable dt = s.edited(id);
                DataRow dr = dt.Rows[0];
                return Json(new { regno = dr["TEACH_REG"], clss = dr["CLASS_ID"], id = dr["ID"], sub = dr["SUB_ID"]});
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult> Update(MarkModel i)
        {

            Mark s = new Mark();
            int val = s.update(i);
            return Json(new { success = val });
        
        }
        public async Task<IActionResult> Delete(int id)
        {

            Mark s = new Mark();
            int val = s.delete(id);
            return Json(new { success = val });
        }

    }
}
