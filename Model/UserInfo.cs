using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int? UserId
        {
            get; set;
        }

        public string UserName { get; set; }
        public int UserAge { get; set; }
        public int? UserSex { get; set; }
        public int? UserType { get; set; }
        public int? Flag { get; set; }
    }
}
