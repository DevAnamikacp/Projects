using System.Data;

namespace TeacherMaster.Models
{
    public class MarkModel
    {
        public int Id { get; set; }
        public int TeachId { get; set; }
       
        public int SubId { get; set; }
        public int ClassId { get; set; }
        public int Mark { get; set; }
        public int InMark { get; set; }
        public int TotMark { get; set; }

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
