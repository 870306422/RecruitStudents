using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PowerToModule
    {
        public int? PMId { get; set; }
        public string PowerId { get; set; }
        public string ModuleId { get; set; }

        public string PowerName { get; set; }
        public int? Flag { get; set; }
    }
}
