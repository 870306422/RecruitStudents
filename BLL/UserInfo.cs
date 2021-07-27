using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserInfo
    {
        DAL.UserInfo dal = new DAL.UserInfo();

        public DataTable SelectUserInfoToList(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            return dal.SelectUserInfoToList(where, pageIndex, PageSize, sort, out countNum);
        }
        #region 添加
        public int InsertUsers(Model.UserInfo model)
        {
            return dal.InsertUsers(model);
        }
        #endregion
        #region 删除
        public int DeleteUsers(Model.UserInfo model)
        {
            return dal.DeleteUsers(model);
        }
        #endregion
        #region 修改
        public int EditUsers(Model.UserInfo model)
        {
            return dal.EditUsers(model);
        }
        #endregion
        #region 角色查询
        public DataTable SelectUserTypeInfo(string where)
        {
            return dal.SelectUserTypeInfo(where);
        }
        #endregion
    }
}
