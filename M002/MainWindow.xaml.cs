using System.Windows;

namespace M002;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		if (IsInitialized)
		{
			TB.Text = "Checked";
		}
	}

	//private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	//{
	//	TB.FontSize = e.NewValue;
	//}
}