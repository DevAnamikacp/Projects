using System.Data;
namespace TeacherMaster.Models
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Treg { get; set; }
        public string TName { get; set;}
        public string Email { get; set;}
        public string Phno { get; set;}
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
