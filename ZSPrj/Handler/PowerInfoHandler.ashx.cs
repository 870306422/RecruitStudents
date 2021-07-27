using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler
{
    /// <summary>
    /// PowerInfoHandler 的摘要说明
    /// </summary>
    public class PowerInfoHandler : IHttpHandler
    {
        BLL.PowerInfo bll = new BLL.PowerInfo();
        BLL.ModuleInfo mdbll = new BLL.ModuleInfo();
        BLL.PowerToModuleInfo pmbll = new BLL.PowerToModuleInfo();
        #region 判断选择项
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"] == "SelectPowerInfoToList")
                {
                    SelectPowerInfoToList(context);
                }else if (context.Request["para"] == "GetModuleInfo")
                {
                    GetModuleInfo(context);
                }
                else if (context.Request["para"].ToString() == "destroy")
                {
                    DestroyPowerInfoToList(context);
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
                else if (context.Request["para"].ToString() == "addPowerInfo")
                {
                    addPowerInfo(context);
                }
                else if (context.Request["para"].ToString() == "delPowerInfo")
                {
                    DelPowerInfo(context);
                }
                else if (context.Request["para"].ToString() == "EditPowerInfo")
                {
                    EditPowerInfo(context);
                }
            }
        }
        #endregion
        #region 删除powerid的所有模块
        private void DelPowerInfo(HttpContext context)
        {
            //powerToModule.ModuleId = context.Request["id"];
            Model.PowerToModule powerToModule = new Model.PowerToModule();
            powerToModule.PowerName = context.Request["PowerName"];
            if (pmbll.DeletePowerToModule(powerToModule) > 0)
            {
                context.Response.Write("InsertPowerToModule删除成功");
            }
            else
            {
                context.Response.Write("InsertPowerToModule删除失败");
            }
        }
        #endregion
        #region 添加
        private void EditUser(HttpContext context)
        {
            //if (!String.IsNullOrEmpty(context.Request["forms"]))
            //{
            Model.PowerInfo powerInfo = new Model.PowerInfo();
            string json = context.Request["forms"].ToString();
            powerInfo = Common.JsonHelper.DeserializeJsonToObject<Model.PowerInfo>(json);
            //moduleInfo.Mid = int.Parse(context.Request["id"]);
            if (context.Request["para"].ToString() == "editUser")
            {
                if (bll.UpdatePower(powerInfo) > 0)
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
                if (bll.InsertPower(powerInfo) > 0)
                {
                    context.Response.Write("powerInfo添加成功");

                }
                else
                {
                    context.Response.Write("powerInfo添加失败");
                }
                //}
            }
        }
        #endregion
        #region 修改editPowerInfo
        private void EditPowerInfo(HttpContext context)
        {
            Model.PowerToModule powerToModule = new Model.PowerToModule();
            powerToModule.ModuleId = context.Request["ModuleId"];
            powerToModule.PowerId = context.Request["PowerId"];
            if (pmbll.InsertPowerToModule1(powerToModule) > 0)
            {
                context.Response.Write("InsertPowerToModule修改添加成功");
            }
            else
            {

                context.Response.Write("InsertPowerToModule修改添加失败");
            }
        }
        #endregion
        #region 添加模块和权限的关联
        private void addPowerInfo(HttpContext context)
        {
            Model.PowerToModule powerToModule = new Model.PowerToModule();
            powerToModule.ModuleId = context.Request["ModuleId"];
            powerToModule.PowerName = context.Request["PowerName"];
            if (pmbll.InsertPowerToModule(powerToModule) > 0)
            {
                context.Response.Write("InsertPowerToModule添加成功");
            }
            else
            {

                context.Response.Write("InsertPowerToModule添加失败");
            }
        }
        #endregion
        #region  权限组
        private void GetModuleInfo(HttpContext context)
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
            string sort = "PowerID";
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
            string where2 = "";
            string where1 = "";
            //string where2 = "and PowerId = '1'";
            if (!String.IsNullOrEmpty(context.Request["id"]))
            {
                where2 = "and PowerId = '" + context.Request["id"].ToString() + "'";
            }
            DataTable dt1 = mdbll.SelectModuleInfo1(where1);   //所有模块信息
            DataTable dt2 = pmbll.SelectPowerToModuleInfo(where2);   //管理员能访问的模块
            string jsonString = "{\"mInfo\":" + Common.JsonHelper.SerializeObject(dt1) + ",\"pmInfo\"," + Common.JsonHelper.SerializeObject(dt2) + "}";
            string json = "{\"mInfo\":" + Common.JsonHelper.SerializeObject(dt1) + ",\"pmInfo\":" + Common.JsonHelper.SerializeObject(dt2) + "}";

            context.Response.Write(json);
        }
        #endregion
        #region 条件查询
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
            string sort = "PowerID";
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
            if (!String.IsNullOrEmpty(context.Request["PowerName"]))
            {
                where = " and PowerName = '" + context.Request["PowerName"].ToString() + "'";
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

            DataTable dt = bll.SelectPowerInfoToList(where, pageIndex, pageSize, sort + " " + order, out countNum);

            string jsonString = Common.JsonHelper.DataTableToJsonList(dt, countNum);

            context.Response.Write(jsonString);
        }

        #endregion
        #region 删除
        private void DestroyPowerInfoToList(HttpContext context)
        {
            Model.PowerInfo powerInfo = new Model.PowerInfo();
            powerInfo.PowerID = int.Parse(context.Request["id"]);
            if (bll.DeletePower(powerInfo) > 0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }
        #endregion
        #region 权限组列表显示
        private void SelectPowerInfoToList(HttpContext context)
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
            string sort = "PowerID";
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

            DataTable dt1 = bll.SelectPowerInfoToList(where, pageIndex, pageSize,sort +" "+ order, out countNum);
            string jsonString =Common.JsonHelper.DataTableToJsonList(dt1, countNum);

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