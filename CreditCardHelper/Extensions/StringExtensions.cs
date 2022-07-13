using System.Collections.Generic;

namespace CreditCardHelper.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Remove all non-numeric values from a string
        /// </summary>
        /// <param name="input">The string to update.</param>
        /// <returns>The updated string.</returns>
        public static IEnumerable<string> GetOnlyNumericValues(this string input, int maxCharactersBetweenNumbers = int.MaxValue)
        {
            var outputList = new List<string>();
            var sBuilder = new System.Text.StringBuilder();
            var charactersBetweenNumbers = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input, i))
                {
                    if (charactersBetweenNumbers <= maxCharactersBetweenNumbers)
                    {
                        sBuilder.Append(input.Substring(i, 1));
                    }
                    else
                    {
                        var number = sBuilder.ToString();
                        if (!string.IsNullOrWhiteSpace(number))
                            outputList.Add(number);
                        sBuilder = new System.Text.StringBuilder();
                        charactersBetweenNumbers = 0;
                    }
                }
                else
                {
                    charactersBetweenNumbers++;
                }
            }
            var foundNumber = sBuilder.ToString();
            if (!string.IsNullOrWhiteSpace(foundNumber) && !outputList.Contains(foundNumber))
                outputList.Add(foundNumber);
            return outputList;
        }
    }
}
