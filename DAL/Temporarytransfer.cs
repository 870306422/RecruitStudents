using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Temporarytransfer
    {
        DBHelp.DBHelper db = new DBHelp.DBHelper();
        #region 查询转院记录
        //public DataTable SelectTemporarytransfer(string where)
        //{
        //    string sql = "select * from Temporarytransfer where Flag = 1" + where;
        //    return db.ExecuteQuery(sql);
        //}
        #endregion
        #region 查询转院记录
        public DataTable SelectName(string str)
        {
            string sql = "select * from StudentInfoT where 1=1"+str;
            return db.ExecuteQuery(sql);
        }
        public DataTable SelectTemporarytransfer(Model.PersonnelInformation model)
        {
            string sql = "select * from Temporarytransfer where Teacher = '" + model.PIid + "'";
            return db.ExecuteQuery(sql);
        }
        #endregion
        #region 确认接收数据
        public int saveconfirm(Model.Temporarytransfer temporarytransfer)
        {
            string sql = "update StudentInfoT set Academyid = '" + temporarytransfer.StuName + "' where StudentID = '" + temporarytransfer.TtId + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        #region 转院显示咨询数据
        public DataTable TurnZXSJToList(string where, int PageIndex, int PageSize, string sort, out int commun)
        {
            string sql = "select b.StudentID,a.TtId,a.SecondSchool,b.STUName,c.AName,d.PIid from Temporarytransfer a left join StudentInfoT b on a.StuName=b.StudentID left join Academy c on a.StuName=c.AId left join PersonnelInformation d on d.PIid = a.Teacher where a.Flag = 1" + where;
            return db.QueryDataList(sql, PageSize, PageIndex, sort, out commun);
        }
        #endregion
        #region 删除缓存数据
        public int savedelete(Model.Temporarytransfer temporarytransfer)
        {
            string sql = "delete from Temporarytransfer where TtId = '" + temporarytransfer.TtId + "'";
            return db.ExecuteNonQuery(sql);
        }
        #endregion
        //查询条数
        public DataTable Transfer(Model.PersonnelInformation model)
        {
            string sql = "select count(*) as num from Temporarytransfer where Teacher = '" + model.PIid + "'";
            return db.ExecuteQuery(sql);
        }
    }
}
