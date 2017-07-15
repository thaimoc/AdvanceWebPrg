using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebFormApp
{
    public static class Log
    {
        private static string _fileName = null;
        public static string FileName
        {
            get
            {
                if (_fileName == null)
                {
                    _fileName = HttpContext.Current.Server.MapPath("App_Data/Log.txt");
                }
                return _fileName;
            }
        }

        public static string UserIsOnlineFileName
        {
            get { return HttpContext.Current.Server.MapPath("App_Data/UserIsOnline.txt"); }
        }

        public static Boolean WriteLog(string content)
        {
            //Pass the filepath and filename to the StreamWriter Constructor
            using (StreamWriter sw = File.AppendText(FileName))
            {
                try
                {
                    //Write a second line of text
                    sw.WriteLine(content);
                    //Close the file
                    sw.Close();
                    return true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static Boolean WriteUserIsOnline(int count)
        {
            using (StreamWriter sw = new StreamWriter(UserIsOnlineFileName))
            {
                try
                {
                    //Write a second line of text
                    sw.WriteLine(count.ToString());
                    //Close the file
                    sw.Close();
                    return true;
                }
                catch (IOException e)
                {
                    throw e;
                }
            }
        }

        public static int ReadUserIsOnline()
        {
            using (StreamReader rd = new StreamReader(UserIsOnlineFileName))
            {
                try
                {
                    string line = rd.ReadToEnd();
                    return Convert.ToInt32(line);
                }
                catch (IOException e)
                {
                    throw e;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}