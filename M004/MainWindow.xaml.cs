using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace M004;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		BindingExpression ex = TB.GetBindingExpression(TextBlock.TextProperty);
		ex.UpdateSource();
	}
}