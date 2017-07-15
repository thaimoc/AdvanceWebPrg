using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp.Controls
{
    public partial class StatusUserOnline : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblUserIsOnline.Text = Application["IsOnlineUser"].ToString();
                lblUserAccessed.Text = Application["IsUserAccess"].ToString();
            }
        }
    }
}