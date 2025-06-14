using System.Text.RegularExpressions;
using Vektorel.Muzayede.Common.Enums;

namespace Vektorel.Muzayede.Common.Helpers;

public class PhoneNumberValidator
{
    static PhoneNumberValidator()
    {
        Expressions = new Dictionary<PhoneCountry, string>
        {
            { PhoneCountry.Turkiye, @"^(?:\+90|0)?5(0[0-9]|3[0-9]|4[0-9]|5[0-9]|6[0-1])\d{7}$" },
            { PhoneCountry.Sweden, @"^(?:\+46|0)(7[02369])\d{7}$" }
        };
    }
    public bool ValidateNumber(string number)
    {
        if (!number.StartsWith('+'))
        {
            return false;
        }
        var countries = Enum.GetValues<PhoneCountry>();

        var rawNumbers = number.Substring(1);
        if (!countries.Any(f => rawNumbers.StartsWith(f.GetHashCode().ToString())))
        {
            return false;
        }

        var country = countries.First(f => rawNumbers.StartsWith(f.GetHashCode().ToString()));

        if (Regex.IsMatch(number, Expressions[country]))
        {
            return true;
        }
        return false;
    }

    private static Dictionary<PhoneCountry, string> Expressions;
}



