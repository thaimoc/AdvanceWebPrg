using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql;

namespace WebApp.Admin.Controls
{
    public partial class EditCourse : System.Web.UI.UserControl
    {
        public int CourseID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(txtID.Text) | txtID.Text == "")
                    return -1;
                return Convert.ToInt32(txtID.Text);
            }
            set
            {
                txtID.Text = value.ToString();
            }
        }

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
           //btnSave.Click += new EventHandler(btnSave_Click);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool rs = false;
            using (GeneralRepository<DAL.Sql.Modles.Course> repository = new GeneralRepository<DAL.Sql.Modles.Course>())
            {
                DAL.Sql.Modles.Course data = null;
                if (CourseID != -1)
                {
                    data = repository.Find(x => x.CourseID == CourseID).FirstOrDefault();
                    rs = repository.Update(GetData(data));
                    lblSatusInfo.Text = rs ? "Updating is successful!" : "Updating had been failed!";
                }
                else
                {
                    data = new DAL.Sql.Modles.Course();
                    rs = repository.Add(GetData(data)) > 0;
                    lblSatusInfo.Text = rs ? "Inserting is successful!" : "Inserting had been failed!";
                }
            }
            if (rs)
            {
                PopulateControls();
            }
        }

        public void PopulateControls()
        {
            using (DAL.Sql.Modles.CourseEntities context = new DAL.Sql.Modles.CourseEntities())
            {
                ddlCategories.DataSource = context.Categories.AsQueryable().ToList();
                ddlCategories.DataTextField = "Name";
                ddlCategories.DataValueField = "CategoryID";
                ddlCategories.DataBind();

                ddlMembers.DataSource = context.Members.AsQueryable().ToList();
                ddlMembers.DataTextField = "Name";
                ddlMembers.DataValueField = "MemberID";
                ddlMembers.DataBind();

                if (CourseID != -1)
                {
                    SetData(context.Courses.FirstOrDefault(x => x.CourseID == CourseID));
                }
            }
        }

        private void SetData(DAL.Sql.Modles.Course source)
        {
            txtID.Text = source.CourseID.ToString();
            txtName.Text = source.Name;
            txtStartDate.Text = source.StartDate.ToString();
            txtFee.Text = source.Fee.ToString();
            txtDuration.Text = source.Duration.ToString();
            chkIsActive.Checked = source.IsActive == null? false : Convert.ToBoolean(source.IsActive);
            txtIntroduction.Text = source.Introduction;
            ddlMembers.SelectedValue = source.TearcherID.ToString();
            ddlCategories.SelectedValue = source.CategoryID.ToString();
        }

        private DAL.Sql.Modles.Course GetData(DAL.Sql.Modles.Course source)
        {
            source.Name = txtName.Text;
            source.CategoryID = Convert.ToInt32(ddlCategories.SelectedValue);
            source.TearcherID = Convert.ToInt32(ddlMembers.SelectedValue);
            source.StartDate = Convert.ToDateTime(txtStartDate.Text);
            source.Duration = Convert.ToInt32(txtDuration.Text);
            source.Fee = Convert.ToDecimal(txtFee.Text);
            source.IsActive = chkIsActive.Checked;
            source.Introduction = txtIntroduction.Text;
            return source;
        }
    }
}