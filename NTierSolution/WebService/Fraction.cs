using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace WebService
{
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public class Fraction : SoapHeader
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        
        public Fraction()
        {
            Numerator = 1;
            Denominator = 1;
        }
        
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            if (denominator == 0)
            {
                throw new ArgumentException("denominator equal zezo!");
            }
            Denominator = denominator;
        }
       
        public Fraction(int x)
            : this(x, 1)
        { }        

        /// <summary>
        /// Greatest Common Divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        
        public int GtsComDivisor(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == 0 || b == 0)
            {
                return a + b;
            }
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }            
            return a;
        }

       
        public void Reduce()
        {
            int grt = GtsComDivisor(Numerator, Denominator);
            if (grt != 1)
            {
                Numerator = Numerator / grt;
                Denominator = Denominator / grt;
            }
        }

       
        public Fraction Add(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Denominator + y.Numerator * x.Denominator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }
        
        public Fraction Subtraction(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Denominator - y.Numerator * x.Denominator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }
        
        public Fraction Multiplication(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }

        public Fraction Division(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator / y.Denominator, x.Denominator / y.Denominator);
            rs.Reduce();
            return rs;
        }


        public static explicit operator int(Fraction f)
        {
            return Convert.ToInt32(f.Numerator / f.Denominator);
        }

        public static implicit operator Fraction(int interger)
        {
            return new Fraction(interger);
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Denominator + y.Numerator * x.Denominator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Denominator - y.Numerator * x.Denominator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator * y.Numerator, x.Denominator * y.Denominator);
            rs.Reduce();
            return rs;
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            Fraction rs = new Fraction(x.Numerator / y.Denominator, x.Denominator / y.Denominator);
            rs.Reduce();
            return rs;
        }

        public override string ToString()
        {
            return Denominator == 1 ? Numerator.ToString() : String.Format("{0}/{1}", Numerator, Denominator);
        }
    }
}