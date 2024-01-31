using System.Collections.ObjectModel;
using System.Windows;

namespace M007;


public partial class MainWindow : Window
{
	public ObservableCollection<Person> personen { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		for (int i = 0; i < 100; i++)
			personen.Add(new Person() { Name = new string(Random.Shared.Next().ToString().Select(e => (char) (e + 49)).ToArray()), Alter = Random.Shared.Next() });
	}
}