using System;
using System.Collections.Generic;
using System.Text;

namespace PrintingApp.Helper
{
    public static class StringHelper
    {
        public static readonly Func<string, bool> IsEmpty = str =>
        {
            return (string.IsNullOrWhiteSpace(str)) ? true : false;
        };
        public static readonly Func<int, float> ToFloat = (number) =>
        {
            return (float.Parse(number.ToString(), System.Globalization.NumberStyles.Number));
        };
    }
}
