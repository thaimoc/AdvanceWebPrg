using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Sql.Modles;
using BLL;
using DAL.Sql;
using BLL.Validation;
using Entities;

namespace WebFormApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
           // CreateUserWizard.CreatedUser += new EventHandler(CreateUserWizard_CreatedUser);
            CreateUserWizard.ContinueButtonClick += new EventHandler(CreateUserWizard_ContinueButtonClick);
        }

        void CreateUserWizard_ContinueButtonClick(object sender, EventArgs e)
        {
            Response.Redirect(Link.ToDefault());
        }

        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
        {
            Member newMember = new Member()
            {
                MemberID = 0,
                Name = CreateUserWizard.UserName,
                Email = CreateUserWizard.Email,
                Password = CreateUserWizard.Password,
                CreateDate = DateTime.Now,
                LastLogin = DateTime.Now,
                IsActive = false
            };
            using (CourseEntities context = new CourseEntities())
            {
                MemberManager manager = new MemberManager(new GeneralRepository<Member>());
                //ValidationResult validate = manager.Validate(newMember);
                //if (validate.Valid)
                //{
                //    //Thong bao loi va xoa user vua tao
                    
                //    return;
                //}
                manager.InsertOrUpdate(newMember);
            }
        }
    }
}