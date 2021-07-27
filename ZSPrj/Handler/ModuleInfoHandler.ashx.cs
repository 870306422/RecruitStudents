using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ZSPrj.Handler
{
    /// <summary>
    /// ModuleInfoHandler 的摘要说明
    /// </summary>
    public class ModuleInfoHandler : IHttpHandler,IRequiresSessionState
    {
        BLL.ModuleInfo bll = new BLL.ModuleInfo();
        BLL.PersonnelInformation PersonnelInformation = new BLL.PersonnelInformation();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"]== "GetFourMenu")
                {
                    SelectModuleInfo(context);
                }else if (context.Request["para"] == "SelectModuleInfoToList")
                {
                    SelectModuleInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "destroy")
                {
                    DestroyUserInfoToList(context);
                }
                else if (context.Request["para"].ToString() == "addUser")
                {
                    EditUser(context);
                }
                else if (context.Request["para"].ToString() == "editUser")
                {
                    EditUser(context);
                }
                else if (context.Request["para"].ToString() == "Selectlist")
                {
                    Selectlist(context);
                }
                else if (context.Request["para"].ToString() == "savePIPwd")
                {
                    savePIPwd(context);
                }
                else if (context.Request["para"].ToString() == "GetName")
                {
                    GetName(context);
                }
                else if (context.Request["para"].ToString() == "GetPID")
                {
                    GetPID(context);
                }

            }
        }
        #region 修改密码
        private void savePIPwd(HttpContext context)
        {
            string NewPIpwd = context.Request["NewPIpwd"];
            Model.PersonnelInformation personnelInformation = new Model.PersonnelInformation();

            Model.PersonnelInformation PI = (Model.PersonnelInformation)context.Session["PI"];
            personnelInformation.PIid = PI.PIid;
            personnelInformation.PIpwd = NewPIpwd;
            if (PersonnelInformation.EditPIPwd(personnelInformation)>0)
            {
                context.Response.Write("修改成功");
            }
            else
            {
                context.Response.Write("修改失败");
            }

        }
        #endregion
        #region 左侧模板查询
        public void SelectModuleInfo(HttpContext context)
        {
            Model.PersonnelInformation PI = (Model.PersonnelInformation)context.Session["PI"];      
            DataTable dt = bll.SelectModuleInfo2(PI.PIAccount.ToString());
            string json = Common.JsonHelper.SerializeObject(dt);
            context.Response.Write(json);

        }
        #endregion
        #region 姓名，权限赋值
        public void GetName(HttpContext context)
        {
            Model.PersonnelInformation PI = (Model.PersonnelInformation)context.Session["PI"];
            context.Response.Write(PI.PIName.ToString());
        }
        #endregion
        #region 权限赋值
        public void GetPID(HttpContext context)
        {
            Model.PersonnelInformation PI = (Model.PersonnelInformation)context.Session["PI"];
            context.Response.Write(PI.PowerName.ToString());
        }
        #endregion
        #region 条件查询
        //条件查询
        private void Selectlist(HttpContext context)
        {//当前页
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
            string sort = "Mid";
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
            if (!String.IsNullOrEmpty(context.Request["UserName"]))
            {
                where = " and ModuleName = '" + context.Request["UserName"].ToString() + "'";
            }
            if (!String.IsNullOrEmpty(context.Request["Flag"]))
            {
                where += " and Flag = '" + context.Request["Flag"].ToString() + "'";
            }
            if (!String.IsNullOrEmpty(context.Request["ModuleUrl"]))
            {
                where += " and ModuleUrl = '" + context.Request["ModuleUrl"].ToString() + "'";
            }
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectModuleInfoList(where, pageIndex, pageSize, sort + " " + order, out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);
        }
        #endregion
        #region 增加修改
        //增加修改
        private void EditUser(HttpContext context)
        {
            if (!String.IsNullOrEmpty(context.Request["forms"]))
            {
                Model.ModuleInfo moduleInfo = new Model.ModuleInfo();
                string json = context.Request["forms"].ToString();
                moduleInfo = Common.JsonHelper.DeserializeJsonToObject<Model.ModuleInfo>(json);
                //moduleInfo.Mid = int.Parse(context.Request["id"]);
                if (context.Request["para"].ToString() == "editUser")
                {
                    if (bll.EditUsers(moduleInfo) > 0)
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
                    if (bll.InsertUsers(moduleInfo) > 0)
                    {
                        context.Response.Write("添加成功");
                    }
                    else
                    {
                        context.Response.Write("添加失败");
                    }
                }


            }

        }
        #endregion
        #region 删除
        //删除
        private void DestroyUserInfoToList(HttpContext context)
        {
            Model.ModuleInfo moduleInfo = new Model.ModuleInfo();
            moduleInfo.Mid = int.Parse(context.Request["id"]);
            if (bll.DeleteUsers(moduleInfo) > 0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }
        #endregion
        #region 条件查询
        //条件查询
        private void SelectModuleInfoToList(HttpContext context)
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
            string sort = "Mid";
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
            //if (!String.IsNullOrEmpty(context.Request["UserName"]))
            //{
            //    where = " and UserName = '" + context.Request["UserName"].ToString() + "'";
            //}
            //if (!String.IsNullOrEmpty(context.Request["Flag"]))
            //{
            //    where += " and Flag = '" + context.Request["Flag"].ToString() + "'";
            //}
            //if (!String.IsNullOrEmpty(context.Request["ModuleUrl"]))
            //{
            //    where += " and ModuleUrl = '" + context.Request["ModuleUrl"].ToString() + "'";
            //}
            //获取总数据量
            int countNum = 0;

            DataTable dt = bll.SelectModuleInfoList1(where, pageIndex, pageSize, sort + " " + order, out countNum);

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