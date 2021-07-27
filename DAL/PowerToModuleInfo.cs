using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PowerToModuleInfo
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();
        #region 分页显示PowerToModule
        public DataTable SelectPowerToModuleInfo(string where)
        {
            string sql = "select * from PowerToModuleInfo where Flag = 1"+where;
            return db.ExecuteQuery(sql);
        }
        #endregion
        #region 添加PowerToModule
        public int InsertPowerToModule(Model.PowerToModule powerToModule)
        {
            string sql = "insert into PowerToModuleInfo (PowerId,ModuleId,Flag) values((select PowerID from PowerInfo where PowerName = '" + powerToModule.PowerName + "'),'" + powerToModule.ModuleId + "',1)";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 添加PowerToModule
        public int InsertPowerToModule1(Model.PowerToModule powerToModule)
        {
            string sql = "insert into PowerToModuleInfo (PowerId,ModuleId,Flag) values('"+powerToModule.ModuleId+"','" + powerToModule.ModuleId + "',1)";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 删除PowerToModule
        public int DeletePowerToModule(Model.PowerToModule powerToModule)
        {
            string sql = "delete from PowerToModuleInfo where PowerId = (select PowerID from PowerInfo where PowerName = '" + powerToModule.PowerName + "')";
            string sql1 = "delete PowerToModuleInfo where PowerId = (select PowerID from PowerInfo where PowerName = '" + powerToModule.PowerName + "')";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
