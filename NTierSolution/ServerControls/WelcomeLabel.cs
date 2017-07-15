using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;
using System;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:WelcomeLabel runat=server></{0}:WelcomLable>")]
    public class WelcomeLabel : Label
    {
       [Bindable(true),
       Category("Appearance"),
       DefaultValue("The text to display when the user is not logged in."),
       Description(),
       Localizable(true)
       ]
        public virtual string DefaultUserName
        {
            get
            {
                return ViewState["DefaultUserName"] == null ? String.Empty : ViewState["DefaultUserName"].ToString();
            }
            set
            {
                ViewState["DefaultUserName"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.WriteEncodedText(Text);
            string displayUserName = DefaultUserName;
            if (Context != null)
            {
                string userName = Context.User.Identity.Name;
                if (!String.IsNullOrEmpty(userName))
                {
                    displayUserName = userName;
                }
            }
            if (!String.IsNullOrEmpty(displayUserName))
            {
                writer.Write(", ");
                writer.WriteEncodedText(displayUserName);
            }

            writer.Write("!");
        }


    }
}
