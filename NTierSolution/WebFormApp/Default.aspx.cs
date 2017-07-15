using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TempValue"] = "";
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            btnView.Click += new EventHandler(btnView_Click);
        }

        void btnView_Click(object sender, EventArgs e)
        {
            if (Session["TempValue"] == null)
            {
                Session["TempValue"] = txtValue.Text;
            }
            else
            {
                Session["TempValue"] = Session["TempValue"] + txtValue.Text;
            }
            string s = Session["TempValue"].ToString();

            ScriptManager.RegisterStartupScript(Page, GetType(), "JCSCRIP", String.Format("window.alert('{0}');", s), true);
        }
    }
}