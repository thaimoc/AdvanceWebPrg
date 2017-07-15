using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Sql.Modles
{
    public partial class Course
    {
        public string CategoryName
        {
            get {
                string name = null;
                using (CourseEntities context = new CourseEntities())
                {
                    name = context.Categories.FirstOrDefault(x => x.CategoryID == CategoryID).Name;
                }
                return name;
            }
        }

        public string TeacherName
        {
            get
            {
                string name = null;
                using (CourseEntities context = new CourseEntities())
                {
                    name = context.Members.FirstOrDefault(x => x.MemberID == TearcherID).Name;
                }
                return name;
            }
        }
    }
}
