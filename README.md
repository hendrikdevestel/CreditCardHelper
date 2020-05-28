# CreditCardHelper

CreditCardHelper helps you working with creditcards. Validating the numbers and find the type of card. Verifying card numbers through the Luhn algorithm. It even can check whether there is a number hidden in text.

Nuget Package: https://www.nuget.org/packages/CreditCardHelper

## Usage

#### LuhnValidator

```csharp
var cardIsValid = CreditCardHelper.LuhnValidator.Validate("5105105105105100");
// = true
var cardIsValid2 = CreditCardHelper.LuhnValidator.Validate("123");
// = false
```

#### ValidateCreditCard
```csharp
var cardType = CreditCardHelper.ValidateCreditCard.GetCardTypeByNumber("5105105105105100");
// = CreditCardType.MasterCard
var cardType2 = CreditCardHelper.ValidateCreditCard.GetCardTypeByNumber("123");
// = CreditCardType.Unknown
```

#### Validator
```csharp
var textContainsCC = CreditCardHelper.Validator.TextContainsCreditCard("This is a text with 5105-1051-0510-5100 in it");
// = true
var textContainsCC2 = CreditCardHelper.Validator.TextContainsCreditCard("51st Street number 05 box 1051");
// = false
var textContainsCC3 = CreditCardHelper.Validator.TextContainsCreditCard("Thi5105s is 1051 a te0510xt with5100 in it");
// = true
```
