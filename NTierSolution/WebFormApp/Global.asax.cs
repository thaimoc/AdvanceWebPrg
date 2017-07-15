using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Globalization;
using System.Reflection;

namespace WebFormApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Application Start", s));
            Application["IsOnlineUser"] = 0;
            Application["IsUserAccess"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Session Start", s));
            //int count = Log.ReadUserIsOnline();
            //Log.WriteUserIsOnline(++count);

            Application.Lock();
            Application["IsOnlineUser"] = (int)Application["IsOnlineUser"] + 1;
            Application["IsUserAccess"] = (int)Application["IsUserAccess"] + 1;
            Application.UnLock();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

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
            Application.Lock();
            Application["IsOnlineUser"] = (int)Application["IsOnlineUser"] - 1;
            Application.UnLock();

            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Session End", s));

            //int count = Log.ReadUserIsOnline();
            //Log.WriteUserIsOnline(--count);            
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //http://weblogs.asp.net/scottgu/archive/2005/12/14/433194.aspx
            //HttpRuntime runtime = (HttpRuntime)typeof(System.Web.HttpRuntime).InvokeMember("_theRuntime",
            //                                                                        BindingFlags.NonPublic
            //                                                                        | BindingFlags.Static
            //                                                                        | BindingFlags.GetField,
            //                                                                        null,
            //                                                                        null,
            //                                                                        null);

            //if (runtime == null)
            //    return;

            //string shutDownMessage = (string)runtime.GetType().InvokeMember("_shutDownMessage",
            //                                                                 BindingFlags.NonPublic
            //                                                                 | BindingFlags.Instance
            //                                                                 | BindingFlags.GetField,
            //                                                                 null,
            //                                                                 runtime,
            //                                                                 null);

            //string shutDownStack = (string)runtime.GetType().InvokeMember("_shutDownStack",
            //                                                               BindingFlags.NonPublic
            //                                                               | BindingFlags.Instance
            //                                                               | BindingFlags.GetField,
            //                                                               null,
            //                                                               runtime,
            //                                                               null);
            string s = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Log.WriteLog(String.Format("-- {0} Application End", s));
        }
    }
}
