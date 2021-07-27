using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler.PersonnelInformation
{
    /// <summary>
    /// PersonnelInform 的摘要说明
    /// </summary>
    public class PersonnelInform : IHttpHandler
    {
        BLL.PersonnelInformation bll = new BLL.PersonnelInformation();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                //tree显示 + 查询
                if (context.Request["para"].ToString() == "list")
                {
                    SelectMain(context);
                }
                if (context.Request["para"].ToString() == "listT")
                {
                    SelectMainT(context);
                }
                //下拉框负责人
                if (context.Request["para"].ToString() == "Head")
                {
                    SelectHead(context);
                }
                if (context.Request["para"].ToString() == "insert")
                {
                    Userinsert(context);
                }
                if (context.Request["para"].ToString() == "update")
                {
                    UserEdit(context);
                }
                if (context.Request["para"].ToString() == "delete")
                {
                    UserDelete(context);
                }
            }
                // context.Response.Write("Hello World");
        }
        #region 修改
        public void UserEdit(HttpContext context)
        {
            Model.PersonnelInformation personnel = new Model.PersonnelInformation();
            if (!String.IsNullOrEmpty(context.Request["AId"]))
            {
                personnel.PIid = int.Parse(context.Request["AId"].ToString());
            }
            if (!String.IsNullOrEmpty(context.Request["AName"]))
            {
                personnel.PIUser = context.Request["AName"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PIName"]))
            {
                personnel.PIName = context.Request["PIName"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PIpwd"]))
            {
                personnel.PIpwd = context.Request["PIpwd"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PISex"]))
            {
                personnel.PISex = int.Parse(context.Request["PISex"].ToString());
            }
            if (!String.IsNullOrEmpty(context.Request["PIAccount"]))
            {
                personnel.PIAccount = int.Parse(context.Request["PIAccount"].ToString());
            }
            if (bll.UserEdit(personnel) > 0)
            {
                context.Response.Write("增加成功");
            }
            else
            {
                context.Response.Write("增加失败");
            }

        }
        #endregion
        #region 删除
        public void UserDelete(HttpContext context)
        {
            Model.PersonnelInformation personnelInformation = new Model.PersonnelInformation();
            if (!String.IsNullOrEmpty(context.Request["id"]))
            {
                personnelInformation.PIid = int.Parse(context.Request["id"].ToString());
            }
            if (bll.DeletePI(personnelInformation)>0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }
        #endregion
        #region 下拉框负责人
        public void SelectHead(HttpContext context)
        {
            DataTable dt = bll.SelectHead("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        #endregion
        #region 查询
        public void SelectMain(HttpContext context)
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
            string sort = "PIid";
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

            string where = "";
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.selectPersonnelInformationToList(where, pageIndex, pageSize, sort + " " + order, out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
        }
        #endregion
        #region 显示
        public void SelectMainT(HttpContext context)
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
            string sort = "PIid";
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
            string inq = "";
            string name = "";
            string nv = "";
            if (!String.IsNullOrEmpty(context.Request["inquire"]))
            {
                inq = context.Request["inquire"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["name"]))
            {
                name = context.Request["name"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["nv"]))
            {
                nv = context.Request["nv"].ToString();
            }
            string where = " and PIUser LIKE '%" + inq+ "%' and  PIName LIKE '%" + name + "%' and PISex LIKE '%" + nv+"%'";
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.selectPersonnelInformationToList(where, pageIndex, pageSize, sort + " " + order, out countNum);
            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);
            context.Response.Write(jsonString);
        }
        #endregion
        #region 人员增加
        public void Userinsert(HttpContext context)
        {
            Model.PersonnelInformation personnel = new Model.PersonnelInformation();
            if (!String.IsNullOrEmpty(context.Request["AName"]))
            {
                personnel.PIUser = context.Request["AName"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PIName"]))
            {
                personnel.PIName = context.Request["PIName"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PIpwd"]))
            {
                personnel.PIpwd = context.Request["PIpwd"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["PISex"]))
            {
                personnel.PISex = int.Parse(context.Request["PISex"].ToString());
            }
            if (!String.IsNullOrEmpty(context.Request["PIAccount"]))
            {
                personnel.PIAccount = int.Parse(context.Request["PIAccount"].ToString());
            }
            if (bll.Userinsert(personnel)>0)
            {
                context.Response.Write("增加成功");
            }
            else
            {
                context.Response.Write("增加失败");
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