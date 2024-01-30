using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace M004;

public class DoubleToThicknessConverter : IValueConverter
{
	//Quelle -> Ziel
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		double d = (double) value;
		return new Thickness(d, 0, d, 0);
	}

	//Ziel -> Quelle
	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
}
