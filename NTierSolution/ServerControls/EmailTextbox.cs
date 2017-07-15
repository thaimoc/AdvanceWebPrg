using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:EmailTextbox runat=server></{0}:EmailTextbox>")]
    public class EmailTextbox : CompositeControl
    {    
        Panel pnl;
        Label lbl;
        TextBox txt;
        RegularExpressionValidator vld;

        [Bindable(true), Category("Appearance"), Description("Set or Get label of the textbox"), Localizable(true)]
        public string LabelText
        {
            get
            {
                EnsureChildControls();
                ViewState["Label"] = lbl.Text;
                string s = (string)ViewState["Label"];
                return s == null ? String.Empty : s;
            }
            set
            {
                ViewState["Label"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get text of the textbox"), Localizable(true)]
        public string Text
        {
            get
            {
                EnsureChildControls();
                ViewState["Text"] = txt.Text;
                string s = (string)ViewState["Text"];
                return s == null ? String.Empty : s;
            }
            set
            {
                EnsureChildControls();
                ViewState["Text"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get validate error of the textbox"), Localizable(true)]
        public string ErrorMessage
        {
            get
            {
                EnsureChildControls();
                return vld.ErrorMessage;
            }
            set
            {
                EnsureChildControls();
                vld.ErrorMessage = value;
            }
        }


        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            pnl = new Panel();
            lbl = new Label();
            lbl.ID = "lbl";
            lbl.Text = "Email:";
            txt = new TextBox();
            txt.ID = "txt";
            txt.Text = "someting";
            vld = new RegularExpressionValidator();
            vld.ControlToValidate = txt.ID;
            vld.ValidationExpression = @"[A-Za-z0-9]+@[A-Za-z0-9]+\.[a-zA-Z]+";
            vld.ErrorMessage = "error message!";
            vld.Display = ValidatorDisplay.Dynamic;
            Controls.Add(pnl);

            pnl.Controls.Add(lbl);

            pnl.Controls.Add(txt);
            pnl.Controls.Add(vld);
            pnl.Style.Add("background-color", "silver");
            pnl.Style.Add("width", "300px");
        }
    }
}
