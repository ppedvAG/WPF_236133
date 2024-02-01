using System.Windows;

namespace M009;

public partial class MainWindow : Window
{
	public BindableProperty<string> TextContainer { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		TV.ItemsSource = new string[] { "T1", "T2", "T3" };
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		TV.ItemsSource = null;
	}
}