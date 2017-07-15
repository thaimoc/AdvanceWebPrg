using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;

namespace ServerControls
{
    //[ToolboxData(@"<{0}:RequireTextBox runat=""server"" />")]
    //[Designer("ServerControls.RequireTexBoxDesigner, ServerControls")]
    public class RequireTextBox: CompositeControl
    {
    //    Panel pnl;
    //    LabeledTextBox txt;
    //    RequiredFieldValidator vld;
    //    [Category("Appearance"), Description("Set or Get label of the textbox"), Localizable(true)]
    //    public string Label
    //    {
    //        get
    //        {
    //            EnsureChildControls();
    //            ViewState["Label"] = txt.LabelText;
    //            string s = (string)ViewState["Label"];
    //            return s == null ? String.Empty : s;
    //        }
    //        set
    //        {
    //            ViewState["Label"] = value;
    //        }
    //    }
    //    [Category("Appearance"), Description("Set or Get text of the textbox"), Localizable(true)]
    //    public string Text
    //    {
    //        get
    //        {
    //            EnsureChildControls();
    //            ViewState["Text"] = txt.Text;
    //            string s = (string)ViewState["Text"];
    //            return s == null ? String.Empty : s;
    //        }
    //        set
    //        {
    //            EnsureChildControls();
    //            ViewState["Text"] = value;
    //        }
    //    }
    //    [Category("Appearance"), Description("Set or Get validate error of the textbox"), Localizable(true)]
    //    public string ErrorMessage
    //    {
    //        get
    //        {
    //            EnsureChildControls();
    //            return vld.ErrorMessage;
    //        }
    //        set
    //        {
    //            EnsureChildControls();
    //            vld.ErrorMessage = value;
    //        }
    //    }
    //    [Category("Appearance"), Description("Set background-color of the textbox"), Localizable(true)]
    //    public Color Background_color
    //    {
    //        set
    //        {
    //            EnsureChildControls();
    //            pnl.Style.Add("background-color", value.ToString());
    //        }
    //    }

    //    [Category("Appearance"), Description("Set width of the panel of the textbox"), Localizable(true)]
    //    public int WidthPanel
    //    {
    //        set
    //        {
    //            EnsureChildControls();
    //            pnl.Style.Add("width", value.ToString());
    //        }
    //    }

    //    protected override void CreateChildControls()
    //    {
    //        //base.CreateChildControls();
    //        pnl = new Panel();
    //        txt = new LabeledTextBox();
    //        txt.LabelText = "label";
    //        vld = new RequiredFieldValidator();
    //        vld.ControlToValidate = txt.txtID;
    //        vld.ErrorMessage = "afdasd";
    //        vld.Display = ValidatorDisplay.Dynamic;
    //        Controls.Add(pnl);
    //        pnl.Controls.Add(txt);
    //        pnl.Controls.Add(vld);
    //        pnl.Style.Add("background-color", "silver");
    //        pnl.Style.Add("width", "300px");
    //    }
    }
}
