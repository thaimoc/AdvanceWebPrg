using System;
using System.Web;

namespace Entities
{
    public class Link
    {
        public static string BuildAbsolute(string relativeUrl)
        {
            Uri uri = System.Web.HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
                app += "/";
            relativeUrl = relativeUrl.TrimStart('/');
            return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}",
                uri.Host, uri.Port, app, relativeUrl));
        }

        public static string ToUploadImage(string fileName)
        {
            return BuildAbsolute(String.Format("Uploads/{0}", fileName));
        }

        public static string ToAdminUpload(string clientId, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("Admin/Upload.aspx?id={0}", clientId));
            return BuildAbsolute(String.Format("Admin/Upload.aspx?id={0}&Page={1}", clientId, page));
        }

        public static string ToAdminUpload(string clientId)
        {
            return ToAdminUpload(clientId, "1");
        }

        public static string ToCategory(string categoryId, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("Catalog.aspx?CategoryID={0}", categoryId));
            else
                return BuildAbsolute(String.Format("Catalog.aspx?CategoryID={0}&Page={1}", categoryId, page));
        }

        public static string ToCategory(string categoryId)
        {
            return ToCategory(categoryId, "1");
        }

        public static string ToDefault()
        {
            return BuildAbsolute("Default.aspx");
        }

        public static string ToRegister()
        {
            return BuildAbsolute("Register.aspx");
        }

        public static string ToAdminImage(string fileName)
        {
            return BuildAbsolute(String.Format("Admin/Images/{0}", fileName));
        }

        public static string ToAdminMembers(string page)
        {
            if (page == "1")
                return BuildAbsolute("Admin/Members.aspx");
            else
                return BuildAbsolute("Admin/Members.aspx?Page={0}");
        }

        public static string ToAdminMembers()
        {
            return ToAdminMembers("1");
        }

        public static string ToAdminCategories(string page)
        {
            if (page == "1")
                return BuildAbsolute("Admin/Categories.aspx");
            else
                return BuildAbsolute("Admin/Categories.aspx?Page={0}");
        }

        public static string ToAdminCategories()
        {
            return ToAdminCategories("1");
        }

        public static string ToAdminEditCourse(string id)
        {
            return BuildAbsolute(String.Format("Admin/Coursees.aspx?CourseesID={0}", id));
        }

        public static string ToAdminClass(bool register)
        {
            if (register)
            {
                return BuildAbsolute(String.Format("Admin/Classes.aspx?Register={0}", register.ToString()));
            }
            return BuildAbsolute("Admin/Classes.aspx");
        }

        public static string ToAdminClass()
        {
            return ToAdminClass(false);
        }
    }
}
