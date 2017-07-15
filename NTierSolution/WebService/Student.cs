using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService
{
    public class Student
    {
        public string Code { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public Student()
        {

        }

        public Student(string _mssv, string _ho, string _ten)
        {
            Code = _mssv;
            LastName = _ho;
            FirstName = _ten;
        }
    }
}