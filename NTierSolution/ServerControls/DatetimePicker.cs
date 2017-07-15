using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:DatetimePicker runat=\"server\"></{0}:DatetimePicker>")]
    public class DatetimePicker : TextBox
    {
        [Bindable(true), Category("Appearance"), Description("Set or Get label of the Datetime Picker"), Localizable(true)]
        public new string Lable 
        {
            get 
            {
                return ViewState["DatetimePickerLabel"] == null ? "Date: " : ViewState["DatetimePickerLabel"].ToString();
            }
            set
            {
                ViewState["DatetimePickerLabel"] = value;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css");
            writer.RenderBeginTag(HtmlTextWriterTag.Link);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Src, "http://code.jquery.com/jquery-1.9.1.js");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.RenderEndTag();
            writer.AddAttribute(HtmlTextWriterAttribute.Src, "http://code.jquery.com/ui/1.10.3/jquery-ui.js");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.Write("$(function () { $('.datepicker').datepicker();});");
            writer.RenderEndTag();

            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(Lable);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "datepicker");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
    }
}
