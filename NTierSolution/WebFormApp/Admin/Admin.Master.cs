using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormApp.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptMenu.DataSource = SiteMap.RootNode.ChildNodes;
                rptMenu.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            rptMenu.ItemDataBound += new RepeaterItemEventHandler(rptMenu_ItemDataBound);
        }

        void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HyperLink lnk = (HyperLink)e.Item.FindControl("lnk");
            SiteMapNode node = (SiteMapNode)e.Item.DataItem;
            lnk.NavigateUrl = node.Url;
            lnk.Text = node.Title;
        }
    }
}