using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class WeatherInfo
    {
        public string Temp { get; set; }
        public string Condition { get; set; }
        public string Image { get; set; }

        public string Date { get; set; }
    }

    public class City
    {
        public string Name { get; set; }        
        public WeatherInfo Weather { get; set; }

        public List<WeatherInfo> Weathers { get; set; }
        public City()
        {
            Weather = new WeatherInfo();
            Weathers = new List<WeatherInfo>();
        }

        public void Add(WeatherInfo wt)
        {
            Weathers.Add(wt);
        }
    }
}