using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DAL.Sql.Modles;


namespace WebApp.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.QueryString["ReturnUrl"];
            if (string.IsNullOrWhiteSpace(url))
            {
                RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            }
            else
            {
                RegisterUser.ContinueDestinationPageUrl = Link.ToDefault();
            }
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            string continueUrl = Request.QueryString["ReturnUrl"];
            //string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            Member newMB = new Member()
            {
                MemberID = 0,
                Name = RegisterUser.UserName,
                Password = RegisterUser.Password,
                Email = RegisterUser.Email,
                CreateDate = DateTime.Now,
                LastLogin = DateTime.Now,
                IsActive = false
            };
            using (CourseEntities context = new CourseEntities())
            {
                context.Members.AddObject(newMB);
                context.SaveChanges();
            }
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

    }
}
