using NUnit.Framework;

namespace CreditCardHelper.Tests
{
    [TestFixture]
    public class LuhnValidatorTests
    {
        /// <summary>
        /// Test Creditcard numbers from https://www.paypalobjects.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm
        /// </summary>
        [TestCase("378282246310005", true)] //American Express
        [TestCase("371449635398431", true)] //American Express
        [TestCase("378734493671000", true)] //American Express
        [TestCase("5610591081018250", true)] //Australian BankCard
        [TestCase("30569309025904", true)] //Diners Club
        [TestCase("38520000023237", true)] //Diners Club
        [TestCase("6011111111111117", true)] //Discover
        [TestCase("6011000990139424", true)] //Discover
        [TestCase("3530111333300000", true)] //JCB
        [TestCase("3566002020360505", true)] //JCB
        [TestCase("5555555555554444", true)] //MasterCard
        [TestCase("5105105105105100", true)] //MasterCard
        [TestCase("4111111111111111", true)] //Visa
        [TestCase("4012888888881881", true)] //Visa
        [TestCase("4222222222222", true)] //Visa
        [TestCase("5019717010103742", true)] //Dankort (PBS)
        [TestCase("6331101999990016", true)] //Switch/Solo (Paymentech)

        [TestCase("378282246310004", false)] //American Express modified
        [TestCase("371449635398430", false)] //American Express modified
        [TestCase("378734493671001", false)] //American Express modified
        [TestCase("5610591081018251", false)] //Australian BankCard modified
        [TestCase("30569309025905", false)] //Diners Club modified
        [TestCase("38520000023238", false)] //Diners Club modified
        [TestCase("6011111111111118", false)] //Discover modified
        [TestCase("6011000990139425", false)] //Discover modified
        [TestCase("3530111333300001", false)] //JCB modified
        [TestCase("3566002020360506", false)] //JCB modified
        [TestCase("5555555555554445", false)] //MasterCard modified
        [TestCase("5105105105105101", false)] //MasterCard modified
        [TestCase("4111111111111112", false)] //Visa modified
        [TestCase("4012888888881880", false)] //Visa modified
        [TestCase("42222222222", false)] //Visa modified
        [TestCase("5019717010103733", false)] //Dankort (PBS) modified
        [TestCase("633110199999001", false)] //Switch/Solo (Paymentech) modified
        [TestCase("", false)]
        [TestCase("342<^$", false)]
        public void Validate_ReturnsValue(string input, bool expectedValue)
        {
            //Act
            var result = LuhnValidator.Validate(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}