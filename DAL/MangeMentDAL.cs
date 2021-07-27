using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MangeMentDAL
    {
        DBHelp.DBHelper help = new DBHelp.DBHelper();
        public DataTable SelectManage(string where, int PageSize , int PageIndex, string sort, out int countNum)
        {
           string  str = "select a.StudentID,a.STUName,a.SchoolName,a.EditOutTime,a.ClassName,a.PhoneID,case a.IsSchool when '0' then '正在处理'     when '1' then '无' else '已处理' end as 'IsSchool',case a.WhetherPrepare when '1' then '已预报名' else '未预报名' end as 'WhetherPrepare',case a.WhetherAccept when '1' then '已录取' else '未录取' end as 'WhetherAccept',case a.ScoreCrosses when '1' then '已过线' else '未过线' end as 'ScoreCrosses',case a.Flag when '1' then '已激活' else '未激活' end as 'Flag',case a.QQFlag when '1' then 'QQ已添加' else 'QQ未添加' end as 'QQFlag',a.TeacherId,a.QQId,a.Academyid,a.ConsultingComponents,a.NoteInfo,a.ActualScore,a.ScoreSegment,b.SourceName,(select count(*) from STURecords where STURecords.StudentId=a.StudentID) as 'RName',c.PIName,d.AName, e.Degree from StudentInfoT a left join SourceOne b on a.SourceIId=b.SoureId left join PersonnelInformation c on c.PIid=a.TeacherId left join Academy d on d.AId = a.Academyid left join DegreeTb e on a.Did = e.Did where 1=1" + where;
            return help.QueryDataList(str, PageIndex, PageSize, sort, out countNum);
        }
        public DataTable SelectManageMG(string where)
        {
            string str = "select a.StudentID,a.STUName,a.SchoolName,a.EditOutTime,a.ClassName,a.PhoneID,case a.IsSchool when '0' then '正在处理'    when '1' then '无' else '已处理' end as 'IsSchool',case a.WhetherPrepare when '1' then '已预报名' else '未预报名' end as 'WhetherPrepare',case a.WhetherAccept when '1' then '已录取' else '未录取' end as 'WhetherAccept',case a.ScoreCrosses when '1' then '已过线' else '未过线' end as 'ScoreCrosses',case a.Flag when '1' then '已激活' else '未激活' end as 'Flag',case a.QQFlag when '1' then 'QQ已添加' else 'QQ未添加' end as 'QQFlag',a.TeacherId,a.QQId,a.Academyid,a.ConsultingComponents,a.NoteInfo,a.ActualScore,a.ScoreSegment,b.SourceName,(select count(*) from STURecords where STURecords.StudentId=a.StudentID) as 'RName',c.PIName,d.AName, e.Degree from StudentInfoT a left join SourceOne b on a.SourceIId=b.SoureId left join PersonnelInformation c on c.PIid=a.TeacherId left join Academy d on d.AId = a.Academyid left join DegreeTb e on a.Did = e.Did" + where;
            return help.ExecuteQuery(str);
        }
        public DataTable SelectManageT(string where, int PageSize, int PageIndex, string sort, out int countNum)
        {
            string str = "select a.StudentID,a.STUName,a.SchoolName,a.EditOutTime,a.ClassName,a.PhoneID,case a.IsSchool when '0' then '正在处理'   when '1' then '无' else '已处理' end as 'IsSchool',case a.WhetherPrepare when '1' then '已预报名' else '未预报名' end as 'WhetherPrepare',case a.WhetherAccept when '1' then '已录取' else '未录取' end as 'WhetherAccept',case a.ScoreCrosses when '1' then '已过线' else '未过线' end as 'ScoreCrosses',case a.Flag when '1' then '已激活' else '未激活' end as 'Flag',case a.QQFlag when '1' then 'QQ已添加' else 'QQ未添加' end as 'QQFlag',a.TeacherId,a.QQId,a.Academyid,a.ConsultingComponents,a.NoteInfo,a.ActualScore,a.ScoreSegment,b.SourceName,(select count(*) from STURecords where STURecords.StudentId=a.StudentID) as 'RName',c.PIName,d.AName, e.Degree from StudentInfoT a left join SourceOne b on a.SourceIId=b.SoureId left join PersonnelInformation c on c.PIid=a.TeacherId left join Academy d on d.AId = a.Academyid left join DegreeTb e on a.Did = e.Did where a.TeacherId = '' and 1=1" + where;
            return help.QueryDataList(str, PageIndex, PageSize, sort, out countNum);
        }
        public DataTable SelectManagea(string where, int PageIndex, int PageSize, string sort, out int countNum)
        {
            string str = "select a.StudentID,a.STUName,a.SchoolName,a.EditOutTime,a.ClassName,a.PhoneID,case a.IsSchool when '0' then '正在处理'   when '1' then '无' else '已处理' end as 'IsSchool',case a.WhetherPrepare when '1' then '已预报名' else '未预报名' end as 'WhetherPrepare',case a.WhetherAccept when '1' then '已录取' else '未录取' end as 'WhetherAccept',case a.ScoreCrosses when '1' then '已过线' else '未过线' end as 'ScoreCrosses',case a.Flag when '1' then '已激活' else '未激活' end as 'Flag',case a.QQFlag when '1' then 'QQ已添加' else 'QQ未添加' end as 'QQFlag',a.TeacherId,a.QQId,a.Academyid,a.ConsultingComponents,a.NoteInfo,a.ActualScore,a.ScoreSegment,b.SourceName,(select count(*) from STURecords where STURecords.StudentId=a.StudentID) as 'RName',c.PIName,d.AName, e.Degree from StudentInfoT a left join SourceOne b on a.SourceIId=b.SoureId left join PersonnelInformation c on c.PIid=a.TeacherId left join Academy d on d.AId = a.Academyid left join DegreeTb e on a.Did = e.Did where a.TeacherId = '' and 1=1" + where;
            return help.QueryDataList(str, PageIndex, PageSize, sort, out countNum);
        }
        public DataTable SelectManageA(string where,  int PageSize, int PageIndex, string sort, out int countNum)
        {
            string str = "select a.RID,a.RTime,a.Recs,b.STUName,c.PIName from STURecords a left join StudentInfoT b on a.StudentId=b.StudentID left join PersonnelInformation c on a.RName=c.PIid where 1=1" + where;
            return help.QueryDataList(str, PageIndex, PageSize, sort, out countNum);
        }
        public DataTable Comboxly(string where)
        {
            string str = "select * from SourceOne" + where;
            return help.ExecuteQuery(str);
        }
        public DataTable ComboxKm(string where)
        {
            string str = "select * from DegreeTb" + where;
            return help.ExecuteQuery(str);
        }
        public DataTable Comboxls(string where)
        {
            string str = "select * from PersonnelInformation" + where;
            return help.ExecuteQuery(str);
        }
        public DataTable Comboxzy(string where)
        {
            string str = "select * from Academy" + where;
            return help.ExecuteQuery(str);
        }
        public int DeleteRecords(Model.STURecordsModel model)
        {
            string str = "delete from STURecords where RID = '"+model.RID+"'";
            return help.ExecuteNonQuery(str);
        }
        public int AddData(Model.StudentinfoModel model)
        {
            string str = "insert into StudentInfoT(SourceIId,STUName,SchoolName,ClassName,Did,EditOutTime,ScoreCrosses,WhetherAccept,WhetherPrepare,TeacherId,QQId,PhoneID,Academyid,NoteInfo,ActualScore,ScoreSegment,IsSchool) values('" + model.SourceIId+ "','" + model.STUName + "','" + model.SchoolName + "','" + model.ClassName + "','" + model.Did + "','"+DateTime.Now+"','" + model.ScoreCrosses + "','" + model.WhetherAccept + "','" + model.WhetherPrepare + "','','" + model.QQId + "','" + model.PhoneID + "','" + model.Academyid + "','','" + model.ActualScore + "','"+(model.ActualScore-100)+"-"+ (model.ActualScore + 100) + "',1)";
            return help.ExecuteNonQuery(str);
        }
        public int EditOpen(Model.STURecordsModel model)
        {
            string str = "update STURecords set RName='"+model.RName+"' ,StudentId='"+model.StudentId+"',RTime='"+DateTime.Now+"',Recs='"+model.Recs+"' where RID='"+model.RID+"'";
            return help.ExecuteNonQuery(str);
        }
        public int AddRecords(Model.STURecordsModel modelT)
        {
            string str = " insert into STURecords(RName,StudentId,RTime,Recs) values('"+modelT.RName+"','"+modelT.StudentId+"','"+DateTime.Now+"','"+modelT.Recs+"')";
            return help.ExecuteNonQuery(str);
        }
        public int EditData(Model.StudentinfoModel model)
        {
            string str = "update StudentInfoT set  TeacherId = '"+model.TeacherId+"' where StudentID ='"+model.SourceIId+"'";
            return help.ExecuteNonQuery(str);
        }
        public int edit(string where)
        {
            return help.ExecuteNonQuery(where);
        }
        public DataTable SelectManage(string where)
        {
            return help.ExecuteQuery(where);
        }
        public int Delete(string where)
        {
            string str = "delete StudentInfoT where  StudentID = '"+where+"'";
            return help.ExecuteNonQuery(str);
        }
    }
}