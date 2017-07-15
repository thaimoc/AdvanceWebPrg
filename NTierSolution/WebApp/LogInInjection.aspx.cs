using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp
{
    public partial class LogInInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                cmd.CommandText = "SELECT Name, Password FROM Member WHERE Name = '" + txtName.Text + "' AND Password = '" + txtPass.Text + "'";
                SqlDataReader rdr = null;

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {                    
                    lblStatus.Text = "Log in successful!";
                    lblInfo.Text = String.Format("UserName: {0}, password: {1}", rdr["Name"].ToString(), rdr["Password"].ToString());
                }
                else
                {
                    lblStatus.Text = "Log in failed!";
                    lblInfo.Text = "";
                }
                cnn.Close();
                rdr.Close();
            }
        }
    }
}