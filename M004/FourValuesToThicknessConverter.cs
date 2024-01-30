using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class FourValuesToThicknessConverter : IMultiValueConverter
{
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		//List<double> d = [];
		//foreach (object o in values)
		//	d.Add((double) o);

		List<double> doubles = values.Select(e => (double) e).ToList(); //Select: Transformiert eine Liste in eine neue Form
		return new Thickness(doubles[0], doubles[1], doubles[2], doubles[3]);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
}
