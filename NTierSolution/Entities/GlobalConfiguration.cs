using System;
using System.Configuration;

namespace Entities
{
    public class GlobalConfiguration
    {
        private static int pageSize;
        private static string siteName;
        private static int descriptionLength;
        private static int imagesPerPage;
        private static int topArticles;

        public static int TopArticles { get { return topArticles; } }

        public static int PageSize
        {
            get { return pageSize; }
        }
        public static int DescriptionLength
        {
            get { return descriptionLength; }
        }
        public static string SiteName
        {
            get { return siteName; }
        }
        public static int ImagesPerPage
        {
            get { return imagesPerPage; }
        }

        static GlobalConfiguration()
        {
            pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
            descriptionLength = Convert.ToInt32(ConfigurationManager.AppSettings["DesLength"]);
            siteName = ConfigurationManager.AppSettings["SiteName"];
            imagesPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["ImagesPerPage"]);
            topArticles = Convert.ToInt32(ConfigurationManager.AppSettings["TopArticles"]);
        }
    }
}
