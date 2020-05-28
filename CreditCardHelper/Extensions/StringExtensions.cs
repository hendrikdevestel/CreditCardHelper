using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove all non-numeric values from a string
        /// </summary>
        /// <param name="input">The string to update.</param>
        /// <returns>The updated string.</returns>
        public static string GetOnlyNumericValues(this string input)
        {
            var ret = new System.Text.StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input, i))
                {
                    ret.Append(input.Substring(i, 1));
                }
            }
            return ret.ToString();
        }
    }
}
