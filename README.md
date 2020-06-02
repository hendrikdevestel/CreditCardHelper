# CreditCardHelper ![.NET Core](https://github.com/hendrikdevestel/CreditCardHelper/workflows/.NET%20Core/badge.svg)

CreditCardHelper helps you working with credit cards. Validating the numbers and find the type of card. Verifying card numbers through the Luhn algorithm. It even can check whether there is a number hidden in text.

Nuget Package: https://www.nuget.org/packages/CreditCardHelper

## Usage

#### LuhnValidator


#### ValidateCreditCard
```csharp
var cardType = CreditCardHelper.CardType.GetCardTypeByNumber("5105105105105100");
// = CreditCardType.MasterCard
var cardType2 = CreditCardHelper.CardType.GetCardTypeByNumber("123");
// = CreditCardType.Unknown
```

#### Validator

```csharp
var cardIsValid = CreditCardHelper.Validator.ValidateLuhn("5105105105105100");
// = true
var cardIsValid2 = CreditCardHelper.Validator.ValidateLuhn("123");
// = false
```

```csharp
var textContainsCC = CreditCardHelper.Validator.TextContainsCreditCard("This is a text with 5105-1051-0510-5100 in it");
// = true
var textContainsCC2 = CreditCardHelper.Validator.TextContainsCreditCard("51st Street number 05 box 1051");
// = false
var textContainsCC3 = CreditCardHelper.Validator.TextContainsCreditCard("Thi5105s is 1051 a te0510xt with5100 in it");
// = true
```

