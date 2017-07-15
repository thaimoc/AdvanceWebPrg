using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class HtmlScrapingWeather : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateControls();
        }

        protected void PopulateControls()
        {
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                repData.DataSource = sv.GetWeatherInfo();
            }
            repData.DataBind();
        }

        protected string ShowWeather(object obj, string columnName)
        {
            MyService.City city = obj as MyService.City;
            MyService.WeatherInfo info = city.Weather;

            switch (columnName)
            {
                case "Temp":
                    return info.Temp;
                case "Condition":
                    return info.Condition;
                case "Image":
                    return info.Image;
                default:
                    return String.Empty;
            }
        }

        protected string GetWeatherInfo(object obj, int idex, string columnName)
        {
            MyService.City city = obj as MyService.City;
            MyService.WeatherInfo[] infos = city.Weathers;

            switch (columnName)
            {
                case "Temp":
                    return infos[idex].Temp;
                case "Condition":
                    return infos[idex].Condition;
                case "Image":
                    return infos[idex].Image;
                default:
                    return String.Empty;
            }
        }
    }
}