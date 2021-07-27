using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZSPrj
{
    public class LogenRe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.Session["PI"] ==null)
            {
                Response.Redirect("~/SignOut.aspx");
            }
        }
    }
}