using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZSPrj
{
    public partial class Login : LogenRe
    {
        BLL.PersonnelInformation bll = new BLL.PersonnelInformation();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["PI"] == null)
            //{
            //    Response.Redirect("~/SignOut.aspx");
            //}
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string PIUser = txtPIUser.Text;
            string PIpwd = txtPIpwd.Text;
            DataTable dt = bll.DL("and PIUser = '" + PIUser + "'and PIpwd = '" + PIpwd + "'");
            if (dt.Rows.Count > 0)
            {
                Model.PersonnelInformation PI = new Model.PersonnelInformation();
                PI.PIid = int.Parse(dt.Rows[0]["PIid"].ToString());
                PI.PIName = dt.Rows[0]["PIName"].ToString();
                PI.PIUser = dt.Rows[0]["PIUser"].ToString();
                PI.PIpwd = dt.Rows[0]["PIpwd"].ToString();
                PI.PIAccount = int.Parse(dt.Rows[0]["PIAccount"].ToString());
                PI.PowerName = dt.Rows[0]["PowerName"].ToString();
                Session["PI"] = PI;
                Session["PIa"] = int.Parse(dt.Rows[0]["PIid"].ToString());
                BLL.Temporarytransfer temporarytransfer = new BLL.Temporarytransfer();
                //查询转院数据条数
                //DataTable dta = temporarytransfer.Transfer(PI);
                //Session["a"] = (int)dta.Rows[0]["num"];
                
                DataTable dtt = temporarytransfer.SelectTemporarytransfer(PI);
                for (int i = 0; i < dtt.Rows.Count; i++)
                {
                    if (PI.PIid == int.Parse(dtt.Rows[i]["Teacher"].ToString()))
                    {
                        Session["TEM"] = "tem";
                    }
                }
                Response.Redirect("Main.aspx");
            }
            else
            {
                lagMsg.Text = "用户名或密码不正确";
            }
        }
    }
}