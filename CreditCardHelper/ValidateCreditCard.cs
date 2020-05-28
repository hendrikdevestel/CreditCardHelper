using CreditCardHelper.Enums;
using System;

namespace CreditCardHelper
{
    public static class ValidateCreditCard
    {
        /// <summary>
        /// Gets the type of a creditcard by its number
        /// </summary>
        /// <param name="cardNumber">Creditcard number</param>
        /// <returns>Member of the enum CardType</returns>
        public static CreditCardType GetCardTypeByNumber(string cardNumber)
        {
            cardNumber = cardNumber.GetOnlyNumericValues();
            var cardType = CreditCardType.Unknown;
            if (cardNumber.Length >= 12 && cardNumber.Length <= 19)
            {
                for(var i = 7; i > 0; i--)
                {
                    cardType = GetByIINRange(cardNumber, i);
                    if(cardType != CreditCardType.Unknown)
                    {
                        return cardType;
                    }
                }
            }

            return cardType;
        }

        private static CreditCardType GetByIINRange(string input, int rangeLength)
        {
            var iin = int.Parse(input.Substring(0, rangeLength));
            switch (iin)
            {
                case 1:
                    return CreditCardType.UATP;
                case 4:
                    return CreditCardType.Visa;
                case 34:
                case 37:
                    return CreditCardType.AmericanExpress;
                case 31:
                    return CreditCardType.ChinaTUnion;
                case 62:
                case 81:
                    return CreditCardType.ChinaUnionPay;
                case 36:
                case 38:
                case 39:
                    return CreditCardType.DinersClub; // or Carte Blanche (38)
                case 51:
                case 52:
                case 53:
                case 54:
                case 55:
                    return CreditCardType.MasterCard;
                case 64:
                case 65:
                    return CreditCardType.DiscoverCard;
                case 50:
                case 56:
                case 57:
                case 58:
                case 59:
                case 60:
                case 61:
                case 63:
                case 66:
                case 67:
                case 68:
                case 69:
                    return CreditCardType.Maestro;
                case 300:
                case 301:
                case 302:
                case 303:
                case 304:
                case 305:
                    return CreditCardType.DinersClub;
                case 636:
                    return CreditCardType.InterPayment;
                case 637:
                case 638:
                case 639:
                    return CreditCardType.InstaPayment;
                case 3095:
                    return CreditCardType.DinersClub;
                case 6011:
                    return CreditCardType.DiscoverCard;
                case 6040:
                case 6041:
                    return CreditCardType.UkrCard;
                case 6521:
                case 6522:
                    return CreditCardType.RuPay;
                case 6759:
                    return CreditCardType.Maestro;
                case 5019:
                    return CreditCardType.Dankort;
                case 2200:
                case 2201:
                case 2202:
                case 2203:
                case 2204:
                    return CreditCardType.MIR;
                case 357111:
                    return CreditCardType.LankaPay;
                case 676770:
                case 676774:
                    return CreditCardType.Maestro;
                case 6054740:
                case 6054741:
                case 6054742:
                case 6054743:
                case 6054744:
                    return CreditCardType.NPSPridnestrovie;
            }
            if (iin >= 3528 && iin <= 3589)
            {
                return CreditCardType.JCB;
            }
            if (iin >= 2221 && iin <= 2720)
            {
                return CreditCardType.MasterCard;
            }
            if ((iin >= 622126 && iin <= 622925) ||
                (iin >= 624000 && iin <= 626999) ||
                (iin >= 628200 && iin <= 628899))
            {
                return CreditCardType.DiscoverCard;
            }

            if (iin >= 979200 && iin <= 979289)
            {
                return CreditCardType.Troy;
            }
            if ((iin >= 506099 && iin <= 506198) ||
                (iin >= 650002 && iin <= 650027))
            {
                return CreditCardType.Verve;
            }

            return CreditCardType.Unknown;
        }
    }
}
