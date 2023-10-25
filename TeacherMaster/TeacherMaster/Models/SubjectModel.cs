using System.Data;
namespace TeacherMaster.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string SubName { get; set; }
        public string SubCode { get; set; }
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
