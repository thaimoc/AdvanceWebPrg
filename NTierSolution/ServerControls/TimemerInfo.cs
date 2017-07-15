using System;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI;

namespace ServerControls
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TimemerInfo runat=\"server\"></{0}:TimemerInfo>")]
    public class TimemerInfo : CompositeControl
    {
        private Image imgTime;
        private Image imgDate;
        private Label lblTime;
        private Label lblTimeInfo;
        private Label lblDate;
        private Label lblDateInfo;

        private Label lblSp;

        [Bindable(true), Category("Appearance"), Description(""), Localizable(true)]
        public virtual string TimeImageUrl
        {
            get
            {
                return ViewState["TimeImageUrl"] == null ? String.Empty : (string)ViewState["TimeImageUrl"];
            }
            set
            {
                ViewState["TimeImageUrl"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description(""), Localizable(true)]
        public virtual string DateImageUrl
        {
            get
            {
                return ViewState["DateImageUrl"] == null ? String.Empty : (string)ViewState["DateImageUrl"];
            }
            set
            {
                ViewState["DateImageUrl"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get status accessed lable"), Localizable(true)]
        public virtual string TitleTime
        {
            get
            {
                return ViewState["TitleTime"] == null ? "Thời gian" : (string)ViewState["TitleTime"];
            }
            set
            {
                ViewState["TitleTime"] = value;
            }
        }

        [Bindable(true), Category("Appearance"), Description("Set or Get status accessed lable"), Localizable(true)]
        public virtual string TitleDate
        {
            get
            {
                return ViewState["TitleDate"] == null ? "Ngày" : (string)ViewState["TitleDate"];
            }
            set
            {
                ViewState["TitleDate"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            imgTime = new Image();
            imgTime.ImageUrl = TimeImageUrl;
            //Controls.Add(img);
            lblTime = new Label();
            lblTime.Text = String.Format("{0}: ", TitleTime);
            lblTimeInfo = new Label();
            lblTimeInfo.ID = "showtime";
            //Controls.Add(lbl);

            lblSp = new Label();
            lblSp.Text = " | ";

            imgDate = new Image();
            imgDate.ImageUrl = DateImageUrl;
            //Controls.Add(img);
            lblDate = new Label();
            lblDate.Text = String.Format("{0}: ", TitleDate);
            //Controls.Add(lbl);   
            lblDateInfo = new Label();
            lblDateInfo.ID = "date";
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(@"
                <script type='text/jscript'>
            day = new Date();
            miVisit = day.getTime();
            function clock() {
                dayTwo = new Date();
                hrNow = dayTwo.getHours();
                mnNow = dayTwo.getMinutes();
                scNow = dayTwo.getSeconds();
                miNow = dayTwo.getTime();
                if (hrNow == 0) {
                    hour = 12;
                    ap = ' AM';
                } else if (hrNow <= 11) {
                    ap = ' AM';
                    hour = hrNow;
                } else if (hrNow == 12) {
                    ap = ' PM';
                    hour = 12;
                } else if (hrNow >= 13) {
                    hour = (hrNow - 12);
                    ap = ' PM';
                }
                if (hrNow >= 13) {
                    hour = hrNow - 12;
                }
                if (mnNow <= 9) {
                    min = '0' + mnNow;
                }
                else (min = mnNow)
                if (scNow <= 9) {
                    secs = '0' + scNow;
                } else {
                    secs = scNow;
                }

                time = hour + ':' + min + ':' + secs + ap;
                document.getElementById('showtime').innerHTML = time;
                self.status = time;
                setTimeout('clock()', 1000);
            };

            function ShowDate() {

                var months = new Array(13);
                months[1] = '01';
                months[2] = '02';
                months[3] = '03';
                months[4] = '04';
                months[5] = '05';
                months[6] = '06';
                months[7] = '07';
                months[8] = '08';
                months[9] = '09';
                months[10] = '10';
                months[11] = '11';
                months[12] = '12';
                var time1 = new Date();
                var lmonth1 = months[time1.getMonth() + 1];
                var date1 = time1.getDate();
                if (date1 < 10) date1 = '0' + date1;

                var year1 = time1.getFullYear();

                dateRE = ' ' + date1 + '/' + lmonth1 + '/' + year1;
                document.getElementById('date').innerHTML = dateRE;
            }

            $(document).ready(function () {
                clock(); ShowDate();
            });
        </script>
            ");

            imgTime.RenderControl(writer);
            lblTime.RenderControl(writer);

            lblTimeInfo.RenderControl(writer);

            lblSp.RenderControl(writer);

            imgDate.RenderControl(writer);
            lblDate.RenderControl(writer);
            lblDateInfo.RenderControl(writer);
        }

    }
}
