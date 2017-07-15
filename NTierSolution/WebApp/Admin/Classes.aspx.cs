using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;

namespace WebApp.Admin
{
    public partial class Classes : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            string query = Request.QueryString["Register"] ?? "";
            if (query != "")
            {
                lnkDeleteAllSelected.Visible = false;
                classesView.Visible = false;
                editClass.Visible = true;
                editClass.PopulateControls();
            }
            else
            {
                classesView.Visible = true;
                editClass.Visible = false;
                classesView.PopulateControls();
            }
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(Link.ToAdminClass(true));
        }
    }
}