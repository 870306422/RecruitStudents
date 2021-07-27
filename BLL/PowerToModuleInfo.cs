using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PowerToModuleInfo
    {
        DAL.PowerToModuleInfo dal = new DAL.PowerToModuleInfo();
        #region 分页显示PowerToModule
        public DataTable SelectPowerToModuleInfo(string where)
        {
            return dal.SelectPowerToModuleInfo(where);
        }
        #endregion
        #region 通过权限组名字添加PowerToModule
        public int InsertPowerToModule(Model.PowerToModule powerToModule)
        {
            return dal.InsertPowerToModule(powerToModule);
        }
        #endregion
        #region 通过权限组ID添加PowerToModule
        public int InsertPowerToModule1(Model.PowerToModule powerToModule)
        {
            return dal.InsertPowerToModule1(powerToModule);
        }
        #endregion
        #region 删除PowerToModule
        public int DeletePowerToModule(Model.PowerToModule powerToModule)
        {
            return dal.DeletePowerToModule(powerToModule);
        }
        #endregion
    }
}
