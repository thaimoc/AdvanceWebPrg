using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace ServerControls
{
    //[ToolboxBitmap(typeof(LabeledTextBox), "Icon.bmp")]
    //[DefaultProperty("LabelText")]
    [ToolboxData(@"<{0}:LabeledTextbox runat=""server""/>")]
    [Designer("ServerControls.LabeledTextboxDesigner, ServerControls")]
    public class LabeledTextBox : TextBox
    {
        [Category("Appearance"),
        Description("Set the label of the textbox"),
        Localizable(true)]
        public string LabelText
        {
            get
            {
                string s = (string)ViewState["LabelText"];
                return s == null ? String.Empty : s;
            }
            set
            {
                ViewState["LabelText"] = value;
            }
        }

        public string txtID
        {
            get
            {
                return ClientID.ToString();
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(String.Format(@"<label for=""{0}"">{1}</label> ", this.ClientID, LabelText));
            base.Render(writer);
        }
    }
}
