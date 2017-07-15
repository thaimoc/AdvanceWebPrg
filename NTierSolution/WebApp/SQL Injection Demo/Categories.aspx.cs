using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using DAL.Sql.Modles;

namespace WebApp.SQL_Injection_Demo
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                PopulateControls();
            //}
        }

        protected void PopulateControls()
        {
            string query = Request["name"] ?? "";
            if (query != "")
            {
                repCategories.DataSource = FindByName(query);
            }
            else
            {
                repCategories.DataSource = FindByName("");
            }
            repCategories.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("http://localhost:1272/SQL%20Injection%20Demo/Categories.aspx?name={0}", txtName.Text));
        }

        protected List<Category> FindByName(string name)
        {
            List<Category> list = new List<Category>();
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString))
            {
                cnn.Open();
                SqlCommand cmd = cnn.CreateCommand();
                if(name == "")
                    cmd.CommandText = "SELECT * FROM Category";
                else
                    cmd.CommandText = "SELECT * FROM Category WHERE Name LIKE '%" + name + "%'";
                SqlDataReader rdr = null;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    list.Add(new DAL.Sql.Modles.Category()
                    {
                        CategoryID = Convert.ToInt32(rdr["CategoryID"].ToString()),
                        Name = rdr["Name"].ToString(),
                        Description = rdr["Description"].ToString(),
                        ParentID =  -1,
                        IsActive = Convert.ToBoolean(rdr["IsActive"].ToString())
                    });
                }
                cnn.Close();
                rdr.Close();
            }
            return list;
        }

        
    }
}