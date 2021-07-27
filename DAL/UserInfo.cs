using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserInfo
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();

        public DataTable SelectUserInfoToList(string where, int pageIndex, int PageSize, string sort, out int countNum)
        {
            string sql = "select a.*,b.TypeName from UsersInfo a left join UserTypeInfo b on a.UserType = b.TypeId where 1=1 and a.Flag =1" + where;
            return db.QueryDataList(sql, PageSize, pageIndex, sort, out countNum);
        }
        #region 添加
        public int InsertUsers(Model.UserInfo model)
        {
            string sql = "insert into UsersInfo values('" + model.UserName + "','" + model.UserSex + "','" + model.UserType + "','" + model.UserAge + "','" + model.Flag + "')";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 删除
        public int DeleteUsers(Model.UserInfo model)
        {
            string sql = "update UsersInfo set Flag = '0' where 1 = 1 and UserId = '" + model.UserId + "'" ;
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 修改
        public int EditUsers(Model.UserInfo model)
        {
            string sql = "update UsersInfo set UserName = '"+model.UserName+"', UserSex = '"+model.UserSex+"', UserType = '"+model.UserType+"', UserAge = '"+model.UserAge+"', Flag = '"+model.Flag  + "'where 1 = 1 and UserId = '" + model.UserId + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 角色查询
        public DataTable SelectUserTypeInfo(string where)
        {
            string sql = "select * from UsersInfo where 1=1"+where;
            return db.ExecuteQuery(sql);
        }
        #endregion

    }
}
