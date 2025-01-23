using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MessageSender.Library
{
    public static class Validate
    {
        public static bool IsValidatePhoneNumber(string phoneNumber)
        {
            //return Regex.IsMatch(phoneNumber, @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./,0-9]*$");
            return Regex.IsMatch(phoneNumber, @"^\+(\d{1,4})\d{4,14}(,\+\d{1,4}\d{4,14})*$");
        }
    }
}
