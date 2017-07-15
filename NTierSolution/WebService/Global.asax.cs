using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");            
            Log.WriteLog(String.Format("-- {0} Application Start", s));

            Application["IsUserAccess"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Session Start", s));

            Application.Lock();
            Application["IsUserAccess"] = (int)Application["IsUserAccess"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //Log.WriteLog(String.Format("-- {0} -- {1} -- {2} Begin Request", ip, serviceName ,s));

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Session.Abandon();

            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Session End", s));
        }

        protected void Application_End(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Application End", s));
        }
    }
}