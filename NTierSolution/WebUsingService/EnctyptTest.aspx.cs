using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class EnctyptTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                if (ddlAlgorythm.SelectedValue == "MD5")
                {
                    txtEncrypt.Text = sv.MD5Encrypt(txtEncrypt.Text);
                }
                else
                {
                    txtEncrypt.Text = sv.SHA1Encrypt(txtEncrypt.Text);
                }
            }
        }
    }
}