using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Temporarytransfer
    {
        private int? ttId;
        private int? stuName;
        private int? secondSchool;
        private int? flag;

        public int? TtId { get => ttId; set => ttId = value; }
        public int? StuName { get => stuName; set => stuName = value; }
        public int? SecondSchool { get => secondSchool; set => secondSchool = value; }
        public int? Flag { get => flag; set => flag = value; }
    }
}
