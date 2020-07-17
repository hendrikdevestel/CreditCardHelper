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
        [TestCase("Daily Rate = 65.00EUR Thu, Jun 11, Rate Code: 2076832300", false)]
        [TestCase("Reservering: Nu is het niet mijn intentie om de hele trip te annuleren maar ik zou graag de trip opnieuw plannen nadat de maatregelen tegen het virus reeds zijn opgelost. Is het mogelijk om in overleg met u de reservering te verplaatsen naar Mei of Juni ?-> gast gemaild dat datum verzet mag worden; zie gewone mail/sb 5-4 mail Is het mogelijk dat wij de reservering verplaatsen naar de eerste week van Juni ? (5, 6 en 7 Juni) Indien het hotel dan nog een Superior kamer vrij heeft, zullen wij het eventuele verschil in kamerprijs natuurlijk bijbetalen. -> gast had al sup geboekt; heb de boekingsdatum aangepast in de bestaande boeking en gast op de hoogte gebracht van nieuwe reservering/sb 30 mei gast gemaild dat sup bij ons niet mogelijk is en overplaatsing naar the match aangeboden of datum verzetten/sb/ Vanwege de COVID-19 situatie is ons hotel helaas tijdelijk gesloten en hebben wij nu nog geen zicht op de datum waarop we weer open gaan. Het spijt ons u te moeten teleurstellen. Al onze gasten boeken wij kosteloos over naar ons nieuwe zusterhotel The Match. Kijkt u gerust eens op hun site: http://www.hotelthematch.com/ Dit hotel ligt slechts op 3 minuten loopafstand van ons hotel. Dit hotel beschikt over ruime kamers met regendouche. Helaas is een kamer met jacuzzi niet mogelijk daar zij die niet hebben. Sorry hiervoor. Wij bieden u de mogelijkheid om uw reservering bij ons te verzetten naar een andere aankomstdatum later dit jaar, óf u kunt gebruik maken van een kamer bij The Match. Als compensatie voor het ontbreken van de jacuzzi bieden wij u dan gratis een late check out tot 13.00 u aan. Tevens krijgt u een waarde cheque van € 20,00 om in het (boodschappen)winkeltje van The Match te besteden. Graag horen wij van u waar uw voorkeur naar uitgaat. 02-06 Gasten gaan aankomstdatum verzetten en zullen half juni even bellen hoe het ervoor staat. Willen niet naar the Match FH", false)]
        public void GetCardTypeByNumber_ReturnsValue(string input, bool expectedValue)
        {
            //Act
            var result = Validator.TextContainsCreditCard(input);

            //Assert
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}