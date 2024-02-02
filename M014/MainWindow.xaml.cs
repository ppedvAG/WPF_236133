using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace M014;

public partial class MainWindow : Window
{
	public BindableProperty<ObservableCollection<Person>> personen { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();

		string readJson = File.ReadAllText(@"Personen.json");
		personen.Value = JsonSerializer.Deserialize<ObservableCollection<Person>>(readJson)!;
	}
}