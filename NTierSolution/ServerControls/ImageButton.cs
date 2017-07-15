using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ImageButton runat=server></{0}:ImageButton>")]
    public class ImageButton : Button
    {
        [Bindable(true), Category("Appearance"), Description("Set or Get image's url of the button"), Localizable(true)]
        public new string ImageUrl
        {
            get
            {
                return ViewState["Image"] == null ? null : (string)ViewState["Image"];
            }
            set
            {
                ViewState["Image"] = value;
            }
        }
        public new string Text
        {
            get
            {
                return ViewState["Text"] == null ? null : (string)ViewState["Text"];
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();           
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Style, @"padding-left:20px;padding-bottom:8px;padding-top:8px;background-image:url('"+ImageUrl+"');background-repeat:no-repeat;background-position:left center; -moz-border-radius: 5px;-webkit-border-radius: 5px;");
            writer.RenderBeginTag(HtmlTextWriterTag.Button);
            writer.Write(Text);
            writer.RenderEndTag();
        }
    }
}
