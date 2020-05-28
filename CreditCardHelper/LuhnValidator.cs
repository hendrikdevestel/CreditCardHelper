using System;
using System.Linq;

namespace CreditCardHelper
{
    public static class LuhnValidator
    {
        /// <summary>
        /// Validate an input to the Luhn Algorithm.
        /// </summary>
        /// <param name="input">Potentional creditcard number</param>
        /// <returns>Whether the input is a valid creditcard number or not</returns>
        public static bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            long sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var digit = input[input.Length - 1 - i] - '0';
                sum += (i % 2 != 0) ? GetDouble(digit) : digit;
            }

            return sum % 10 == 0;

            int GetDouble(long i)
            {
                switch (i)
                {
                    case 0: return 0;
                    case 1: return 2;
                    case 2: return 4;
                    case 3: return 6;
                    case 4: return 8;
                    case 5: return 1;
                    case 6: return 3;
                    case 7: return 5;
                    case 8: return 7;
                    case 9: return 9;
                    default: return 0;
                }
            }
        }

        
    }
}
