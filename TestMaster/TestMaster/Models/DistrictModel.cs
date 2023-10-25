using System.Data;

namespace TestMaster.Models
{
    public class DistrictModel
    {
        public int Id { get; set; }
        public string CountryType { get; set; }
        public string StateType { get; set; }
        public string District{ get; set; }
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
