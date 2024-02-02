using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace M010.Converter;

public class ColorToSliderValueConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		Color theColor = (Color) value;
		SliderColor theSliderColor = (SliderColor) parameter;
		return theSliderColor switch
		{
			SliderColor.Red => theColor.R,
			SliderColor.Green => theColor.G,
			SliderColor.Blue => theColor.B,
			SliderColor.Alpha => theColor.A,
			_ => throw new NotImplementedException()
		};
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
}
