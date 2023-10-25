using System.Data;

namespace TestMaster.Models
{
    public class SignupModel
    {

        public int Id { get; set; }
        public int LoginId { get; set; }
        public int CountryType { get; set; }
        public int StateType { get; set; }
        public int DistrictType { get; set; }
        public int CityType { get; set; }
        public int BloodType { get; set; }
        public string PhnNo { get; set; }
        public string DoB { get; set; }
        public string Donnated { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PatientName { get; set; }
        public string Hospital { get; set; }
        public string Location { get; set; }
        public int BloodDonatedType { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
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

