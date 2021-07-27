using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PowerInfo
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();
        # region 分页查询UserInfo
        public DataTable SelectUserInfoToList(string where, int pageIndex, int pageSize, string sort, out int countNum)
        {
            string sql = "select * from ModuleInfo where 1=1 and Flag =1" + where;
            return db.QueryDataList(sql, pageSize, pageIndex, sort, out countNum);
        }
        #endregion
        #region 分页查询PowerInfo
        public DataTable SelectPowerInfoToList(string where, int pageIndex, int pageSize, string sort, out int countNum)
        {
            string sql = "select PowerID,PowerName,ModuleMeno, case Flag when '0' then '无效' else '有效'end as Flag   from PowerInfo  where 1=1 and Flag =1 " + where;
            return db.QueryDataList(sql, pageSize, pageIndex, sort, out countNum);
        }
        #endregion
        #region 删除
        public int DeletePower(Model.PowerInfo model)
        {
            string sql = "update PowerInfo set Flag = '0' where 1 = 1 and PowerID = '" + model.PowerID + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 增加
        public int InsertPower(Model.PowerInfo model)
        {
            string sql = "insert into PowerInfo (PowerName,ModuleMeno,Flag) values('" + model.PowerName+"','"+model.ModuleMeno+"',1)";
            return db.ExecuteNonQuery(sql);
        }
        #endregion

        #region 修改
        public int UpdatePower(Model.PowerInfo model)
        {
            string sql = "update PowerInfo set PowerName = '" + model.PowerName + "', ModuleMeno = '" + model.ModuleMeno + "' where PowerID = '" + model.PowerID + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion



    }
}
