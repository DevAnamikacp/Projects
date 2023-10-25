using System.Data;

namespace TeacherMaster.Models
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string Class { get; set; }
        private DataTable _dt;
        public DataTable dt
        {
            get
            {
                if (_dt == null)
                {
                    _dt = new DataTable();
                }
                return _dt;
            }
            set
            {
                _dt = dt;
            }
        }
    }
}
