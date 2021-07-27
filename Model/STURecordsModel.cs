using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class STURecordsModel
    {
        private int? rID;
        private int? rName;
        private int? studentId;
        private DateTime rTime;
        private string recs;

        public int? RID { get => rID; set => rID = value; }
        public int? RName { get => rName; set => rName = value; }
        public int? StudentId { get => studentId; set => studentId = value; }
        public DateTime RTime { get => rTime; set => rTime = value; }
        public string Recs { get => recs; set => recs = value; }
    }
  
}
