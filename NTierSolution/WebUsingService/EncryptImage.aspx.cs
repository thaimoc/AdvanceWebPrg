using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class EncryptImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncrypt_Click(object sender, EventArgs e)
        {
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                string path = Server.MapPath(String.Format("Uploads/{0}", txtImagePath.Text));// "D:/KimNguyen's Data/Advance Web Programming/dlu/Lab/NTierSolution/WebUsingService/Uploads/4.jpg";// ToUploadImage(txtImagePath.Text);
               path = path.Replace('\\','/');
                if (rdMD5.Checked)
                {
                    txtEncryptText.Text = sv.MD5FileEncrypt(path);
                }
                else
                {
                    txtEncryptText.Text = sv.SHA1FileEncrypt(path);
                }
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