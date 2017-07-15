using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entities;
using DALClass = DAL.Sql.Modles.Class;
using DAL.Sql;

namespace WebApp.Admin.Controls
{
    public partial class ClassesView : System.Web.UI.UserControl
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
            using (GeneralRepository<DALClass> rep = new GeneralRepository<DALClass>())
            {
                repData.DataSource = rep.All().ToList();
            }
            repData.DataBind();
        }

        public string ShowData(object input, string columnName)
        {
            DAL.Sql.Modles.Class data = input as DAL.Sql.Modles.Class;
            switch (columnName)
            {
                case "ID":
                    return String.Format("<input type='checkbox' name='cid' id='cid' value='{0}' />", data.CourseID + "_" + data.MemberID);
                case "Completed":
                    return data.Completed != null ? ((bool)data.Completed ? Link.ToAdminImage("checkbox.png") : Link.ToAdminImage("none.png")) : Link.ToAdminImage("none.png");
                default:
                    return "";
            }

        }
    }
}