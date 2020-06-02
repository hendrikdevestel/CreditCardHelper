using NUnit.Framework;

namespace CreditCardHelper.Tests
{
    [TestFixture]
    public class ValidateCreditCardTests
    {
        /// <summary>
        /// Get the credit card type by its input
        /// </summary>
        [Test]
        [TestCase("378282246310005", CreditCardType.AmericanExpress)] //American Express
        [TestCase("371449635398431", CreditCardType.AmericanExpress)] //American Express
        [TestCase("378734493671000", CreditCardType.AmericanExpress)] //American Express
        [TestCase("5610591081018250", CreditCardType.Maestro)] //Australian BankCard
        [TestCase("30569309025904", CreditCardType.DinersClub)] //Diners Club
        [TestCase("38520000023237", CreditCardType.DinersClub)] //Diners Club
        [TestCase("6011111111111117", CreditCardType.DiscoverCard)] //Discover
        [TestCase("6011000990139424", CreditCardType.DiscoverCard)] //Discover
        [TestCase("3530111333300000", CreditCardType.JCB)] //JCB
        [TestCase("3566002020360505", CreditCardType.JCB)] //JCB
        [TestCase("5555555555554444", CreditCardType.MasterCard)] //MasterCard
        [TestCase("5105105105105100", CreditCardType.MasterCard)] //MasterCard
        [TestCase("4111111111111111", CreditCardType.Visa)] //Visa
        [TestCase("4012888888881881", CreditCardType.Visa)] //Visa
        [TestCase("4222222222222", CreditCardType.Visa)] //Visa
        [TestCase("5019717010103742", CreditCardType.Dankort)] //Dankort (PBS)
        [TestCase("", CreditCardType.Unknown)]
        [TestCase("123", CreditCardType.Unknown)]
        [TestCase("й\")аз!)", CreditCardType.Unknown)]
        public void GetCardTypeByNumber_ReturnsValue(string input, CreditCardType expectedValue)
        {
            //Act
            var result = CardType.GetCardTypeByNumber(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}