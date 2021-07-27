using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ZSPrj.Handler
{
    /// <summary>
    /// UserHandler 的摘要说明
    /// </summary>
    public class UserHandler : IHttpHandler
    {
        BLL.UserInfo bll = new BLL.UserInfo();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"].ToString() == "list")
                {
                    SelectUserInfoToList(context);
                }else if (context.Request["para"].ToString() == "save")
                {
                    SaveUserInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "destroy")
                {
                    destroyUserInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "Selectlist")
                {
                    SelectlistUserInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "editUser")
                {
                    editUserInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "SUserTypeInfo")
                {
                    SUserTypeInfoToList(context);
                }
            }
        }
        //下拉框查询
        private void SUserTypeInfoToList(HttpContext context)
        {
            string where = "";
            DataTable dt = bll.SelectUserTypeInfo(where);
            string json = Common.JsonHelper.SerializeObject(dt);
            context.Response.Write(json);
        }

        //修改
        private void editUserInfoToList(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request["forms"]))
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                string json = context.Request["forms"].ToString();
                userInfo = Common.JsonHelper.DeserializeJsonToObject<Model.UserInfo>(json);
                userInfo.UserId = int.Parse(context.Request["id"]);
                if (bll.EditUsers(userInfo) > 0)
                {
                    context.Response.Write("更改成功");
                }
                else
                {
                    context.Response.Write("更改失败");
                }
            }
        }
        //查询
        private void SelectlistUserInfoToList(HttpContext context)
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
            string where = ""; 
            if (!String.IsNullOrEmpty(context.Request["name"]))
            {
                where = " and UserName = '" +context.Request["name"].ToString()+"'";
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectUserInfoToList(where, pageIndex, pageSize, "UserId", out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);
        }

        //删除
        private void destroyUserInfoToList(HttpContext context)
        {
            //string where = "";
            //if (!String.IsNullOrEmpty(context.Request["id"]))
            //{
            //    where = "and UserId = '" + context.Request["id"] + "'";
            //}
            Model.UserInfo userInfo = new Model.UserInfo();
            userInfo.UserId =int.Parse( context.Request["id"]);
            if (bll.DeleteUsers(userInfo) >0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }

        //添加
        private void SaveUserInfoToList(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request["forms"]))
            {
                Model.UserInfo userInfo = new Model.UserInfo();
                string json = context.Request["forms"].ToString();
                userInfo = Common.JsonHelper.DeserializeJsonToObject<Model.UserInfo>(json);
                if (bll.InsertUsers(userInfo)>0)
                {
                    context.Response.Write("添加成功");
                }
                else
                {
                    context.Response.Write("添加失败");
                }
            }
        }
        //显示
        public void SelectUserInfoToList(HttpContext context)
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

            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectUserInfoToList("", pageIndex, pageSize, "UserId", out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);

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