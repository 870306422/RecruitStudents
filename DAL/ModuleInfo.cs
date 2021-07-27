using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ModuleInfo
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();
        //下拉框查询
        public DataTable SelectModuleInfo(string where)
        {
            string sql = "select Mid, ModuleName, ModuleUrl, ModuleIcon, ModuleMeno,case Flag when '0' then '无效' else '有效'end as Flag  from ModuleInfo where 1 = 1  and Flag = 1" + where;
            return db.ExecuteQuery(sql);
        }

       
        public DataTable SelectModuleInfo1(string where)
        {
            string sql = "select * from ModuleInfo where Flag = 1 " + where;
            return db.ExecuteQuery(sql);
        }
        public DataTable SelectModuleInfo2(string powerId)
        {
            string sql = "select a.*,b.ModuleIcon,b.ModuleUrl,b.ModuleName from PowerToModuleInfo a left join ModuleInfo b on a.ModuleId = b.MId where a.Flag = '1' and a.PowerId = '" + powerId + "'";
            return db.ExecuteQuery(sql);
        }
        //分页显示
        public DataTable SelectModuleInfoList(string where, int pageIndex, int pageSize, string sort, out int countNum)
        {
            //string sql = "select Mid, ModuleName, ModuleUrl, ModuleIcon, ModuleMeno,case Flag when '0' then '无效' else '有效'end as Flag  from ModuleInfo where 1 = 1 " + where;
            string sql = "select Mid, ModuleName, ModuleUrl, ModuleIcon, ModuleMeno,case Flag when '0' then '无效' else '有效'end as Flag  from ModuleInfo where 1 = 1 "+where;
            return db.QueryDataList(sql, pageSize, pageIndex, sort, out countNum);
        }
        //分页显示
        public DataTable SelectModuleInfoList1(string where, int pageIndex, int pageSize, string sort, out int countNum)
        {
            string sql = "select Mid, ModuleName, ModuleUrl, ModuleIcon, ModuleMeno,case Flag when '0' then '无效' else '有效'end as Flag  from ModuleInfo where 1 = 1 and Flag = 1" + where;
            return db.QueryDataList(sql, pageSize, pageIndex, sort, out countNum);
        }
        #region 显示
        #endregion
        #region 删除
        public int DeleteUsers(Model.ModuleInfo model)
        {
            string sql = "update ModuleInfo set Flag = '0' where 1 = 1 and Mid = '" + model.Mid + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 添加
        public int InsertUsers(Model.ModuleInfo model)
        {
            string sql = "insert into ModuleInfo(ModuleName, ModuleUrl, ModuleIcon, ModuleMeno, Flag) values('"+model.ModuleName+"', '"+model.ModuleUrl+"', '"+model.ModuleIcon+"', '"+model.ModuleMeno+"', '1')";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 修改
        public int EditUsers(Model.ModuleInfo model)
        {
            string sql = "update ModuleInfo set ModuleName = '"+model.ModuleName+"', ModuleUrl = '"+model.ModuleUrl+"', ModuleIcon = '"+model.ModuleIcon+"', ModuleMeno = '"+model.ModuleMeno+"' where 1 = 1 and Mid = '"+model.Mid+"'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
