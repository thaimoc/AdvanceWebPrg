using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using Entities.IRepository;
using DAL.Sql;
using Entities;

namespace WebApp.Admin.Controls
{
    public delegate void SubmitHandler();
    public partial class EditCategory : System.Web.UI.UserControl
    {
        public int CategoryID
        {
            get {
                if (string.IsNullOrWhiteSpace(lblID.Text) | lblID.Text == "")
                    return -1;
                return Convert.ToInt32(lblID.Text); 
            }
            set { lblID.Text = value.ToString(); }
        }

        public SubmitHandler Submit_Click;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                PopulateControls();
            }
        }

        public void PopulateControls()
        {
            if (CategoryID == -1)
            {
                btnSave.ImageUrl = Link.ToAdminImage("1367839550_plus-24.png");
            }
            else
            {
                btnSave.ImageUrl = Link.ToAdminImage("1367839767_new-24.png");
            }
            SetData();
            using (CourseEntities context = new CourseEntities())
            {
                ddlParent.DataSource = context.Categories.AsQueryable().ToList();
                ddlParent.DataTextField = "Name";
                ddlParent.DataValueField = "CategoryID";
                ddlParent.DataBind();
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //btnSave.Click += new ImageClickEventHandler(btnSave_Click);
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            int rs = 0;
            using (CourseEntities context = new CourseEntities())
            {
                using (GeneralRepository<Category> repository = new GeneralRepository<Category>(context))
                {
                    if (CategoryID == -1)
                    {
                        if (repository.Find(x => x.Name == txtName.Text).Count() > 0)
                        {
                            nameCustomValidator.IsValid = false;
                        }
                        else
                        {
                            nameCustomValidator.IsValid = true;
                            rs = repository.Add(GetData(new Category()));
                        }
                    }
                    else
                    {
                        repository.Update(GetData(repository.Find(x => x.CategoryID == CategoryID).FirstOrDefault()));
                    }
                }                
            }

            if (rs > 0)
            {
                if (Submit_Click != null)
                    Submit_Click();
            }
        }

        private void SetData()
        {
            if (CategoryID != -1)
            {
                using (CourseEntities context = new CourseEntities())
                {
                    using (GeneralRepository<Category> repository = new GeneralRepository<Category>(context))
                    {
                        Category data = repository.Find(x => x.CategoryID == CategoryID).FirstOrDefault();
                        txtName.Text = data.Name;
                        txtDescription.Text = data.Description;
                        chkIsActive.Checked = data.IsActive == null ? false : Convert.ToBoolean(data.IsActive);
                        lblID.Text = data.CategoryID.ToString();
                    }
                }
            }
        }

        private Category GetData(Category result)
        {
            result.Name = txtName.Text;
            result.IsActive = chkIsActive.Checked;
            result.Description = txtDescription.Text;
            int parentId = Convert.ToInt32(ddlParent.SelectedValue);
            if (CategoryID != -1)
            {
                result.CategoryID = CategoryID;
            }             
            if (parentId > 0)
            {
              result.ParentID = parentId;
            }            
            return result;
        }

        

    }
}