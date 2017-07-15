using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Validation
{
    public interface IValidator<in T> where T : class, new()
    {
        ValidationResult Validate(T obj);
    }
}
