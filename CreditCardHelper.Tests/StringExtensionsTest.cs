using NUnit.Framework;
using CreditCardHelper.Extensions;

namespace CreditCardHelper.Tests
{
    [TestFixture]
    public class StringExtensionsTest
    {
        /// <summary>
        /// Get only numeric values from a given string
        /// </summary>
        [TestCase("test123", "123")]
        [TestCase("1t2e3s4t5", "12345")]
        [TestCase("1t2e3s4t5", "12345")]
        [TestCase("", "")]
        [TestCase("12", "12")]
        [TestCase("<t3est>", "3")]
        [TestCase("\"'§^5[2]\\3>", "523")]
        public void GetOnlyNumericValues_ReturnsValue(string input, string expectedValue)
        {
            //Act
            var result = input.GetOnlyNumericValues();

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}