using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StudentinfoModel
    {
        public int? SourceIId { get; set; }
        public string STUName { get ;set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public string Did { get; set; }
        public string EditOutTime { get; set; }
        public int? ScoreCrosses { get; set; }
        public int? WhetherAccept { get; set; }
        public int? WhetherPrepare { get; set; }
        public int? TeacherId { get; set; }
        public int? QQId { get; set; }
        public int? PhoneID { get; set; }
        public int? Academyid { get; set; }
        public int? NoteInfo { get; set; }
        public int? ActualScore { get; set; }
        public string ScoreSegment { get; set; }
    }
}
