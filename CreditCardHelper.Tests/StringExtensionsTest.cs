using NUnit.Framework;
using CreditCardHelper.Extensions;
using System.Linq;

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

        /// <summary>
        /// Get multiple numeric values from a given string
        /// </summary>
        [TestCase("test123", new string[] { "123" })]
        [TestCase("1t2e3s4t5", new string[] { "12345" })]
        [TestCase("1t2e3s4tt5", new string[] { "1234", "5" })]
        [TestCase("", new string[] {})]
        [TestCase("12", new string[] { "12" })]
        [TestCase("<t3est>4", new string[] { "3", "4" })]
        [TestCase("\"'§^5[2]\\3>", new string[] { "52", "3" })]
        public void GetOnlyNumericValues_ReturnsArrayValue(string input, string[] expectedValue)
        {
            //Act
            var result = input.GetOnlyNumericValues(1);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue.ToArray()));
        }
    }
}