using System.Windows.Markup;

namespace M001;

/// <summary>
/// Extension, um einen Enum an eine ItemsSource zu binden
/// </summary>
public class EnumerationTestExtension : MarkupExtension
{
	public IEnumerable<object> Values { get; set; }

	public EnumerationTestExtension(Type enumType)
	{
		if (enumType == null || !enumType.IsEnum)
		{
			throw new ArgumentException("Der gegebene Typ ist kein Enum Typ");
		}

		Values = Enum.GetValues(enumType).Cast<object>();
	}

	public override object ProvideValue(IServiceProvider serviceProvider) => Values;
}