using System.Collections.ObjectModel;
using System.Windows;

namespace M005;

public partial class MainWindow : Window
{
	public Person p { get; set; } //Hier muss auch INotifyPropertyChanged implementiert werden

	public BindableProperty<Person> p2 { get; set; } = new();

	public ObservableCollection<Person> people { get; set; } = new();

	public MainWindow()
	{
		p = new Person() { Name = "Max", Alter = 33 };
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		p.Alter++;
		p2.Value = new Person() { Name = "Max2", Alter = Random.Shared.Next() };
		people.Add(new Person() { Name = new string(Random.Shared.Next().ToString().Select(e => (char) (e + 49)).ToArray()), Alter = Random.Shared.Next() });
	}
}