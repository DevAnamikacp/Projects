using Microsoft.AspNetCore.Mvc;
using System.Data;
using TeacherMaster.Models;
using TeacherMaster.Models.Dal;

namespace TeacherMaster.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> selClass(string x)
        {
            Subj s = new Subj();
            DataTable dt = s.SelClass();
            String op = "";
            string sel;

            op += "<option>select</option>";
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
        public async Task<IActionResult>Insert(SubjectModel i)
        {
            Subj s = new Subj();
            int val = s.insert(i);
            return Json(new { success = val });

        }
        public async Task<IActionResult> show()
        {
            Subj s = new Subj();
            DataTable ds = s.show();
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
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Subj s = new Subj();
                DataTable dt = s.edited(id);
                DataRow dr = dt.Rows[0];
                return Json(new { code = dr["SUB_CODE"], name = dr["SUB_NAME"], idd = dr["ID"], cls = dr["CLASS_ID"] });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IActionResult>updated(SubjectModel i)
        {
            try
            {
                Subj s = new Subj();
                int val = s.Update(i);
                return Json(new { success = val });
            }
            catch
            {
                throw;
            }
        }
        public async Task<IActionResult> Deleted(int id)
        {
            try
            {
                Subj s = new Subj();
                int val = s.Delete(id);
                return Json(new { success = val });
            }
            catch
            {
                throw;
            }
        }
    }
}
