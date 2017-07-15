using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using WebApp.Admin.Controls;
using Entities;
using DAL.Sql;

namespace WebApp.Admin
{
    public partial class Categories : PageBase
    {
        private int EditIndex
        {
            get { return (int)ViewState["EditIndex"]; }
            set { ViewState["EditIndex"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EditIndex = -1;
                PopulateControls();                
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //lnkAdd.Click += new EventHandler(lnkAdd_Click);
            editCategory.Submit_Click += new SubmitHandler(Submit_Click);
            //repCategories.ItemCommand += new RepeaterCommandEventHandler(repCategories_ItemCommand);
            repCategories.ItemDataBound += new RepeaterItemEventHandler(repCategories_ItemDataBound);
            lnkDeleteSelected.Click += new EventHandler(lnkDeleteSelected_Click);
        }

        void lnkDeleteSelected_Click(object sender, EventArgs e)
        {
            string cids = Request["cid"].ToString();
            string[] ids = null;
            using (GeneralRepository<Category> repository = new GeneralRepository<Category>())
            {
                if (cids.Contains(','))
                {
                    ids = cids.Split(',');
                    foreach (string i in ids)
                    {
                        int id = Convert.ToInt32(i);
                        repository.Delete(x => x.CategoryID == id);
                    }
                }
                else
                {
                    int id = Convert.ToInt32(cids);
                    repository.Delete(x => x.CategoryID == id);
                }
            }
            PopulateControls();
        }

        void repCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.ItemIndex == EditIndex)
                {
                    //PlaceHolder p = e.Item.FindControl("updatePlaceHodler") as PlaceHolder;
                    //p.Visible = true;
                    EditCategory inSideEditCategory = e.Item.FindControl("inSideEditCategory") as EditCategory;
                    inSideEditCategory.Visible = true;
                    //inSideEditCategory.Submit_Click += new SubmitHandler(Submit_Click);
                    inSideEditCategory.CategoryID = (e.Item.DataItem as Category).CategoryID;
                    inSideEditCategory.PopulateControls();
                    //EditCategory editCata = new EditCategory();
                    //editCata.ID = "editCata";                                       
                    //p.Controls.Add(editCata);

                }
            }
        }

        protected void repCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            bool rs = false;
            if (e.CommandName == "UpdateIsActive")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                
                using (GeneralRepository<Category> repository = new GeneralRepository<Category>())
                {
                    Category cata = repository.Find(x => x.CategoryID == id).FirstOrDefault();
                    cata.IsActive = !cata.IsActive;
                    rs = repository.Update(cata);
                }
                
            }
            else if (e.CommandName == "edit")
            {
                EditIndex = e.Item.ItemIndex;
            }

            //if (rs)
            //{
                PopulateControls();
            //}
        }

        public void Submit_Click()
        {  
            string page = Request["Page"] ?? "";
            if (page == "")
            {
                Response.Redirect(Link.ToAdminCategories());
            }
            else
            {
                Response.Redirect(Link.ToAdminCategories(page));
            }
        }

        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            newPalaceHolder.Visible = !newPalaceHolder.Visible;
        }
                
        private void PopulateControls()
        {
            using (CourseEntities context = new CourseEntities())
            {
                repCategories.DataSource = context.Categories.AsQueryable().ToList();
                repCategories.DataBind();
            }
        }
    }
}