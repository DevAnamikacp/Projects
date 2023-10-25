using Microsoft.AspNetCore.Mvc;
using TeacherMaster.Models.Dal;
using TeacherMaster.Models;
using System.Data;

namespace TeacherMaster.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult>insert(TeacherModel i)
        {
            Teach s = new Teach();
            int x = s.inserted(i);
            return Json(new { success = x });
        }
        public async Task<IActionResult> Show()
        {
            Teach s = new Teach();
            DataTable dt = s.ShoW();
            string an = "";
            an += "<table class =\"table table-light\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                an += "<th>" + dc + "</th>";
            }
            an += "</tr>";
            int count = 1;
            foreach (DataRow dr in dt.Rows)
            {
                string id = dr["ID"].ToString();
                an += "<tr ondblclick=Edit(" + id + ")><td>" + count++ + "</td>";

                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    an += "<td>" + dr[dc] + "</td>";
                }
            }
            an += "</tr></table>";
            return Json(new { success = an });

        }
        public async Task<IActionResult>edit(int id)
        {
            Teach s = new Teach();
            DataTable dt = s.edited(id);
            DataRow dr = dt.Rows[0];
            return Json(new { id = dr["ID"], treg = dr["TEACH_REG"], tname = dr["TEACHER_NAME"], eml = dr["EMAIL"], phn = dr["PHN_NO"]});
        }
        public async Task<IActionResult> Updated(TeacherModel i)
        {

            Teach s = new Teach();
            int val = s.Updat(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> Delete(int id)
        {

            Teach s = new Teach();
            int val = s.del(id);
            return Json(new { success = val });
        }
    }
}
