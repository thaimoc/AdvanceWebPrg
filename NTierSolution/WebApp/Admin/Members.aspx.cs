using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using BLL;
using DAL.Sql;
using Entities;
using System.Web.Security;
using Entities.IRepository;

namespace WebApp.Admin
{
    public partial class Members : PageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            int howManyPages = 0;
            int PageSize = GlobalConfiguration.PageSize;
            string page = Request.QueryString["Page"] ?? "1";

            string firstPageUrl = Link.ToAdminMembers();
            string pagerUrl = Link.ToAdminMembers("3");

            using(CourseEntities context = new CourseEntities())
            {
                howManyPages = (int)Math.Ceiling(((double)context.Members.Count()) / PageSize);
                IQueryable<Member> query = context.Members.OrderBy(x => x.MemberID);
                query = query.Skip((Convert.ToInt32(page) - 1) * PageSize);
                int count = query.Count();
                int len = count > PageSize ? PageSize : count;
                repMembers.DataSource = query.Take(len).ToList();
            }
            repMembers.DataBind();
            pagerTop.Show(int.Parse(page), howManyPages, firstPageUrl, pagerUrl, false);
            pagerBottom.Show(int.Parse(page), howManyPages, firstPageUrl, pagerUrl, true);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //lnkDeleteSelected.Click += new EventHandler(lnkDeleteSelected_Click);
            //repMembers.ItemCommand += new RepeaterCommandEventHandler(repMembers_ItemCommand);
        }

        protected void repMembers_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "UpdateIsActive")
            {
                int id = Convert.ToInt32(e.CommandArgument.ToString());
                using (CourseEntities context = new CourseEntities())
                {
                    Member data = context.Members.FirstOrDefault(x => x.MemberID == id);
                    data.IsActive = !data.IsActive;
                    context.SaveChanges();
                }
            }
            PopulateControls();
        }

        protected void lnkDeleteSelected_Click(object sender, EventArgs e)
        {
            string cids = Request["cid"];
            using (CourseEntities context = new CourseEntities())
            {
                MemberManager manager = new MemberManager(new GeneralRepository<Member>(context));
                if (cids.Contains(','))
                {
                    string[] ids = cids.Split(',');

                    foreach (var i in ids)
                    {
                        int j = Convert.ToInt32(i);
                        Member mb = manager.Find(x => x.MemberID == j).Result.FirstOrDefault();
                        Membership.DeleteUser(mb.Name);
                        manager.Delete(j);
                    }
                }
                else
                {
                    int j = Convert.ToInt32(cids);
                    Member mb = manager.Find(x => x.MemberID == j).Result.FirstOrDefault();
                    Membership.DeleteUser(mb.Name);
                    manager.Delete(j);
                }
            }
            PopulateControls();
        }
    }
}