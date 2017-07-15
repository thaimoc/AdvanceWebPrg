using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUsingService
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            using(MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                switch ((MyService.MoneyConvertEnum)Enum.Parse(typeof(MyService.MoneyConvertEnum), ddlTypeConvert.SelectedValue))
                {
                    case WebUsingService.MyService.MoneyConvertEnum.USD2VND:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.USD2VND).ToString();
                        break;
                    case WebUsingService.MyService.MoneyConvertEnum.VND2USD:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.VND2USD).ToString();
                        break;
                    case WebUsingService.MyService.MoneyConvertEnum.EUR2VND:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.EUR2VND).ToString();
                        break;
                    case WebUsingService.MyService.MoneyConvertEnum.VND2EUR:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.VND2EUR).ToString();
                        break;
                    case WebUsingService.MyService.MoneyConvertEnum.YP2VND:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.YP2VND).ToString();
                        break;
                    case WebUsingService.MyService.MoneyConvertEnum.VND2YP:
                        txtConvertValue.Text = sv.MoneyConvert(Convert.ToDecimal(txtValue.Text), MyService.MoneyConvertEnum.VND2YP).ToString();
                        break;
                }
            }
        }
    }
}
