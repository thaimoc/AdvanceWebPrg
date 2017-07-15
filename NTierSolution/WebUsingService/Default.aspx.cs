using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUsingService.MyService;

namespace WebUsingService
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Fraction a = new Fraction() { Numerator = Convert.ToInt32(txtAx.Text), Denominator = Convert.ToInt32(txtAy.Text)};
            Fraction b = new Fraction() { Numerator = Convert.ToInt32(txtBx.Text), Denominator = Convert.ToInt32(txtBy.Text) };
            using (MyService.Lab04SoapClient sv = new MyService.Lab04SoapClient())
            {
                switch (ddlOperator.SelectedValue)
                {
                    case "0":
                        a = sv.Add(a, b);
                        break;
                    case "1":
                        a = sv.Subtraction(a, b);
                        break;
                    case "2":
                        a = sv.Multiplication(a, b);
                        break;
                    case "3":
                        a = sv.Division(a, b);
                        break;
                }                
                txtAddResult.Text = String.Format("{0}/{1}", a.Numerator, a.Denominator);
            }
        }

        
    }
}
