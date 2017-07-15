using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class WebFormChungThuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                MyService.ChungThuc ct = new MyService.ChungThuc();
                ct.UserName = txtUserName.Text;
                ct.Password = txtPass.Text;
                lblStatusInfo.Text = sv.ChungThucSoapHeader(ct);
            }
        }
    }
}