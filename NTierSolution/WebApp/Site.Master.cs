using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        //protected void Page_PreInit(object sender, EventArgs e)
        //{
        //    Page.Theme = Session["Theme"] == null ? "Blue" : Session["Theme"].ToString();
        //}

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
