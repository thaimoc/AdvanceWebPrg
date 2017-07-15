using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql;
using DALCouse = DAL.Sql.Modles.Course;
using DAL.Sql.Modles;
using Entities;

namespace WebApp.Admin.Controls
{
    public partial class EditClass : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    PopulateControls();
            //}
        }

        public void PopulateControls()
        {
            using (GeneralRepository<DALCouse> rep = new GeneralRepository<DALCouse>())
            {
                ddlCourses.DataSource = rep.All().ToList();
                ddlCourses.DataTextField = "Name";
                ddlCourses.DataValueField = "CourseID";
            }
            txtMember.Text = Page.User.Identity.Name;
            txtRegisterDay.Text = DateTime.Now.ToShortDateString();
            
            ddlCourses.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool rs = false;
            int memberId = -1;
            int courseId = -1;
            using (GeneralRepository<DALCouse> rep = new GeneralRepository<DALCouse>())
            {
                courseId = Convert.ToInt32(ddlCourses.SelectedValue);
                DALCouse cour = rep.Find(x => x.CourseID == courseId).FirstOrDefault();
                if (DateTime.Now > cour.StartDate)
                {
                    rs = false;
                }
                else if (DateTime.Now < cour.StartDate)
                {
                    rs = true;
                }
            }
            if (!rs)
            {
                CustomValid.ErrorMessage = "Course have been opened and don't register!";
                CustomValid.IsValid = rs;
                return;
            }
            using (GeneralRepository<Member> rep = new GeneralRepository<Member>())
            {
                string userName = Page.User.Identity.Name;
                Member usr = rep.Find(x => x.Name == userName).FirstOrDefault();
                if (usr != null)
                {
                    rs = usr.Password == txtPassword.Text;
                    memberId = usr.MemberID;
                }
                else
                {
                    CustomValidatorPass.ErrorMessage = "Your is not a member";
                    rs = false;
                }
            }
            if (!rs)
            {
                CustomValidatorPass.IsValid = rs;
               return;
            }
            if (memberId != -1 && courseId != -1)
            {
                using (GeneralRepository<Class> rp = new GeneralRepository<Class>())
                {
                    if (rp.Find(x => x.CourseID == courseId && x.MemberID == memberId).Count() > 0)
                    {
                        CustomValid.ErrorMessage = "You had been choosed this course";
                        CustomValid.IsValid = false;
                    }
                    else
                    {
                        rs = rp.Add(GetData(memberId)) > 0;
                    }
                }
            }
            lblStatus.Text = rs ? "Inseting have been successed!":"Inserting have been failed";
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private DAL.Sql.Modles.Class GetData(int memberId)
        {
            return new Class()
            {
                CourseID = Convert.ToInt32(ddlCourses.SelectedValue),
                MemberID = memberId,
                RegisterDay = DateTime.Now,
                Completed = false,
                Assessement = txtAssessement.Text
            };
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlCourses.SelectedIndex = -1;
            lblStatus.Text = "";
            txtAssessement.Text = "";
        }

        
        
    }
}