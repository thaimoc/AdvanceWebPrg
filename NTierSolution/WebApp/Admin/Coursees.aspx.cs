using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Controls;
using Entities;
using DAL.Sql;

namespace WebApp.Admin
{
    public partial class Coursees : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        protected void PopulateControls()
        {
            string courid = Request["CourseesID"] ?? "";
            if (courid != "")
            {
                coursesView.Visible = false;                
                editCourse.CourseID = Convert.ToInt32(courid);
                editCourse.PopulateControls();
            }
            else
            {
                editCourse.Visible = false;
                coursesView.Visible = true;
                coursesView.PopulateControls();
            }
            lnkDeleteAllSelected.Visible = coursesView.Visible;
        }
        
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            coursesView.Submit_Click += new Controls.CoursesView.CoursesViewSubmitHandler(Submit_Click);
            lnkNew.Click += new EventHandler(lnkNew_Click);
            lnkDeleteAllSelected.Click += new EventHandler(lnkDeleteAllSelected_Click);
        }

        void lnkDeleteAllSelected_Click(object sender, EventArgs e)
        {
            string query = Request["cid"].ToString();
            using (GeneralRepository<DAL.Sql.Modles.Course> rp = new GeneralRepository<DAL.Sql.Modles.Course>())
            {
                if (query.Contains(','))
                {
                    string[] cids = query.Split(',');
                    foreach (var i in cids)
                    {
                        int id = Convert.ToInt32(i);
                        rp.Delete(x => x.CourseID == id);
                    }
                }
                else
                {
                    int id = Convert.ToInt32(query);
                    rp.Delete(x => x.CourseID == id);
                }
            }
            PopulateControls();
        }

        void lnkNew_Click(object sender, EventArgs e)
        {
            Response.Redirect(Link.ToAdminEditCourse("-1"));
        }

        public void Submit_Click(object obj)
        {
            Response.Redirect(Link.ToAdminEditCourse(obj.ToString()));
        }
    }
}