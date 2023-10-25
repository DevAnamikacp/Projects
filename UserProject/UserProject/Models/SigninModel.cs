using System.Data;

namespace UserProject.Models
{
    public class SigninModel
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public int TypeId { get; set; }
        public string PhnNo { get; set; }
        public string Gender{ get; set; }
        public string Pswrd { get; set; }
        public string UserName{ get; set; }
        public string LastLogin{ get; set; }

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
