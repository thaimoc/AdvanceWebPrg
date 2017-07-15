using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormApp.Admin
{
    public static class Helper
    {
        public static string GetMembershipProvider()
        {
            return "CustomMembershipProvider";
        }
    }
}