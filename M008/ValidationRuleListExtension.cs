using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace M008;

public class ValidationRuleListExtension : MarkupExtension
{
	//Aufbau:
	//Binding auf den Backend Wert
	//Die Rules

	//Hier muss das Binding abgelegt werden, um es danach in ProvideValue zu benutzen
	private Binding b;

	public ValidationRuleListExtension(Binding b, ValidationRuleCollection collection)
	{
		foreach (ValidationRule rule in collection)
		{
			b.ValidationRules.Add(rule);
		}
		this.b = b;
	}

	//Hier wird festgelegt, was passiert, wenn das Binding ausgeführt wird (wenn der Wert von GUI <-> Model geschoben wird)
	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return b.ProvideValue(serviceProvider);
	}
}

public class ValidationRuleCollection : Collection<ValidationRule> { }