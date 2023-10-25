using System.Data;
using Microsoft.AspNetCore.Mvc;
using TeacherMaster.Models;
using TeacherMaster.Models.Dal;

namespace TeacherMaster.Controllers
{
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> inser(ClassModel i)
        {
            Save s = new Save();
            int x = s.insert(i);
            return Json(new { success = x });
        }
        public async Task<IActionResult> show()
        {
            Save s = new Save();
            DataTable dt = s.Show();
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
        public async Task<IActionResult> edited(int id)
        {
            Save s = new Save();
            DataTable dt = s.edit(id);
            DataRow dr = dt.Rows[0];
            return Json(new { id = dr["ID"], lass = dr["CLASS"] });
        }
        public async Task<IActionResult> Updated(ClassModel i)
        {
            
                Save s = new Save();
                int val = s.Updat(i);
                return Json(new { success = val }); 
        }
        public async Task<IActionResult> Delete(int id)
        {
            Save s = new Save();
            int x = s.delete(id);
            return Json(new { success = x });


        }
    }
}
