using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;

namespace WebLab2
{
    public partial class _Default : System.Web.UI.Page
    {
        Dictionary<DateTime, int> testData = new Dictionary<DateTime, int>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();
            
        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            Random rd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 10; i++)
            {
                testData.Add(DateTime.Now.AddDays(i), rd.Next(1, 50));
            }
            Chart1.Series["Testing"].Points.DataBind(testData, "Key", "Value", string.Empty);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Chart1.Series["Testing"].ChartType = SeriesChartType.Pie;
            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            Chart1.ChartAreas[0].Area3DStyle.Inclination = 5;
        }
    }
}
