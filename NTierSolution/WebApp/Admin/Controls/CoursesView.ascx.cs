using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql;
using Entities;

namespace WebApp.Admin.Controls
{
    public partial class CoursesView : System.Web.UI.UserControl
    {
        public delegate void CoursesViewSubmitHandler(object obj);
        public CoursesViewSubmitHandler Submit_Click;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    PopulateControls();
            //}
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //repCourses.ItemCommand += new RepeaterCommandEventHandler(repCourses_ItemCommand);
        }

        protected void repCourses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                if (Submit_Click != null)
                {
                    Submit_Click(id);
                }
            }
            if (e.CommandName == "UpdateIsActive")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                //using(GeneralRepository<DAL.Sql.Modles.Course> ref = new GeneralRepository<DAL.Sql.Modles.Course>)
                //{

                //}
            }
        }

        public void PopulateControls()
        {
            using (GeneralRepository<DAL.Sql.Modles.Course> repository = new GeneralRepository<DAL.Sql.Modles.Course>())
            {
                repCourses.DataSource = repository.All().ToList();
                repCourses.DataBind();
            }
        }

        public string ShowData(object input, string columnName)
        {
            DAL.Sql.Modles.Course data = input as DAL.Sql.Modles.Course;
            switch (columnName)
            {
                case "CourseID":
                    return String.Format("<input type='checkbox' name='cid' id='cid' value='{0}' />", data.CourseID);
                case "IsActive":
                    return data.IsActive != null ? ((bool)data.IsActive ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                default:
                    return "";
            }

        }
    }
}