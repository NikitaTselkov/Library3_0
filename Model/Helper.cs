using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public static class Helper
    {
        public static string MyGetHashCode(this string value)
        {
            var result = value.Length.ToString();

            for (int i = 0; i < value.Length; i++)
            {
                result += char.ConvertToUtf32(value, i).ToString();
            }

            return result;
        }

    }
}
