using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PersonnelInformation
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();
        #region 人员信息表
        public DataTable selectPersonnelInformationToList(string where,int PageSize ,int PageIndex, string sort,out int common)
        {
            string sql = "select PIid, PIName, PIUser, PIpwd,case PISex when '1' then '男' else '女' end as PISex ,PIAccount,Flag from PersonnelInformation where Flag = 1"+where;
            return db.QueryDataList(sql, PageSize, PageIndex, sort, out common);
        }
        #endregion
        #region 增加
        public int Userinsert(Model.PersonnelInformation personnelInformation)
        {
            string sql = "insert into PersonnelInformation(PIName,PIUser,PIpwd,PISex,PIAccount,Flag) values('"+personnelInformation.PIName+"','"+personnelInformation.PIUser+"','"+personnelInformation.PIpwd+"','"+personnelInformation.PISex+"','"+personnelInformation.PIAccount+"',1)";
            return db.ExecuteNonQuery(sql);
        }
        public int UserEdit(Model.PersonnelInformation personnelInformation)
        {
            string sql = "update PersonnelInformation set PIpwd = '" + personnelInformation.PIpwd + "',PIName='"+personnelInformation.PIName+ "',PIUser='"+personnelInformation.PIUser+ "',PISex='"+personnelInformation.PISex+"' ,PIAccount='"+personnelInformation.PIAccount+"' where Flag =1 and PIid = '" + personnelInformation.PIid + "'";
            return db.ExecuteNonQuery(sql);
        }
        public DataTable SelectHead(string where)
        {
            string sql = "select * from PowerInfo where 1=1" + where;
            return db.ExecuteQuery(sql);
        }
        #endregion
        #region 人员登录
        public DataTable DL(string where)
        {
            string sql = "select a.*,b.PowerName from PersonnelInformation a left join PowerInfo b on a.PIAccount = b.PowerID where  a.Flag = 1"+ where;
            return db.ExecuteQuery(sql);
        }
        #endregion
        #region 删除人员
        public int DeletePI(Model.PersonnelInformation personnelInformation)
        {
            string sql = "update PersonnelInformation set Flag = '0' where 1 = 1 and PIid = '" + personnelInformation.PIid+ "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 添加PI(
        public int InsertPI(Model.PersonnelInformation personnelInformation)
        {
            string sql = "insert into PersonnelInformation(PIName, PIUser, PIpwd, PISex, PIAccount, Flag) values('"+ personnelInformation.PIName+ "', '"+personnelInformation.PIUser+"', '"+personnelInformation.PIpwd+"', "+personnelInformation.PISex+", "+personnelInformation.PIAccount+", 1)";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 修改PIPwd(
        public int EditPIPwd(Model.PersonnelInformation personnelInformation)
        {
            string sql = "update PersonnelInformation set PIpwd = '"+personnelInformation.PIpwd+"' where Flag =1 and PIid = '"+personnelInformation.PIid+"'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
    }
}
