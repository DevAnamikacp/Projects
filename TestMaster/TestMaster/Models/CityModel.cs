using System.Data;

namespace TestMaster.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string CountryType { get; set; }
        public string StateType { get; set; }
        public string DistrictType { get; set; }
        public string City { get; set; }
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

