using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Sql.Modles
{
    public partial class Class
    {
        private string _CourseName = null;
        public string CourseName {
            get
            {
                if (_CourseName != null)
                    return _CourseName;
                using (CourseEntities context = new CourseEntities())
                {
                    _CourseName = context.Courses.FirstOrDefault(x => x.CourseID == CourseID).Name;
                }
                return _CourseName;
            }
        }
        private string _MemberName = null;
        public string MemberName {
            get
            {
                if (_MemberName != null)
                    return _MemberName;
                using (CourseEntities context = new CourseEntities())
                {
                    _MemberName = context.Members.FirstOrDefault(x => x.MemberID == MemberID).Name;
                }
                return _MemberName;
            } 
        }
    }
}
