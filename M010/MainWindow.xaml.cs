using System.Windows;
using System.Windows.Media;

namespace M010;

public partial class MainWindow : Window
{
	public BindableProperty<int> CounterBindable { get; set; } = new();

	public BindableProperty<Color> TheColor { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
		TheColor.Value = Color.FromArgb(255, 123, 234, 213);
	}

	private void IntegerUpDown_ButtonUpClicked(object sender, RoutedEventArgs e)
	{
		CounterBindable.Value++;
	}

	private void IntegerUpDown_ButtonDownClicked(object sender, RoutedEventArgs e)
	{
		CounterBindable.Value--;
	}
}