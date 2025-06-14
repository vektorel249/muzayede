using Vektorel.Muzayede.Common.Helpers;

namespace Vektorel.Muzayede.Tests;

[TestFixture]
public class PhoneNumberValidatorTests
{
    public PhoneNumberValidatorTests()
    {
        Sut = new PhoneNumberValidator();
    }
    public PhoneNumberValidator Sut { get; set; }
    [Test]
    public void Can_Validate_TurkishNumber()
    {
        var result = Sut.ValidateNumber("+905079991905");
        Assert.That(result, Is.True);
    }

    [Test]
    public void Cannot_Validate_TurkishNumber()
    {
        var result = Sut.ValidateNumber("+904079991905");
        Assert.That(result, Is.False);
    }

    [TestCase("+905001234567")]
    [TestCase("+905321234567")]
    [TestCase("+905551234567")]
    [TestCase("+905551234567")]
    [TestCase("+905391234567")]
    [TestCase("+905391234567")]
    [TestCase("+905601234567")]
    [TestCase("+905601234567")]
    [TestCase("+905311234567")]
    [TestCase("+905311234567")]
    public void Can_Validate_TurkishNumber_With_Params(string number)
    {
        var result = Sut.ValidateNumber(number);
        Assert.That(result, Is.True);
    }

    [TestCase("+903121234567")]
    [TestCase("+902321234567")]
    [TestCase("+904051234567")]
    [TestCase("+906021234567")]
    [TestCase("+903434")]
    [TestCase("+9050623456780")]
    [TestCase("++90")]
    [TestCase("+90")]
    [TestCase("+900000000000")]
    [TestCase("1111111111111")]
    [TestCase("1111111111")]
    public void Cannot_Validate_TurkishNumber_With_Params(string number)
    {
        var result = Sut.ValidateNumber(number);
        Assert.That(result, Is.False);
    }

    [Test]
    public void Can_Validate_SwedishNumber()
    {
        var result = Sut.ValidateNumber("+46701234567");
        Assert.That(result, Is.True);
    }

    [Test]
    public void Cannot_Validate_SwedishNumber()
    {
        var result = Sut.ValidateNumber("+46901234567");
        Assert.That(result, Is.False);
    }
}