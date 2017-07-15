using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Sql.Modles;
using Entities;

namespace WebApp
{
    public class PageBase : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["Theme"] == null)
                Session["Theme"] = "Blue";
            Page.Theme = Session["Theme"].ToString();
        }

        public string ShowData(object input, string columnName, string typeClass)
        {            
            
            switch (typeClass)
            {
                case "Member":
                    {
                        Member data = input as Member;
                        switch (columnName)
                        {
                            case "MemberID":
                                return String.Format("<input type='checkbox' name='cid' id='cid' value='{0}' />", data.MemberID);
                            case "IsActive":
                                return data.IsActive != null ? ((bool)data.IsActive ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                            default:
                                return "";
                        }
                    }
                case "Category":
                {
                    Category data = input as Category;
                    switch (columnName)
                    {
                        case "CategoryID":
                            return String.Format("<input type='checkbox' name='cid' id='cid' value='{0}' />", data.CategoryID);
                        case "IsActive":
                            return data.IsActive != null ? ((bool)data.IsActive ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                        default:
                            return "";
                    }
                }
                case "Course":
                {
                    Course data = input as Course;
                    switch (columnName)
                    {
                        case "CategoryID":
                            return String.Format("<input type='checkbox' name='cid' id='cid' value='{0}' />", data.CourseID);
                        case "IsActive":
                            return data.IsActive != null ? ((bool)data.IsActive ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                        default:
                            return "";
                    }
                }
                default:
                    return "";
            }
            
        }
    }
}