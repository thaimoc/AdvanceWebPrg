using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Sql.Modles
{
    public partial class Category
    {
        public string ParentName
        {
            get {
                if(ParentID == null)
                    return null;
                using (CourseEntities context = new CourseEntities())
                {
                    return context.Categories.FirstOrDefault(x => x.CategoryID == ParentID).Name;
                }
            }
        }
    }
}
