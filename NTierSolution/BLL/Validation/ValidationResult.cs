using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Validation
{
    public class ValidationResult
    {
        public List<string> Messages { get; set; }

        public bool Valid
        {
            get { return !Messages.Any(); }
        }

        public ValidationResult()
        {
            Messages = new List<string>();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Messages.ForEach(m => sb.AppendLine(m));
            return sb.ToString();
        }
    }
}
