using System.Windows.Markup;
using System.Windows.Media;

namespace M007;

/// <summary>
/// Markup Extension: Eigene Logik schreiben die in { } im XAML eingesetzt werden kann
/// Binding, TemplateBinding, StaticResource, x:Static sind alles MarkupExtensions
/// </summary>
public class ColorsExtension : MarkupExtension
{
	public override object ProvideValue(IServiceProvider serviceProvider) =>
		typeof(Colors).GetProperties().Select(e => (Color) e.GetValue(null)).ToArray();
}
