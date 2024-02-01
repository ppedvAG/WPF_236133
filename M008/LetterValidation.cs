using System.Globalization;
using System.Windows.Controls;

namespace M008;

public class LetterValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = (string) value;
		if (str.All(char.IsLetter))
			return ValidationResult.ValidResult;
		return new ValidationResult(false, "Der Name darf nur aus Buchstaben bestehen!");
	}
}
