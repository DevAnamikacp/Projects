using System.Data;

namespace TestMaster.Models
{
    public class StateModel
    {
        public int Id { get; set; }
        public string CountryType { get; set; }
        public string State { get; set; }
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
