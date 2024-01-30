using System.Windows;

namespace M003;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
		for (int i = 0; i < 1000; i++)
		{
			Scroll.Text += i.ToString() + "\n";
		}
	}
}