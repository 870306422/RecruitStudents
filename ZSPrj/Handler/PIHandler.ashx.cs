using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler
{
    /// <summary>
    /// PIHandler 的摘要说明
    /// </summary>
    public class PIHandler : IHttpHandler
    {

        BLL.PersonnelInformation PI = new BLL.PersonnelInformation();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"] == "PowerInfoToList")
                {
                    PIInfo(context);
                }else if (context.Request["para"] == "SelectPowerInfoToList")
                {
                    SelectPIInfo(context);
                } else if (context.Request["para"] == "destroy")
                {
                    DestroyPIInfo(context);
                }
                else if (context.Request["para"] == "addUser")
                {
                    AddPIInfo(context);
                }

            }
        }
        #region 删除
        private void DestroyPIInfo(HttpContext context)
        {
            Model.PersonnelInformation personnelInformation = new Model.PersonnelInformation();
            personnelInformation .PIid= int.Parse(context.Request["id"]);
            if (PI.DeletePI(personnelInformation) > 0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }
        #endregion
        #region 添加
        private void AddPIInfo(HttpContext context)
        {
            //if (!String.IsNullOrEmpty(context.Request["forms"]))
            //{
            Model.PersonnelInformation personnelInformation = new Model.PersonnelInformation();
            string json = context.Request["forms"].ToString();
            personnelInformation = Common.JsonHelper.DeserializeJsonToObject<Model.PersonnelInformation>(json);
            if (context.Request["para"].ToString() == "editUser")
            {
                if (PI.InsertPI(personnelInformation) > 0)
                {
                    context.Response.Write("更改成功");
                }
                else
                {
                    context.Response.Write("更改失败");
                }
            }
            else if (context.Request["para"].ToString() == "addUser")
            {
                if (PI.InsertPI(personnelInformation) > 0)
                {
                    context.Response.Write("添加成功");

                }
                else
                {
                    context.Response.Write("添加失败");
                }
                //}
            }
        }
        #endregion
        #region 条件查询分页显示
        private void SelectPIInfo(HttpContext context)
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
            if (!String.IsNullOrEmpty(context.Request["PIName"]))
            {
                where = "and PIName ='" +context.Request["PIName"].ToString()+"'";
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = PI.selectPersonnelInformationToList(where, pageIndex, pageSize, sort + " " + order, out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);
        }
        #endregion
        #region 分页显示人员列表
        private void PIInfo(HttpContext context)
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

            DataTable dt = PI.selectPersonnelInformationToList(where, pageIndex, pageSize, sort + " " + order, out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);
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