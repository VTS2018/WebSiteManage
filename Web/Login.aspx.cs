using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            AdminLogin();
        }

        public void AdminLogin()
        {
            WebSiteModel.Admin admin = new WebSiteModel.Admin();
            string[] arr = Maticsoft.DBUtility.PubConstant.Admin.Split('|');
            admin.User = arr[0];
            admin.Password = arr[1];

            if ((this.txtUser.Text == admin.User) && (this.txtpwd.Text == admin.Password))
            {
                Session["admin"] = admin;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Write("<script>alert('不能登录！')</script>");
                //Response.End();
            }
        }
    }
}