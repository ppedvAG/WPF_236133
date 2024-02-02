using System.Windows;
using System.Windows.Controls;

namespace M012;

public partial class MainWindow : Window
{
	public ExitCommand exit { get; set; } = new();

	public CustomCommand newWindow { get; set; }

	public CustomCommand ConfirmCommand { get; set; }

	public BindableProperty<string> OutputText { get; set; } = new();

	public MainWindow()
	{
		newWindow = new CustomCommand((o) => new MainWindow((string) o).Show());
		ConfirmCommand = new CustomCommand((o) => OutputText.Value = (o as TextBox).Text);
		InitializeComponent();
	}

	public MainWindow(string title) : this() => this.Title = title;
}