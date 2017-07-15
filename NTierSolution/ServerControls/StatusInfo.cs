using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:StatusInfo runat=server></{0}:StatusInfo>")]
    public class StatusInfo : CompositeControl
    {
        [Bindable(true), Category("Appearance"), Description("Set or Get image's url of the button"), Localizable(true)]
        public virtual int UserAccessed
        {
            get
            {
                return ViewState["UserAccessed"] == null ? 0 : (int)ViewState["UserAccessed"];
            }
            set
            {
                ViewState["UserAccessed"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get image's url of the button"), Localizable(true)]
        public virtual int UserOnline
        {
            get
            {
                return ViewState["UserOnline"] == null ? 0 : (int)ViewState["UserOnline"];
            }
            set
            {
                ViewState["UserOnline"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get image's url of the button"), Localizable(true)]
        public virtual string ImageUrl
        {
            get
            {
                return ViewState["ImageUrl"] == null ? null : (string)ViewState["ImageUrl"];
            }
            set
            {
                ViewState["ImageUrl"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get status accessed lable"), Localizable(true)]
        public virtual string StatusAccesed
        {
            get
            {
                return ViewState["StatusAccesed"] == null ? "Số lượng người truy cập" : (string)ViewState["StatusAccesed"];
            }
            set
            {
                ViewState["StatusAccesed"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get status online lable"), Localizable(true)]
        public virtual string StatusOnline
        {
            get
            {
                return ViewState["StatusOnline"] == null ? "Online" : (string)ViewState["StatusAccesed"];
            }
            set
            {
                ViewState["StatusOnline"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            Image img = new Image();
            img.ImageUrl = ImageUrl;            
            Controls.Add(img);
            Label lb = new Label();
            lb.Text = " " + StatusAccesed + String.Format("({0})", UserAccessed) + " | " + StatusOnline + String.Format(": ({0})", UserOnline);
            Controls.Add(lb);
        }
    }
}
