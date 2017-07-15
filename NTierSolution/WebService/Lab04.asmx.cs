using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using HtmlAgilityPack;
using System.Net;

namespace WebService
{
    /// <summary>
    /// Summary description for Lab04
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Lab04 : System.Web.Services.WebService
    {
        //[WebMethod]
        //[XmlInclude(typeof(Fraction))]
        //public Fraction Add(int xNumerator, int xDenominator, int yNumerator, int yDenominator)
        //{
        //    Fraction y = new Fraction(yNumerator, yDenominator);
        //    Fraction x = new Fraction(xNumerator, xDenominator);
        //    return x + y;
        //}

        private const string IMAGE = "http://hn.24h.com.vn/ttcb/thoitiet/";
        private const string strWeather = "http://hn.24h.com.vn/ttcb/thoitiet/thoitiet.php";

        [WebMethod]
        [XmlInclude(typeof(Fraction))]
        public Fraction Add(Fraction x, Fraction y)
        {
            return x + y;
        }

        [WebMethod]
        [XmlInclude(typeof(Fraction))]
        public Fraction Subtraction(Fraction x, Fraction y)
        {
            return x - y;
        }

        [WebMethod]
        public Fraction Multiplication(Fraction x, Fraction y)
        {
            return x * y;
        }

        [WebMethod]
        public Fraction Division(Fraction x, Fraction y)
        {
            return x / y;
        }

        public List<Fraction> ListFraction(int n)
        {
            List<Fraction> list = new List<Fraction>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(new Fraction(1, i));
            }
            return list;
        }

        [WebMethod]
        public string GetClientIP()
        {
            string hostName = "";
            IPHostEntry ip = new IPHostEntry();
            hostName = Dns.GetHostName();
            ip = Dns.GetHostByName(hostName);
            //lbTenMay.Text = ip.HostName;
            string ipp = "";// ip.AddressList[0].ToString();
            foreach (IPAddress item in ip.AddressList)
            {
                ipp += item.ToString();
            }
            return ipp;
        }

        [WebMethod]
        public decimal MoneyConvert(decimal x, MoneyConvertEnum type)
        {
          
            switch (type)
            {
                case MoneyConvertEnum.USD2VND:
                    return x * (decimal)21035.00; 
                case MoneyConvertEnum.VND2USD:
                    return x / (decimal)21035.00; 
                case MoneyConvertEnum.EUR2VND:
                    return x * (decimal)27149.73; 
                case MoneyConvertEnum.VND2EUR:
                    return x / (decimal)27149.73; 
                case MoneyConvertEnum.YP2VND:
                    return x * (decimal)202.79; 
                case MoneyConvertEnum.VND2YP:
                    return x / (decimal)202.79; 
                default:
                    return x;
            }            
        }

        [WebMethod]
        public long Factorial(int x)
        {
            long result = 0;
            for (int i = 2; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        [WebMethod]
        public List<int> NPrimeNumbers(int n)
        {
            List<int> result = new List<int>();
            for(int i = 2; ; i++)
            {
                if (IsPrime(i) > 0)
                {
                    result.Add(i);
                }
                if (result.Count == n)
                {
                    break;
                }
            }
            return result;
        }

        [WebMethod]
        public int IsPrime(int number)
        {
            if (number == 1)
            {
                return 0;
            }
            if (number == 2)
            {
                return 1;
            }
            if (number % 2 == 0)
            {
                return 0;
            }
            int n = (int)Math.Sqrt((double)number);
            for (int i = 3; i <= n; i = i + 2)
            {
                if (number % i == 0)
                    return 0;
            }
            return 1;
        }
        [WebMethod]
        public string MD5Encrypt(string s)
        {
            return Utilities.Crypto.MD5Encrypt(s);
        }

        [WebMethod]
        public string MD5FileEncrypt(string path)
        {
            return Utilities.Crypto.GetMD5Hash(path);
        }

        [WebMethod]
        public string SHA1Encrypt(string s)
        {
            return Utilities.Crypto.SHA1(s);
        }

        [WebMethod]
        public string SHA1FileEncrypt(string path)
        {
            return Utilities.Crypto.GetSHA1Hash(path);
        }

        public DataSet NorthwindCustomersAll(string northWindConnectionString)
        {
            DataSet rs = new DataSet();
            using (SqlConnection cnn = new SqlConnection(northWindConnectionString))
            {
                string comd = "SELECT * FROM Customers";
                cnn.Open();
                using( var adap = new SqlDataAdapter(comd, cnn))
                {
                    adap.Fill(rs, "Customers");
                }
                cnn.Close();
            }
            return rs;
        }

        [WebMethod]
        public List<Student> GetStudents(string url)
        {
            List<Student> list = new List<Student>();
            Student temp;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            //doc.Load(url);
            foreach (HtmlNode tr in doc.DocumentNode.SelectNodes(@"//tr[count(td)=4]"))
            {
                temp = new Student();
                bool start = true;
                foreach (HtmlNode i in tr.SelectNodes("td"))
                {
                    if (start)
                    {
                        start = false;
                        continue;
                    }
                    else
                    {
                        if (temp.Code == null)
                            temp.Code = i.InnerHtml;
                        else if (temp.LastName == null)
                            temp.LastName = i.InnerHtml;
                        else
                            temp.FirstName = i.InnerHtml;
                    }
                }
                list.Add(temp);
            }
            list.OrderBy(x => x.FirstName);
            return list;
        }

        [WebMethod]
        public List<string> GetStudentsNameOrderbyName(string url)
        {
            List<string> list = new List<string>();
            string temp;
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            //doc.Load(url);
            foreach (HtmlNode tr in doc.DocumentNode.SelectNodes(@"//tr[count(td)=4]"))
            {
                temp = "";
                int index = 0;
                foreach (HtmlNode i in tr.SelectNodes("td"))
                {
                    if (index == 2)
                    {
                        temp += i.InnerHtml + " ";
                    }
                    if (index == 3)
                    {
                        temp += i.InnerHtml;
                    }
                    index++;
                }
                list.Add(temp);
            }
            list.Sort();
            return list;
        }

        //lengocluyen@outlook.com
        [WebMethod(CacheDuration=600)]
        public List<City> GetWeatherInfo()
        {
            return GetWeatherInfo(strWeather);
        }
        
        private List<City> GetWeatherInfo(string url)
        {
            List<City> list = new List<City>();
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);
            City city;
            string dateUpdateWeather = doc.DocumentNode.SelectNodes("//html/body/div/div[3]/div[2]/table/tbody/tr[2]/td[2]/table[2]/tbody/tr/td/span")
                                                    .FirstOrDefault().InnerText;
            bool start = true;
            string currentDate = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[2]/table/tbody/tr[2]/td[2]/table[2]/tbody/tr/td[2]/i")
                        .FirstOrDefault().InnerText;
            string tomorow = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[2]/table/tbody/tr[2]/td[2]/table[2]/tbody/tr/td[3]/i")
                        .FirstOrDefault().InnerText;
            string nextTomorow = doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[2]/table/tbody/tr[2]/td[2]/table[2]/tbody/tr/td[4]/i")
                        .FirstOrDefault().InnerText;
            
            foreach (HtmlNode tr in doc.DocumentNode.SelectNodes("/html/body/div/div[3]/div[2]/table/tbody/tr[2]/td[2]/table[2]/tbody/tr[count(td[@valign='top'])=4]"))
            {
                if (start)
                {
                    start = false;
                    continue;
                }
                int index = 0;
                city = new City();
                HtmlNode strong = tr.SelectNodes("td/div/a/h3/strong").FirstOrDefault();                
                city.Name = strong.InnerHtml;
                city.Weather.Date = dateUpdateWeather;
                WeatherInfo info;
                bool begin = true;
                foreach (var td in tr.SelectNodes("td"))
                {
                    info = new WeatherInfo();
                    if (begin)
                    {
                        //HtmlNode img = td.SelectNodes("table/tbody/tr/td/img").FirstOrDefault();
                        //string s = IMAGE + img.Attributes["src"].Value;
                        //city.Weather.Image = s;
                        try
                        {
                            city.Weather.Image = IMAGE + td.SelectNodes("table/tbody/tr/td/img").FirstOrDefault().Attributes["src"].Value;
                            city.Weather.Condition = td.SelectNodes("table/tbody/tr/td[2]").FirstOrDefault().InnerHtml;
                            city.Weather.Temp = td.SelectNodes("table/tbody/tr/td[2]/span").FirstOrDefault().InnerHtml;
                        }
                        catch
                        {
                            city.Weather.Condition = "Thoi tiet dang cap nhat...";
                        }
                        begin = false;
                        continue;
                    }
                    info.Image = IMAGE + td.SelectNodes("div/img").FirstOrDefault().Attributes["src"].Value;
                    info.Condition = td.SelectNodes("div[2]/span[2]").FirstOrDefault().InnerText;
                    info.Temp = td.SelectNodes("div[2]/span").FirstOrDefault().InnerHtml;

                    if (index == 0)
                    {
                        info.Date = currentDate;
                    }
                    else if (index == 1)
                    {
                        info.Date = tomorow;
                    }
                    else if (index == 2)
                    {
                        info.Date = nextTomorow;
                    }

                    city.Add(info);
                    index++;
                }                
                list.Add(city);
            }
            return list;
        }

        public ChungThuc ct;
        [WebMethod(Description="asdfas")]
        [SoapHeader("ct")]
        public string ChungThucSoapHeader()
        {
            if (ct == null)
                return "Chua co thong tin chung thuc";
            if (ct.ChungT(ct.UserName, ct.Password))
                return "Chung thuc thanh cong";
            return "User name va password khong hop le";
        }

    }

    public class ChungThuc : SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ChungThuc()
        {

        }

        public bool ChungT(string u, string p)
        {
            return u == "abc";
        }
    }

    public enum MoneyConvertEnum
    {
        USD2VND,
        VND2USD,
        EUR2VND,
        VND2EUR,
        YP2VND,
        VND2YP
    }
}
