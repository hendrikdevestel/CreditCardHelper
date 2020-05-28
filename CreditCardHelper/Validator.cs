using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreditCardHelper
{
    public static class Validator
    {
        /// <summary>
        /// Valid lengths of credit card numbers according to: https://en.wikipedia.org/wiki/Payment_card_number
        /// </summary>
        private static int[] _cardLengths = new int[] { 12, 14, 15, 16, 18, 19 };

        /// <summary>
        /// Find all hidden creditcard numbers in a text.
        /// </summary>
        /// <param name="input">Text where a potentional creditcard number could be in</param>
        /// <returns>Whether the text contains a (hidden) credit card number.</returns>
        public static bool TextContainsCreditCard(string input)
        {
            input = input.GetOnlyNumericValues();
            if (input.Length < _cardLengths.Min())
            {
                return false;
            }

            foreach (var validLength in _cardLengths.Where(m => m <= input.Length))
            {
                var extraNumbers = input.Length - validLength;
                for(var i = 0; i <= extraNumbers; i++)
                {
                    var textToTest = input.Substring(i, validLength);
                    if (LuhnValidator.Validate(textToTest))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
