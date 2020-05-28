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
        [TestCase("0000006011111111111117", true)] //Valid card number is 6011111111111117
        [TestCase("00test006011111test111111117", true)] //Valid card number is
        [TestCase("5610test5910", false)]
        [TestCase("325th Street number 130 box 9000", false)]
        [TestCase("00test006011111test11111111", false)]
        public void GetCardTypeByNumber_ReturnsValue(string input, bool expectedValue)
        {
            //Act
            var result = Validator.TextContainsCreditCard(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}