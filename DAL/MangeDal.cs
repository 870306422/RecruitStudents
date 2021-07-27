using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MangeDal
    {
        DBHelp.DBHelper help = new DBHelp.DBHelper();
        public DataTable MangeSelect(string where)
        {
            string str = "select a.*,b.PIName from Academy a left join PersonnelInformation b on a.Hid=b.PIid " + where;
            return help.ExecuteQuery(str);
        }
        public DataTable DropSelect(string where)
        {
            string str = "select a.*,b.PIid,b.PIName from Academy a left join PersonnelInformation b on a.Hid=b.PIid" + where;
            return help.ExecuteQuery(str);
        }
        public DataTable DropSelectT(string where)
        {
            string str = "select * from PersonnelInformation where Flag = 1 " + where;
            return help.ExecuteQuery(str);
        }
        public int EditHeaderT(Model.Academy academy)
        {
            string str = "update Academy set PId ='"+academy.PId1+"'  ,AName = '" + academy.AName1 + "',Hid = '" + academy.Hid1 + "' where AId = '" + academy.AId1 + "'";
            return help.ExecuteNonQuery(str);
        }
        public int EditHeader(Model.Academy academy)
        {
            string str = "update Academy set AName = '"+academy.AName1+"',Hid = '"+academy.Hid1+"' where AId = '"+academy.AId1+"'";
            return help.ExecuteNonQuery(str);
        }
        #region 学院招生统计 弹出增加修改
        //查找学院 + 
        public DataTable AddHead(string where)
        {
            string str = "select * from Academy where 1=1"+where;
            return help.ExecuteQuery(str);
        }
        //查找学院老师aid
        public DataTable AddHeadT(string where)
        {
            string str = "select * from PersonnelInformation where 1=1" + where;
            return help.ExecuteQuery(str);
        }
        //增加学院
        public int Add(string where)
        {
            string str = "insert into Academy values('"+where+"') ";
            return help.ExecuteNonQuery(str);
        }
        //增加一级学院老师
        public int AddT(string where)
        {
            string str = "insert into Academy(AName) values('" + where + "') ";
            return help.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 根据id查负责人姓名
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable SelName(string where) 
        {
            string str = "select* from PersonnelInformation  where 1=1 "+where;
            return help.ExecuteQuery(str);
        }


        /// <summary>
        /// 有父级是添加二级专业负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddTwoAca(Model.Academy academy) 
        {
            string str = "insert into Academy values('"+academy.AName1+"',"+academy.Hid1+","+academy.AId1+")";
            return help.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 没有父级是添加学院负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddAcademy(Model.Academy academy)
        {
            string str = "insert into Academy values('" + academy.AName1 + "','" + academy.Hid1 + "',0)";
            return help.ExecuteNonQuery(str);
        }

        /// <summary>
        /// 根据姓名查id
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public DataTable SelId(Model.Academy academy) 
        {
            string str = "select * from Academy where 1=1 and AName ='" + academy.AName1 + "'";
            return help.ExecuteQuery(str);
        }
        /// <summary>
        /// 没有父级是二级专业负责人
        /// </summary>
        /// <param name="academy"></param>
        /// <returns></returns>
        public int AddAca(Model.Academy academy)
        {
            string str = "insert into Academy values('" + academy.AName1 + "'," + academy.Hid1 + ","+academy.AId1+")";
            return help.ExecuteNonQuery(str);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Del(string where) 
        {
            string str = "delete  from Academy" + where;
            return help.ExecuteNonQuery(str);
        }
        #endregion
    }
}
