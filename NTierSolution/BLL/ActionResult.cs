using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ActionResult
    {
        public List<Exception> Exceptions { get; set; }

        public bool Success
        {
            get { return !Exceptions.Any(); }
        }

        public ActionResult()
        {
            Exceptions = new List<Exception>();
        }

        public string GetErrorMessages()
        {
            var sb = new StringBuilder();
            Exceptions.ForEach(e => sb.AppendLine(e.Message));
            return sb.ToString();
        }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Result { get; set; }
    }

    public class ActionResultAsList<T> : ActionResult
    {
        public List<T> Result { get; set; }
    }
}
