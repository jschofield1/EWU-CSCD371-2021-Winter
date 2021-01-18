using System;

namespace Classroom
{
    public static class StringExtension
    {
        public static string TitleCase(this string value, int maxLength = 0)
        {
            return $"{char.ToUpper(value[0])}{value.Substring(1)}";


        }
    }
}