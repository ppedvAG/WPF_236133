using System.Windows;

namespace M010;

public partial class MainWindow : Window
{
	public BindableProperty<int> CounterBindable { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
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