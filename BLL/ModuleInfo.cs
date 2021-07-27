using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ModuleInfo
    {
        DAL.ModuleInfo dal = new DAL.ModuleInfo();
        //下拉框查询
        public DataTable SelectModuleInfo(string where)
        {
            return dal.SelectModuleInfo(where);
        }
       
        public DataTable SelectModuleInfo1(string where)
        {
            return dal.SelectModuleInfo1(where);
        }
        public DataTable SelectModuleInfo2(string powerId)
        {
            return dal.SelectModuleInfo2(powerId);
        }
        //分页显示
        public DataTable SelectModuleInfoList(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectModuleInfoList(where, pageIndex, PageSize, sort, out countNum);
        }//分页显示
        public DataTable SelectModuleInfoList1(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectModuleInfoList1(where, pageIndex, PageSize, sort, out countNum);
        }
        #region 删除
        public int DeleteUsers(Model.ModuleInfo model)
        {
            return dal.DeleteUsers(model);
        }
        #endregion
        #region 添加
        public int InsertUsers(Model.ModuleInfo model)
        {
            return dal.InsertUsers(model);
        }
        #endregion
        #region 修改
        public int EditUsers(Model.ModuleInfo model)
        {
            return dal.EditUsers(model);
        }
        #endregion
    }
}
