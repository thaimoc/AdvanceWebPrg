using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Sql.Modles;
using Entities;

namespace WebFormApp.Admin
{
    public class BasePage : System.Web.UI.Page
    {

        public string ShowData(object input, string columnName)
        {
            Member data = input as Member;
            switch (columnName)
            {
                case "MemberID":
                    return String.Format(
       "<input type='checkbox' name='cid' value='{0}' />", data.MemberID);
                case "IsActive":
                    return data.IsActive != null ? ((bool)data.IsActive ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                default:
                    return "";
            }
        }
    }


}