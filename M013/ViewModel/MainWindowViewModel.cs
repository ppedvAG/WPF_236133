using M013.Model;

namespace M013.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	public BindableProperty<Person> P { get; set; } = new();

	public CustomCommand NeuePersonCommand { get; set; }

	/// <summary>
	/// Wenn der DataContext gesetzt wird, wird er mittels new Instanziert
	/// </summary>
	public MainWindowViewModel()
	{
		NeuePersonCommand = new CustomCommand((o) => P.Value = new Person() { Name = "Max", Alter = Random.Shared.Next() % 100 });
	}
}
