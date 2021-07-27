using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler
{
    /// <summary>
    /// Temporarytransfer 的摘要说明
    /// </summary>
    public class Temporarytransfer : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"].ToString() == "TurnZXSJToList")
                {
                    TurnZXSJToList(context);
                }
                else if (context.Request["para"].ToString() == "saveconfirm")
                {
                    saveconfirm(context);
                }
                else if (context.Request["para"].ToString() == "savecancel")
                {
                    savecancel(context);
                }
                else if (context.Request["para"].ToString() == "selectnam")
                {
                    SelectName(context);
                }
                else if (context.Request["para"].ToString() == "transfe")
                {
                    Transfer(context);
                }
            }
        }
        BLL.Temporarytransfer bll = new BLL.Temporarytransfer();
        #region 取消转院
        private void savecancel(HttpContext context)
        {
            Model.Temporarytransfer temporarytransfer = new Model.Temporarytransfer();
            temporarytransfer.TtId = int.Parse(context.Request["id"].ToString());
            if (bll.savedelete(temporarytransfer) > 0)
            {
                
                context.Response.Write("不同意'" + temporarytransfer.StuName + "'转院");
            }
            else
            {
                context.Response.Write("不同意'" + temporarytransfer.StuName + "'转院失败");
            }
        }
        #endregion
        #region 确认转院
       

        //查询
        public void SelectName(HttpContext context)
        {
            string a = context.Request["sid"].ToString();
            DataTable dt = bll.SelectName(" and STUName = '" + context.Request["sid"].ToString() +"'");
            context.Response.Write(dt);

        }
        private void saveconfirm(HttpContext context)
        {

            Model.Temporarytransfer temporarytransfer = new Model.Temporarytransfer();
            temporarytransfer.TtId = int.Parse(context.Request["id"].ToString());
            temporarytransfer.StuName = int.Parse(context.Request["SsName"].ToString());
            if (bll.saveconfirm(temporarytransfer) > 0)
            {
                context.Response.Write("成功");
                temporarytransfer.TtId = int.Parse(context.Request["tid"].ToString());

                if (bll.savedelete(temporarytransfer) > 0)
                {
                    context.Response.Write("同意'"+ context.Request["Stuname"].ToString() + "'转院");
                }
            }
            else
            {
                context.Response.Write("同意'" + temporarytransfer.StuName + "'转院失败");
            }
        }
        #endregion
        private void TurnZXSJToList(HttpContext context)
        {
            //当前页
            int pageIndex = 1;
            if (!String.IsNullOrEmpty(context.Request["page"]))
            {
                pageIndex = int.Parse(context.Request["page"].ToString());
            }
            //每页显示的数量
            int pageSize = 10;
            if (!String.IsNullOrEmpty(context.Request["rows"]))
            {
                pageSize = int.Parse(context.Request["rows"].ToString());
            }
            //设置排序字段
            string sort = "TtId";
            if (!String.IsNullOrEmpty(context.Request["sort"]))
            {
                sort = context.Request["sort"].ToString();
            }
            //排序的方式 asc or desc
            string order = "asc";
            if (!String.IsNullOrEmpty(context.Request["order"]))
            {
                order = context.Request["order"].ToString();
            }
            //获取总数据量
            int countNum = 0;
            string where = " and Teacher = '" + context.Request["id"].ToString()+"'";
            DataTable dt = bll.TurnZXSJToList(where, pageIndex, pageSize, sort + " " + order, out countNum);   //所有模块信息
            string json = Common.JsonHelper.DataTableToJsonList(dt);
            context.Response.Write(json);
        }

        //查询数据条数
        private void Transfer(HttpContext context)
        {
            Model.PersonnelInformation PI = new Model.PersonnelInformation();
            PI.PIid = int.Parse(context.Request["id"].ToString());
            DataTable dt = bll.Transfer(PI);
            int dtt = (int)dt.Rows[0]["num"];
            context.Response.Write(dtt);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}