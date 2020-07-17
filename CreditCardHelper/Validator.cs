using System;
using System.Linq;

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
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            input = input.GetOnlyNumericValues();
            if (input.Length < _cardLengths.Min())
            {
                return false;
            }

            foreach (var validLength in _cardLengths.Where(m => m <= input.Length))
            {
                var extraNumbers = input.Length - validLength;
                for (var i = 0; i <= extraNumbers; i++)
                {
                    var textToTest = input.Substring(i, validLength);
                    if (!ValidateLuhn(textToTest))
                    {
                        continue;
                    }
                    var cardType = CardType.GetCardTypeByNumber(textToTest);
                    if(LengthIsValidateWithType(validLength, cardType))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Validate an input to the Luhn Algorithm.
        /// </summary>
        /// <param name="input">Potentional creditcard number</param>
        /// <returns>Whether the input is a valid creditcard number or not</returns>
        public static bool ValidateLuhn(string input)
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

        private static bool LengthIsValidateWithType(int length, CreditCardType cardType)
        {
            switch (length)
            {
                case 12:
                    return cardType == CreditCardType.Maestro;
                case 13:
                    return cardType == CreditCardType.Maestro;
                case 14:
                    return cardType == CreditCardType.DinersClub
                        || cardType == CreditCardType.Maestro;
                case 15:
                    return cardType == CreditCardType.AmericanExpress
                        //|| cardType == CreditCardType.Maestro
                        || cardType == CreditCardType.DinersClub;
                case 16:
                    return cardType == CreditCardType.ChinaUnionPay
                        || cardType == CreditCardType.DinersClub
                        || cardType == CreditCardType.DiscoverCard
                        || cardType == CreditCardType.UkrCard
                        || cardType == CreditCardType.RuPay
                        || cardType == CreditCardType.InterPayment
                        || cardType == CreditCardType.InstaPayment
                        || cardType == CreditCardType.JCB
                        || cardType == CreditCardType.Maestro
                        || cardType == CreditCardType.Dankort
                        || cardType == CreditCardType.MIR
                        || cardType == CreditCardType.NPSPridnestrovie
                        || cardType == CreditCardType.MasterCard
                        || cardType == CreditCardType.Troy
                        || cardType == CreditCardType.Visa
                        || cardType == CreditCardType.Verve
                        || cardType == CreditCardType.LankaPay;
                case 17:
                case 18:
                    return cardType == CreditCardType.ChinaUnionPay
                        || cardType == CreditCardType.DinersClub
                        || cardType == CreditCardType.DiscoverCard
                        || cardType == CreditCardType.InterPayment
                        || cardType == CreditCardType.JCB
                        || cardType == CreditCardType.Maestro;
                case 19:
                    return cardType == CreditCardType.ChinaTUnion
                        || cardType == CreditCardType.ChinaUnionPay
                        || cardType == CreditCardType.DinersClub
                        || cardType == CreditCardType.DiscoverCard
                        || cardType == CreditCardType.InterPayment
                        || cardType == CreditCardType.JCB
                        || cardType == CreditCardType.Maestro
                        || cardType == CreditCardType.Verve;
            }
            return false;
        }
    }

}
