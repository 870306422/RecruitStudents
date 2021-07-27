using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace ZSPrj.Handler.Mange
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {
        BLL.MangeBll bll = new BLL.MangeBll();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                //tree显示 + 查询
                if (context.Request["para"]=="list")
                {
                    mangane(context);
                }
                //弹出层 下拉框
                if (context.Request["para"] == "dropdown")
                {
                    DropdownSelect(context);
                }
                if (context.Request["para"] == "dropdownT")
                {
                    DropdownSelectT(context);
                }
                if (context.Request["para"] == "selectpwd")
                {
                    SelectPwd(context);
                }
                //增加专业
                if (context.Request["para"] == "addHead")
                {
                    AddaddHead(context);
                }
                if (context.Request["para"] == "asd")
                {
                    AddHeadT(context);
                }
                //修改专业
                if (context.Request["para"] == "editHead")
                {
                    EditHeader(context);
                }
                if (context.Request["para"] == "Del")
                {
                    Del(context);
                }
            }
            
            //context.Response.Write("Hello World");
        }
        public void AddHeadT(HttpContext context)
        {
            string pinam = "";
            if (!String.IsNullOrEmpty(context.Request["pinam"]))
            {
                pinam = context.Request["pinam"].ToString();
            }
            DataTable dt = bll.AddHeadT(" and PIName = '" + pinam+"'");
            if (dt.Rows.Count > 0)
            {
                string na = dt.Rows[0]["PIid"].ToString();
                context.Response.Write(na);
            }
        }
        #region 修改专业
        public void EditHeader(HttpContext context)
        {
            Model.Academy academy = new Model.Academy();
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(context.Request["aid"]))
            {
                //院校
                academy.AId1 = int.Parse(context.Request["aid"].ToString());
            }
            if (!String.IsNullOrEmpty(context.Request["hid"]))
            {
                //专业
                academy.Hid1 = int.Parse(context.Request["hid"].ToString());
            }
            if (!String.IsNullOrEmpty(context.Request["anamea"]))
            {
                //专业
                academy.AName1 = context.Request["anamea"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["AName"]))
            {
                //专业
                academy.ANamett1 = context.Request["AName"].ToString();
            }
            if (academy.ANamett1 != null)
            {
                if (!String.IsNullOrEmpty(context.Request["asd"]))
                {
                    academy.PId1 = int.Parse(context.Request["asd"].ToString());
                }
                if (bll.EditHeaderT(academy) > 0)
                {
                    context.Response.Write("修改成功");
                }
                else
                {
                    context.Response.Write("修改失败");
                }
            }
            else
            {
                if (bll.EditHeader(academy) > 0)
                {
                    context.Response.Write("修改成功");
                }
                else
                {
                    context.Response.Write("修改失败");
                }
            }
        }
        #endregion
        #region 增加专业
        public void AddaddHead(HttpContext context)
        {
            Model.Academy academy = new Model.Academy();

            string AName = "";
            string ANameT = "";
            string Head = "";
            if (!String.IsNullOrEmpty(context.Request["AName"]))
            {
                AName = context.Request["AName"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["ANameT"]))
            {
                ANameT = context.Request["ANameT"].ToString();
            }
            if (!String.IsNullOrEmpty(context.Request["Head"]))
            {
                //负责人
                Head = context.Request["Head"].ToString();
            }
                DataTable dt = bll.AddHead(" and AName = '" + AName + "'");
                if (dt.Rows.Count > 0)
                {
                    var Aid = dt.Rows[0]["AId"].ToString();
                    academy.AName1 = ANameT.ToString();
                    academy.Hid1 = int.Parse(Head);
                    academy.AId1 = int.Parse(Aid);
                    if (bll.AddTwoAca(academy) > 0)
                    {
                        context.Response.Write("添加成功");
                    }
                    else
                    {
                        context.Response.Write("添加失败");
                    }
                }
                else
                {
                    academy.AName1 = ANameT;
                    academy.Hid1 = int.Parse(Head);
                    if (bll.AddAcademy(academy) > 0)
                        {
                            context.Response.Write("添加成功");
                        }
                        else
                        {
                            context.Response.Write("添加失败");
                        }
                }


        }


        public void Del(HttpContext context) 
        {
            int AId = int.Parse(context.Request["AId"]);
            string where = " where   AId=" + AId + " ";
            if (bll.Del(where)>0)
            {
                context.Response.Write("删除成功");
            }
            else
            {
                context.Response.Write("删除失败");
            }
        }

        #endregion

        #region 弹出层 下拉框
        #region 查询
        public void SelectPwd(HttpContext context)
        {
            int aid = 0;
            if (!String.IsNullOrEmpty(context.Request["aid"]))
            {
                aid = int.Parse(context.Request["aid"].ToString());
            }
            DataTable dt = bll.AddHead(" and AId = '" + aid + "'" );
            string json = Common.JsonHelper.DataTable2Json(dt);
            if (dt.Rows.Count>0)
            {
                context.Response.Write(json);
            }
        }
        #endregion
        public void DropdownSelect(HttpContext context)
        {
            DataTable dt = bll.DropSelect("");
            context.Response.Write(GetTreeJsonByTableT(dt, "AId", "AName", "Hid", "PId", "0"));
        }
        /// <summary>
        /// 院长
        /// </summary>
        /// <param name="context"></param>
        public void DropdownSelectT(HttpContext context)
        {
            StringBuilder sub = new StringBuilder();
            DataTable dt = bll.DropSelectT("");
            string strjson = Common.JsonHelper.DataTable2Json(dt);
            string json = "[" + strjson + "]";
            context.Response.Write(json);
        }
        #endregion

        #region  树
        /// <summary>
        /// 树
        /// </summary>
        /// <param name="context"></param>
        public void mangane(HttpContext context)
        {
            string inq = "";
            DataTable str = new DataTable();
            if (!String.IsNullOrEmpty(context.Request["inq"]))
            {
                inq = " where AName='" + context.Request["inq"].ToString() + "'" ;
                str = bll.MangeSelect(inq);
                int pid = int.Parse(str.Rows[0]["PId"].ToString());
                if (pid==0)
                {
                    inq = " where AName='" + context.Request["inq"].ToString() + "'";
                    str = bll.MangeSelect(inq);
                    int AId = int.Parse(str.Rows[0]["AId"].ToString());
                    inq = " where AId=" + AId + " or PId = " + AId + "";
                    str = bll.MangeSelect(inq);
                }
                else
                {
                    inq = " where AName = '" + context.Request["inq"].ToString() + "'";
                    str = bll.MangeSelect(inq);
                    int AId = int.Parse(str.Rows[0]["AId"].ToString());
                    inq = " where AId=" + AId + "";
                    str = bll.MangeSelect(inq);
                }
            }
            else
            {
                str = bll.MangeSelect(inq);
            }
            context.Response.Write(GetTreeJsonByTable(str, "AId", "AName", "PIName", "PId", str.Rows[0]["PId"]));
        }

        /// <summary>
        /// 根据DataTable生成Json树结构
        /// </summary>
        /// <param name="tabel">数据源</param>
        /// <param name="idCol">ID列 AId</param>
        /// <param name="txtCol">Text列 AName</param>
        /// <param name="rela">关系字段(字典表中的树结构字段) PId</param>
        /// <param name="pId">父ID(0) str</param>
        StringBuilder result = new StringBuilder();
        StringBuilder sb = new StringBuilder();
        private string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol,string PIName, string rela, object pId)
        {
            result.Append(sb.ToString());
            sb.Clear();
            if (tabel.Rows.Count > 0)
            {
                sb.Append("[");
                string filer = string.Format("{0}='{1}'", rela, pId);
                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"name\":\"" + row[txtCol] + "\",\"PIName\":\"" + row[PIName] +"\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            sb.Append(",\"children\":");
                            GetTreeJsonByTable(tabel, idCol, txtCol, PIName, rela, row[idCol]);
                            result.Append(sb.ToString());
                            sb.Clear();
                        }
                        result.Append(sb.ToString());
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb.ToString());
                sb.Clear();
            }
            return result.ToString();
        }

        private string GetTreeJsonByTableT(DataTable tabel, string idCol, string txtCol, string PIName, string rela, object pId)
        {
            result.Append(sb.ToString());
            sb.Clear();
            if (tabel.Rows.Count > 0)
            {
                sb.Append("[");
                string filer = string.Format("{0}='{1}'", rela, pId);
                DataRow[] rows = tabel.Select(filer);
                if (rows.Length > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"PIName\":\"" + row[PIName] + "\"");
                        if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
                        {
                            sb.Append(",\"children\":");
                            GetTreeJsonByTableT(tabel, idCol, txtCol, PIName, rela, row[idCol]);
                            result.Append(sb.ToString());
                            sb.Clear();
                        }
                        result.Append(sb.ToString());
                        sb.Clear();
                        sb.Append("},");
                    }
                    sb = sb.Remove(sb.Length - 1, 1);
                }
                sb.Append("]");
                result.Append(sb.ToString());
                sb.Clear();
            }
            return result.ToString();
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