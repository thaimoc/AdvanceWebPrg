using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using BLL;
using DAL.Sql;
using Entities;

namespace WebFormApp.Admin
{
    public partial class Members : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            lnkDelete.Click += new EventHandler(lnkDelete_Click);
        }

        void lnkDelete_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PopulateControls()
        {
            using (CourseEntities context = new CourseEntities())
            {
                repMembers.DataSource = context.CreateObjectSet<Member>().AsQueryable().ToList();
                repMembers.DataBind();
            }
        }

        
    }
}