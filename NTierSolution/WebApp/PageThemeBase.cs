using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class PageThemeBase : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = Session["Theme"] == null ? "Blue" : Session["Theme"].ToString();
        }
    }
}