using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZSPrj.Handler
{
    /// <summary>
    /// LoginHandler 的摘要说明
    /// </summary>
    public class LoginHandler : IHttpHandler
    {
        BLL.PersonnelInformation bll = new BLL.PersonnelInformation();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (!String.IsNullOrEmpty(context.Request["para"]))
            {
                if (context.Request["para"] == "DL")
                {
                    LoginPIInfo(context);
                }
            }
        }

        private void LoginPIInfo(HttpContext context)
        {
           
           
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