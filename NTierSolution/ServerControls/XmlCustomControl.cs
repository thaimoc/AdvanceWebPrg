using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:XmlCustomControl runat=\"server\"></{0}:XmlCustomControl>")]
    public class XmlCustomControl : WebControl
    {
        [Bindable(true), Category("Appearance"), Description(""), Localizable(true)]
        public new string XmlPath
        {
            get
            {
                return ViewState["XmlPath"] == null ? "" // "D:/KimNguyen's Data/Advance Web Programming/dlu/Lab/NTierSolution/WebLab2/App_Data/XMLFile.xml" 
                    : ViewState["XmlPath"].ToString();
            }
            set
            {
                ViewState["XmlPath"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description(""), Localizable(true)]
        public new string Text
        {
            get
            {
                return ViewState["Text"] == null ? String.Empty : ViewState["Text"].ToString();
            }
            set
            {
                ViewState["Text"] = value;
            }
        }

        public static string ReadXmlData(string filePath)
        {
            String ruslt = "";
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine() + sr.ReadLine();
                    ruslt += line;
                    ruslt += "<tr><th>Mã số SV</th><th>Họ Tên</th><th>Lớp</th><th>Học kỳ</th><th>Diểm TB</th></tr>";
                    while((line = sr.ReadLine()) != null)
                    {
                        ruslt += line;
                    }
                }
            }
            catch (Exception e)
            {
                ruslt = "The file could not be read: " + e.Message;
            }
            return ruslt;
        }

        public static string ConvertXmlTextToHtmlText(string inputText)
        {
            // Replace all start and end tags. 
            //string startPattern = @"<([^>]+)>";
            //Regex regEx = new Regex(startPattern);
            //string outputText = regEx.Replace(inputText, "&lt;<b>$1&gt;</b>");

            string startPattern = @"Students";
            Regex regEx = new Regex(startPattern);
            string outputText = regEx.Replace(inputText, "Table");

            startPattern = @"Student";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "tr");

            startPattern = @"MSSV";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "td");

            startPattern = @"HoTen";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "td");

            startPattern = @"Lop";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "td");

            startPattern = @"HoKy";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "td");

            startPattern = @"DTB";
            regEx = new Regex(startPattern);
            outputText = regEx.Replace(outputText, "td");

            outputText = outputText.Replace(" ", "&nbsp;");
            outputText = outputText.Replace("\r\n", "<br />");
            return outputText;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (XmlPath != "")
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlPath);
                writer.RenderBeginTag(HtmlTextWriterTag.Table);
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write("MSSV");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write("Ho Ten");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write("Lop");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write("Hoc Ky");
                writer.RenderEndTag();
                writer.RenderBeginTag(HtmlTextWriterTag.Th);
                writer.Write("Diem TB");
                writer.RenderEndTag();
                writer.RenderEndTag();

                XmlNodeList list = doc.SelectNodes("//Student");


                if (list != null)
                {
                    foreach (XmlNode node in list)
                    {
                        writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.Write(node.SelectSingleNode("//MSSV").InnerText);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.Write(node.SelectSingleNode("//HoTen").InnerText);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.Write(node.SelectSingleNode("//Lop").InnerText);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.Write(node.SelectSingleNode("//HoKy").InnerText);
                        writer.RenderEndTag();
                        writer.RenderBeginTag(HtmlTextWriterTag.Td);
                        writer.Write(node.SelectSingleNode("//DTB").InnerText);
                        writer.RenderEndTag();
                        writer.RenderEndTag();
                    }
                }

                writer.RenderEndTag();
            }
        }

        
    }
}
