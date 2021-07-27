using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler.DataManag
{
    /// <summary>
    /// DataManagement 的摘要说明
    /// </summary>
    public class DataManagement : IHttpHandler
    {
        Model.StudentinfoModel model = new Model.StudentinfoModel();
        BLL.MangementBLL bll = new BLL.MangementBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"] == "list")
                {
                    SelectManage(context);
                }
                if (context.Request["para"] == "listT")
                {
                    SelectManageT(context);
                }
                if (context.Request["para"] == "km")
                {
                    ComboxKm(context);
                }
                if (context.Request["para"] == "ly")
                {
                    Comboxly(context);
                }
                if (context.Request["para"] == "ls")
                {
                    Comboxls(context);
                }
                if (context.Request["para"] == "zy")
                {
                    Comboxzy(context);
                }
                if (context.Request["para"] == "addUser")
                {
                    AddData(context);
                }
                if (context.Request["para"] == "editUser")
                {
                    EditData(context);
                }
                if (context.Request["para"] == "edddd")
                {
                    EditOpen(context);
                }
                if (context.Request["para"] == "delete")
                {
                    DeleteRecords(context);
                }
                //咨询记录
                if (context.Request["para"] == "zxjl")
                {
                    Sturecords(context);
                }
                if (context.Request["para"] == "add")
                {
                    AddRecords(context);
                }
                if (context.Request["para"] == "Expo")
                {
                    SelectManageM(context);
                }
                if (context.Request["para"] == "ExpoAll")
                {
                    SelectManageMG(context);
                }
                //转介绍
                if (context.Request["para"] == "zjs")
                {
                    ZJS(context);
                }
                if (context.Request["para"] == "AddTemporarytransfer")
                {
                    ZJS(context);
                }
                //删除
                if (context.Request["para"] == "deletea")
                {
                    Delete(context);
                }
            }
            //context.Response.Write("Hello World");
        }
        public void EditOpen(HttpContext context)
        {
            Model.STURecordsModel mo = new Model.STURecordsModel();
            string json = context.Request["forms"].ToString();
            //mo.RName = int.Parse(context.Request["sid"].ToString());
            mo = Common.JsonHelper.DeserializeJsonToObject<Model.STURecordsModel>(json);
            mo.StudentId = int.Parse(context.Request["STUName"].ToString());
            if (bll.EditOpen(mo) > 0)
            {
                context.Response.Write("更改成功");
            }
            else
            {
                context.Response.Write("更改失败");
            }
        }

        #region 删除 
        private void Delete(HttpContext context)
        {
            string ad = "";
            if (!String.IsNullOrEmpty(context.Request["id"]))
            {
                ad = context.Request["id"].ToString();
            }
            if (bll.Delete(ad) > 0)
            {
                context.Response.Write("学员删除成功");
            }
            else
            {
                context.Response.Write("学员删除失败");
            }
        }
        #endregion
        #region 转介绍
        private void ZJS(HttpContext context)
        {
            Model.Temporarytransfer mo = new Model.Temporarytransfer();
            DataTable dt = bll.SelectManage("select * from PersonnelInformation where PIName = '"+ context.Request["tid"].ToString() + "'");
            int a = (int)dt.Rows[0]["PIid"];
            int AddStuDistribution = bll.edit("insert into Temporarytransfer values('" + context.Request["ZXSJId"].ToString() + "','" + context.Request["AId"].ToString() + "','" + a + "','1')");
            if (AddStuDistribution > 0)
            {
                context.Response.Write("等待管理员处理");
            }
            else
            {
                context.Response.Write("转院失败");
            }
        }
        #endregion
        #region 咨询删除
        private void DeleteRecords(HttpContext context)
        {
            Model.STURecordsModel modelT = new Model.STURecordsModel();
            modelT.RID = int.Parse(context.Request["id"].ToString());
            if (bll.DeleteRecords(modelT) > 0)
            {
                context.Response.Write("咨询增加成功");
            }
            else
            {
                context.Response.Write("咨询增加失败");
            }
        }
        #endregion
        #region 咨询增加
        private void AddRecords(HttpContext context)
        {
            Model.STURecordsModel modelT = new Model.STURecordsModel();
            string json = context.Request["forms"].ToString();
            modelT = Common.JsonHelper.DeserializeJsonToObject<Model.STURecordsModel>(json);
            modelT.StudentId = int.Parse(context.Request["STUName"].ToString());
            if (bll.AddRecords(modelT) > 0)
            {
                context.Response.Write("咨询增加成功");
            }
            else
            {
                context.Response.Write("咨询增加失败");
            }
        }
        #endregion
        #region 咨询页面
        private void Sturecords(HttpContext context)
        {
            //当前页
            int PageIndex = 1;
            if (!String.IsNullOrEmpty(context.Request["page"]))
            {
                PageIndex = int.Parse(context.Request["page"].ToString());
            }

            //每页显示的数量
            int PageSize = 10;
            if (!String.IsNullOrEmpty(context.Request["rows"]))
            {
                PageSize = int.Parse(context.Request["rows"].ToString());
            }
            //设置排序字段
            string sort = "RID";
            if (!String.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"].ToString();
            }
            string id = "";
            if (!String.IsNullOrEmpty(context.Request["id"]))
            {
                id = " and a.StudentID =" + int.Parse(context.Request["id"].ToString());
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectManageA(id, PageSize , PageIndex, "RID", out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
        }
        #endregion
        #region 弹出框表单
        private void SelectManageT(HttpContext context)
        {
            //当前页
            int PageIndex = 1;
            if (!String.IsNullOrEmpty(context.Request["page"]))
            {
                PageIndex = int.Parse(context.Request["page"].ToString());
            }

            //每页显示的数量
            int PageSize = 10;
            if (!String.IsNullOrEmpty(context.Request["rows"]))
            {
                PageSize = int.Parse(context.Request["rows"].ToString());
            }
            //设置排序字段
            string sort = "StudentID";
            if (!String.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"].ToString();
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectManageT("", PageIndex, PageSize, "StudentID", out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
        }
        #endregion
        #region 分配
        private void EditData(HttpContext context)
        {
            string json = context.Request["forms"].ToString();
            model = Common.JsonHelper.DeserializeJsonToObject<Model.StudentinfoModel>(json);
            if (!String.IsNullOrEmpty(context.Request["id"]))
            {
                model.SourceIId = int.Parse(context.Request["id"].ToString());
            }
            if (bll.EditData(model) > 0)
            {
                context.Response.Write("学员分配成功");
            }
            else
            {
                context.Response.Write("学员分配失败");
            }
        }
        #endregion
        #region 增加
        private void AddData(HttpContext context)
        {
            string json = context.Request["forms"].ToString();
            model = Common.JsonHelper.DeserializeJsonToObject<Model.StudentinfoModel>(json);
            if (bll.AddData(model) > 0)
            {
                context.Response.Write("更改成功");
            }
            else
            {
                context.Response.Write("更改失败");
            }
        }
        #endregion
        #region 主页面显示
        //主页面显示
        private void SelectManage(HttpContext context)
        {
            //当前页
            int PageIndex = 1;
            if (!String.IsNullOrEmpty(context.Request["page"]))
            {
                PageIndex = int.Parse(context.Request["page"].ToString());
            }

            //每页显示的数量
            int PageSize = 10;
            if (!String.IsNullOrEmpty(context.Request["rows"]))
            {
                PageSize = int.Parse(context.Request["rows"].ToString());
            }
            //设置排序字段
            string sort = "StudentID";
            if (!String.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"].ToString();
            }
            //获取总数据量
            int countNum = 0;

            string where = "";
            if (!String.IsNullOrEmpty(context.Request["ida"]))
            {
                where = " and a.StudentID like '%"+ context.Request["ida"].ToString() + "%'";
                where+= " and b.SourceName like '%" + context.Request["idt"].ToString() + "%'";
                //where += " and a.STUName like '%" + context.Request["idtr"].ToString() + "%'";
                //where += " and a.PIName like '%" + context.Request["idf"].ToString() + "%'";
            }
          
            DataTable dt = bll.SelectManage(where, PageIndex, PageSize, "StudentID", out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
        }
        #endregion
        #region 下拉框
        private void Comboxly(HttpContext context)
        {
            DataTable dt = bll.Comboxly("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        private void ComboxKm(HttpContext context)
        {
            DataTable dt = bll.ComboxKm("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        private void Comboxls(HttpContext context)
        {
            DataTable dt = bll.Comboxls("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        private void Comboxzy(HttpContext context)
        {
            DataTable dt = bll.Comboxzy("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        #endregion
        #region 导出
        private void SelectManageM(HttpContext context)
        {
            //当前页
            int PageIndex = 1;
            if (!String.IsNullOrEmpty(context.Request["page"]))
            {
                PageIndex = int.Parse(context.Request["page"].ToString());
            }

            //每页显示的数量
            int PageSize = 10;
            if (!String.IsNullOrEmpty(context.Request["rows"]))
            {
                PageSize = int.Parse(context.Request["rows"].ToString());
            }
            //设置排序字段
            string sort = "StudentID";
            if (!String.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"].ToString();
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectManagea("", PageIndex, PageSize, "StudentID", out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
            ExportEasy(dt);
        }
        private void SelectManageMG(HttpContext context)
        {
           
            DataTable dt = bll.SelectManageMG("");
            ExportEasy(dt);
        }

        /// NPOI简单Demo，快速入门代码
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strFileName"></param>
        /// <remarks>NPOI认为Excel的第一个单元格是：(0，0)</remarks>
        /// <Author>柳永法 http://www.yongfa365.com/ 2010-5-8 22:21:41</Author>
        public static void ExportEasy(DataTable dtSource)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();

            //填充表头
            HSSFRow dataRow = (HSSFRow)sheet.CreateRow(0);
            foreach (DataColumn column in dtSource.Columns)
            {
                dataRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
            }


            //填充内容
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dataRow = (HSSFRow)sheet.CreateRow(i + 1);
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    dataRow.CreateCell(j).SetCellValue(dtSource.Rows[i][j].ToString());
                }
            }


            //保存
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(@"A:\实训\招生项目\"+DateTime.Now.ToString("yyyyMMddhhmmss")+".xls", FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }
            }
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}