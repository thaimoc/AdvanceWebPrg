using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebFormApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["LoginReferrer"] = Request.QueryString["ReturnUrl"]??
                    (Page.Request.UrlReferrer != null ? Page.Request.UrlReferrer.ToString():"~/");
            }

            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("~/");
            }

            if(Session["LoginReferrer"]!=null)
                RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Session["LoginReferrer"].ToString());
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            LoginUser.LoggedIn += new EventHandler(LoginUser_LoggedIn);
        }

        void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            if(Session["LoginReferrer"] != null)
                Response.Redirect(Session["LoginReferrer"].ToString());
        }
    }
}