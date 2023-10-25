using System.Data;

namespace TestProject.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string RegNo { get; set; }
        public string RegName { get; set; }
        public string Address { get; set; }
        public string PhnNo { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
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
    public class FineModdel
    {
        public int Id { get; set; }
        public string RegNo { get; set; }
        public int FineId { get; set; }
        public string FineAmount { get; set; }
        public string PoliceId { get; set; }
        public string PoliceInCharge { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
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

    public class VoilationModdel
    {
        public int Id { get; set; }
        public string Voilation { get; set; }
        public int Fine { get; set; }
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

