using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreLib
{
    public static class StringExtensions
    {
        /// <summary>ip
        public static string ToTitleCase(this string str)
        {
            var cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            return cultureInfo.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
