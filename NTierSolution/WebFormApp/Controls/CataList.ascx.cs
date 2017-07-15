using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL.Sql.Modles;
using DAL.Sql;
using Entities;
using System.Data;

namespace WebFormApp.Controls
{
    public partial class CataList : System.Web.UI.UserControl
    {
        static CategoryManager manager;
        string categoryID = "";
        public CataList()
        {
            manager = new CategoryManager();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            categoryID = Request.QueryString["CategoryID"];            
            if (!IsPostBack)
            {
                PopulateControls();                
            }
        }

        private void PopulateControls()
        {
            //using (CategoryManager manager = new CategoryManager())
            //{
                List<Category> cataLevel1 = manager.Find(c => c.IsActive == true).Result.ToList();
                MenuNode root = ConvertToTree(cataLevel1);
                MyMenu.Items.Clear();
                foreach (MenuNode topLevelNode in root.Children)
                {
                    MyMenu.Items.Add(topLevelNode.ToMenuItem()); // Visits all nodes in the tree.
                }
            //}
        }
               
        // Assuming table is ordered.
        static MenuNode ConvertToTree(List<Category> list)
        {
            var map = new Dictionary<int?, MenuNode>();
            map[0] = new MenuNode() { Id = 0}; // root node

            MenuNode newNodeHome = new MenuNode()
            {
                Id = int.MaxValue,
                ParentId = 0,
                Url = Link.BuildAbsolute("Default.aspx"),
                Description = "Home"
            };
            map[0].Children.Add(newNodeHome);

            foreach (Category item in list)
            {
                MenuNode newNode = new MenuNode()
                {
                    Id = item.CategoryID,
                    ParentId = 0,
                    Url = Link.ToCategory(item.CategoryID.ToString()),
                    Description = item.Name
                };
                if (item.ParentID == null || (item.ParentID != null && manager.Find(x=>x.CategoryID == item.ParentID && x.IsActive == false).Result.Count > 0))
                {
                    map[0].Children.Add(newNode);
                }
                else
                {
                    newNode.ParentId = item.ParentID;                    
                    map[newNode.ParentId].Children.Add(newNode);
                }
                map[item.CategoryID] = newNode;
            }
            return map[0]; // root node
        }
    }

    public class MenuNode
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<MenuNode> Children { get; set; }

        public MenuNode()
        {
            Children = new List<MenuNode>();
        }

        // Will visit all descendants and turn them into menu items.
        public MenuItem ToMenuItem()
        {
            MenuItem item = new MenuItem(Description) { NavigateUrl = Url };
            foreach (MenuNode child in Children)
            {
                item.ChildItems.Add(child.ToMenuItem());
            }
            return item;
        }
    }
}