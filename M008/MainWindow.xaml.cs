using System.Windows;

namespace M008;

public partial class MainWindow : Window
{
	public Person p { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}
}