using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebUsingService
{
    public partial class Upload : System.Web.UI.Page
    {
        public string id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"] ?? "";
            if (!IsPostBack)
            {
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            // Thu muc chua hinh anh
            string imageFolder = MapPath("~/Uploads");
            DirectoryInfo dir = new DirectoryInfo(imageFolder);
            FileInfo[] allFiles = dir.GetFiles();
            // Tong so hinh trong thu muc 
            int totalFiles = allFiles.Length;

            // Chi lay nhung file hinh cua trang hien tai
            FileInfo[] files = allFiles.OrderByDescending(x => x.CreationTime).ToArray();
            
            // Dua vao DataList
            dlImage.DataSource = files;
            dlImage.DataBind();
        }


        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        private static string BuildAbsolute(string relativeUrl)
        {
            Uri uri = HttpContext.Current.Request.Url;
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
                app += "/";
            relativeUrl = relativeUrl.TrimStart('/');
            return HttpUtility.UrlPathEncode(
                String.Format("http://{0}:{1}{2}{3}",
                uri.Host, uri.Port, app, relativeUrl));
        }

        public static string ToUploadImage(string fileName)
        {
            return BuildAbsolute(String.Format("Uploads/{0}", fileName));
        }

    }
}