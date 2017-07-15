using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp.XSS_Demo
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        protected void PopulateControls()
        {
            string strQs = string.Empty;
            if (Request.QueryString["strErr"] != null)
            {
                strQs = Request.QueryString["strErr"] as string;
                lblStatusInfo.Text = strQs;
                HideLabel();
            }
            NoCache(); //remove cache
            ReadFromCookies();
        }

        void ReadFromCookies()
        {
            lblCookies.Text = string.Empty;
            if (Response.Cookies["email"] != null)
            {
                HttpCookie aCookie = Request.Cookies["email"];
                if (!string.IsNullOrEmpty(aCookie.Value))
                {
                    lblCookies.Text = "Data from cookies:" + aCookie.Value;
                }
            }
        }

        //create cookies
        void FakeCookies()
        {
            Response.Cookies["username"].Value = txtUserName.Text;
            Response.Cookies["username"].Expires = DateTime.Now.AddDays(1);

            Response.Cookies["password"].Value = txtPass.Text;
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(1);
        }

        void NoCache()
        {
            Response.AddHeader("Cache-Control", "no-cache");
            Response.Expires = -1;
            Response.Cache.SetNoStore();
            Response.AddHeader("Pragma", "no-cache");
        }

        void HideLabel()
        {
            string strScript = string.Empty;
            string strCtrl = lblStatusInfo.ClientID;
            strScript = "<script>HideCtrl('" + strCtrl + "', '5000')</script>"; //hide after 3 sec
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), strScript, false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
            {
                using (SqlCommand comand = connect.CreateCommand())
                {
                    comand.CommandText = "SELECT Name, Password, Email FROM Member WHERE Name = '" + txtUserName.Text + "' AND Password = '" + txtPass.Text + "'";
                    connect.Open();
                    using (SqlDataReader reader = comand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblStatusInfo.Text = "Login successful";
                            FakeCookies();
                        }
                        else
                        {
                            Response.Redirect("~/XSS%20Demo/LoginPage.aspx?strErr=Invalid Username or Password");
                        }
                    }
                    connect.Close();
                }
            }
            HideLabel();
        }
    }
}