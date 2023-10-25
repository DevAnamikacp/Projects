using System.Data;
namespace TestMaster.Models
{
    public class TestModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public string LastLogin { get; set; }

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
