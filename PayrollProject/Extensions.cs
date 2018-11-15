using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollProject
{
    public static class Extensions
    {
        public static string NullIfWhiteSpace(this string value)
        {
            if (String.IsNullOrWhiteSpace(value)) { return null; }
            return value;
        }
    }
}
