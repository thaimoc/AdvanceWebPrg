using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class GetIp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        protected void PopulateControls()
        {
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                txtIp.Text = sv.GetClientIP();
            }
        }
    }
}