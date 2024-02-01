using System.Globalization;
using System.Windows.Controls;

namespace M008;

public class LengthValidation : ValidationRule
{
	public override ValidationResult Validate(object value, CultureInfo cultureInfo)
	{
		string str = (string)value;
		if (str.Length >= 3 && str.Length <= 15)
			return ValidationResult.ValidResult;
		return new ValidationResult(false, "Der Name muss zwischen 3 und 15 Zeichen haben!");
	}
}
