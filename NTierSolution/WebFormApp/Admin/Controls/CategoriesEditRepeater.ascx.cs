using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL.Sql;
using Entities.IRepository;
using DAL.Sql.Modles;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace WebFormApp.Admin.Controls
{
    public partial class CategoriesEditRepeater : System.Web.UI.UserControl
    {
        IGeneralRepository<DAL.Sql.Modles.Category> repository;
        CategoryManager manager;
        List<DAL.Sql.Modles.Category> list;
        public CategoriesEditRepeater()
        {
            repository = new GeneralRepository<DAL.Sql.Modles.Category>();
            manager = new CategoryManager(repository);
            list = repository.All().ToList();
            //foreach (var item in list)
            //{
            //    if (item.ParentID != null)
            //    item.ParentName = repository.Single(item.ParentID).Name;
            //}
        }

        public DAL.Sql.Modles.Category Data { get; set; }
        private int EditIndex
        {
            get { return (int)ViewState["EditIndex"]; }
            set { ViewState["EditIndex"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Data = new DAL.Sql.Modles.Category();
            if (!IsPostBack)
            {
                EditIndex = -1;
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            rptCategories.DataSource = list;
            rptCategories.DataBind();
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            rptCategories.ItemDataBound += new RepeaterItemEventHandler(rptCategories_ItemDataBound);
            rptCategories.ItemCommand += new RepeaterCommandEventHandler(rptCategories_ItemCommand);
        }

        void rptCategories_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "update")
                EditIndex = e.Item.ItemIndex;
            else if (e.CommandName == "changeIsActive")
            {
                string[] args = e.CommandArgument.ToString().Split('_');
                DAL.Sql.Modles.Category data = repository.Single(int.Parse(args[0]));
                data.IsActive = !Boolean.Parse(args[1]);
                string errorMessage = manager.InsertOrUpdate(data).GetErrorMessages();
                if (errorMessage.Length > 0)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", String.Format("ShowError('{0}');", errorMessage.Substring(0, errorMessage.Length > 100 ? 100 : errorMessage.Length - 1) + "..."), true);
                }
                EditIndex = -1;
            }
            else if (e.CommandName == "save")
            {
                if (Data != null)
                {
                    HiddenField t = e.Item.FindControl("categoryIDHidden") as HiddenField;
                    Data = repository.Single(int.Parse(t.Value));

                    HtmlInputHidden temp = e.Item.FindControl("nameHidden") as HtmlInputHidden;
                    Data.Name = temp.Value;

                    temp = e.Item.FindControl("descriptionHidden") as HtmlInputHidden;
                    Data.Description = temp.Value;

                    HtmlInputHidden temps = e.Item.FindControl("parentNameHidden") as HtmlInputHidden;
                    try
                    {
                        Data.ParentID = int.Parse(temps.Value);
                    }
                    catch
                    {
                        Data.ParentID = null;
                    }

                    List<string> liMessage = manager.Validate(Data).Messages;
                    string mgs;
                    if (liMessage.Count > 0)
                    {
                        mgs = liMessage[0];
                        ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", String.Format("ShowError(\"" + "{0}" + "\");", mgs.Substring(0, mgs.Length > 90 ? 90 : mgs.Length - 1) + "..."), true);
                    }
                    else
                    {
                        mgs = manager.InsertOrUpdate(Data).GetErrorMessages();
                        if (mgs.Length > 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", String.Format("ShowError(\"" + "{0}" + "\");", mgs.Substring(0, mgs.Length > 90 ? 90 : mgs.Length - 1) + "..."), true);
                        }
                        else
                        {
                            string s = String.Format("ShowInfo(\"{0}\")", String.Format("Update category have id = {0} successfull", Data.CategoryID));
                            ScriptManager.RegisterStartupScript(Page, GetType(), "JsStatus", s, true);
                            EditIndex = -1;                           
                        }
                    }
                }
            }
            PopulateControls();
        }

        void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
            if (e.Item.ItemType == ListItemType.AlternatingItem ||
                e.Item.ItemType == ListItemType.Item )
            {               

                if (e.Item.ItemType == ListItemType.AlternatingItem
                    || e.Item.ItemType == ListItemType.Item)
                {
                    if (e.Item.ItemIndex == EditIndex)
                    {
                        Data = (DAL.Sql.Modles.Category)e.Item.DataItem;
                        PlaceHolder p = e.Item.FindControl("nameEditPlaceHolder") as PlaceHolder;

                        TextBox t = new TextBox();
                        t.ID = "nameEdit";
                        t.Text = Data.Name;
                        p.Controls.Add(t);

                        //RequiredFieldValidator rquireName = new RequiredFieldValidator();
                        //rquireName.ID = "rquireName";
                        //rquireName.InitialValue = "0";
                        //rquireName.Text = "*";
                        //rquireName.ErrorMessage = "Name is require field";
                        //rquireName.ForeColor = Color.Red;
                        //rquireName.ControlToValidate = t.ClientID;
                        //rquireName.Display = ValidatorDisplay.Dynamic;
                        //PlaceHolder tp = e.Item.FindControl("rquireNamePlaceHolder") as PlaceHolder;
                        //tp.Controls.Add(rquireName);

                        HyperLink lnkName = e.Item.FindControl("name") as HyperLink;
                        lnkName.Visible = false;

                        p = e.Item.FindControl("descriptionEditPlaceHolder") as PlaceHolder;
                        
                        t = new TextBox();
                        t.ID = "descriptionEdit";
                        t.CssClass = "inputbox";
                        //t.Columns = 50;
                        //t.Rows = 7;
                        t.MaxLength = 4000;                        
                        //t.TextMode = TextBoxMode.MultiLine;
                    
                        if (Data.Description != null)
                            t.Text = Data.Description;
                        else
                            t.Text = String.Empty;

                        p.Controls.Add(t);

                        Label l = e.Item.FindControl("description") as Label;
                        l.Visible = false;

                        HtmlInputHidden h = e.Item.FindControl("nameHidden") as HtmlInputHidden;
                        h.Visible = true;
                        h = e.Item.FindControl("descriptionHidden") as HtmlInputHidden;
                        h.Visible = true;

                        p = e.Item.FindControl("parentNamePlaceHolder") as PlaceHolder;

                        DropDownList ddlParents = new DropDownList();
                        ddlParents.ID = "parentEdit";

                                                                        
                        ddlParents.AppendDataBoundItems = true;
                        ddlParents.Items.Add("--No Parent --");
                        ddlParents.DataSource = list.Where(x=>x.CategoryID != Data.CategoryID).ToList();                        
                        ddlParents.DataValueField = "CategoryID";
                        ddlParents.DataTextField = "Name";
                        int? idParent = ((DAL.Sql.Modles.Category)e.Item.DataItem).ParentID;
                        if (idParent != null)
                            ddlParents.SelectedValue = idParent.ToString();
                        else
                            ddlParents.SelectedIndex = -1;
                        ddlParents.DataBind();
                        
                        //ScriptManager.RegisterStartupScript(Page, GetType(), "", "alert('Selected Value is : ' + $('[id*=parentEdit] option:selected').val())", true);

                        p.Controls.Add(ddlParents);

                        HyperLink hpl = e.Item.FindControl("parentName") as HyperLink;
                        hpl.Visible = false;

                        ImageButton b = e.Item.FindControl("Edit") as ImageButton;
                        b.Visible = false;

                        //b = e.Item.FindControl("Delete") as ImageButton;
                        //b.CommandName = "save";
                        //b.OnClientClick = "OnSave(this)";
                        //b.ImageUrl = "~/Admin/Images/base_floppydisk_32.png";                        
                    }
                    
                }
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                DropDownList ddl = (DropDownList)e.Item.FindControl("ddlParents");
                if (ddl != null)
                {
                    ddl.DataSource = list;
                    ddl.DataValueField = "CategoryID";
                    ddl.DataTextField = "Name";
                    ddl.DataBind();
                }
            }
            
        }

        
                        
    }
}