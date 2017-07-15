using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Controls
{
    public partial class Pager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Show(int currentPage, int howManyPages, string firstPageUrl, string pageUrlFormat, bool showPages)
        {
            if (howManyPages > 1)
            {
                this.Visible = true;
                lblCurrentPage.Text = currentPage.ToString();
                lblHowManyPages.Text = howManyPages.ToString();

                if (currentPage == 1)
                {
                    lnkPrevious.Enabled = false;
                    lnkPrevious.CssClass = "disabled";
                }
                else
                {
                    lnkPrevious.NavigateUrl = currentPage == 2 ?
                        firstPageUrl : String.Format(pageUrlFormat, currentPage - 1);
                }

                if (currentPage == howManyPages)
                {
                    lnkNext.Enabled = false;
                    lnkNext.CssClass = "disabled";
                }
                else
                {
                    lnkNext.NavigateUrl = String.Format(pageUrlFormat, currentPage + 1);
                }

                if (showPages)
                {
                    PageUrl[] pages = new PageUrl[howManyPages];
                    pages[0] = new PageUrl("1", firstPageUrl);
                    for (int i = 2; i <= howManyPages; i++)
                    {
                        pages[i - 1] = new PageUrl(i.ToString(), String.Format(pageUrlFormat, i));
                    }
                    if (currentPage > 0 && currentPage <= howManyPages)
                        pages[currentPage - 1] = new PageUrl(currentPage.ToString(), "");

                    repPager.DataSource = pages;
                    repPager.DataBind();
                }
            }
            else
            {
                this.Visible = false;
            }
        }
    }

    public class PageUrl
    {
        private string page;
        public string Page
        {
            get { return page; }
        }

        private string url;
        public string Url
        {
            get { return url; }
        }

        public PageUrl(string page, string url)
        {
            this.page = page;
            this.url = url;
        }
    }
}