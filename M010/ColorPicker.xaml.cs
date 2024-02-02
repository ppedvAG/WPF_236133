using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M010;

public partial class ColorPicker : UserControl
{
	public Color SelectedColor
	{
		get => (Color) GetValue(SelectedColorProperty);
		set => SetValue(SelectedColorProperty, value);
	}

	public static readonly DependencyProperty SelectedColorProperty =
		DependencyProperty.Register
		(
			"SelectedColor",
			typeof(Color),
			typeof(ColorPicker)
		);



	public ColorPicker()
	{
		InitializeComponent();
	}

	/// <summary>
	/// propa -> Tab, Tab
	/// Ermöglicht, ein "vererbbares" Property anzulegen
	/// Wird an unterliegende Komponente mittels <Name>.<Property> weitergegeben
	/// Beispiel: Grid.Row, Grid.Column
	/// Im Unterelement kann auf dieses Property zugegriffen werden
	/// </summary>
	public static int GetMax(DependencyObject obj) => (int) obj.GetValue(MaxProperty);

	public static void SetMax(DependencyObject obj, int value) => obj.SetValue(MaxProperty, value);

	public static readonly DependencyProperty MaxProperty =
		DependencyProperty.RegisterAttached("Max", typeof(int), typeof(ColorPicker));

	private void RSlider_SliderValueChanged_1(object sender, RoutedPropertyChangedEventArgs<byte> e)
	{

    }
}
