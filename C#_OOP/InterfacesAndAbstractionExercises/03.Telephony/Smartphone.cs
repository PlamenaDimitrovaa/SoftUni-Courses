using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {

        public string Browsing(string url)
        {
            if (url.Any(Char.IsDigit))
            {
                return "Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Calling(string number)
        {
            if (!number.All(Char.IsDigit))
            {
                return "Invalid number!";
            }

            if (number.Length == 7)
            {
                return $"Dialing... {number}";
            }
            else
            {
                return $"Calling... {number}";
            }
        }
    }
}
