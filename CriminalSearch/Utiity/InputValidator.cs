using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CriminalSearch.Utility
{
    public class InputValidator
    {
        public bool IsAlphaNumeric(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9\s,]*$");
        }

        public bool IsEmail(string input)
        {
            return Regex.IsMatch(input, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public bool IsValidRange(double from, double to)
        {
            bool result = true;
            
            if (from <= 0 || to >= 100)
                result = false;
            else if (from == double.MaxValue || from == double.MinValue)
                result = false;
            else if (to == double.MaxValue || to == double.MinValue)
                result = false;
            else if (from > to)
                result = false;

            return result;
        }
    }
}
