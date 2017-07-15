using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApp.Admin.Controls
{
    public partial class ThemeSwitch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
                ddlThemes.SelectedValue = Session["Theme"] == null ? "Blue" : Session["Theme"].ToString();
            }
        }

        private void BindData()
        {
            var list = new List<string>();
            var themePath = Server.MapPath("~/App_Themes");
            var dir = new DirectoryInfo(themePath);
            foreach (var item in dir.GetDirectories())
                list.Add(item.Name);

            ddlThemes.DataSource = list;
            ddlThemes.DataBind();
        }

        protected void ddlThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["Theme"] = ddlThemes.SelectedValue;
            Server.Transfer(Request.FilePath);
        }

        
    }
}