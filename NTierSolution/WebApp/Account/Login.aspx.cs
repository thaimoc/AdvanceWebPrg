using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoginUser.LoggingIn += new LoginCancelEventHandler(LoginUser_LoggingIn);
        }

        void LoginUser_LoggingIn(object sender, LoginCancelEventArgs e)
        {
            
        }
    }
}
