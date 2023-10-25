using System.Data;

namespace TestMaster.Models
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
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

