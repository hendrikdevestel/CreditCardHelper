using NUnit.Framework;

namespace CreditCardHelper.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        /// <summary>
        /// Check whether the input contains a credit card. It could be modified with texts between.
        /// </summary>
        [Test]
        [TestCase("3782-822-463-100-05", true)] //Valid card number is 378282246310005
        [TestCase("371 4 49test63 test 5398431", true)] //Valid card number is 371449635398431
        [TestCase("371 4 49test63 test 5398431", false, 2)] //Valid card number is 371449635398431 but test is longer than 2 characters between numbers.
        [TestCase("371 4 49test63 test 5398431", false, 3)] //Valid card number is 371449635398431 but test is longer than 3 characters between numbers.
        [TestCase("0000006011111111111117", true)] //Valid card number is 6011111111111117
        [TestCase("00test006011111test111111117", true)] //Valid card number is
        [TestCase("5610test5910", false)]
        [TestCase("325th Street number 130 box 9000", false)]
        [TestCase("00test006011111test11111111", false)]
        [TestCase(" = 65.00 , 11, : 2076832300", false)]
        [TestCase(" : . ?-> ; / 5-4 ? (5, 6 7 ) , . -> ; / 30 / / -19 . . . : :// . . / 3 . . . . , ó . 13.00 . € 20,00 ( ) . . 02-06 . ", false)]
        public void GetCardTypeByNumber_ReturnsValue(string input, bool expectedValue, int maxCharactersBetweenNumbers = int.MaxValue)
        {
            //Act
            var result = Validator.TextContainsCreditCard(input, maxCharactersBetweenNumbers);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}