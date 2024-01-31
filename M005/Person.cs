using System.ComponentModel;

namespace M005;

public class Person : INotifyPropertyChanged
{
	private string name;

	public string Name
	{
		get => name;
		set
		{
			name = value;
			Notify(nameof(Name));
		}
	}

	private int alter;

	public int Alter
	{
		get => alter;
		set
		{
			alter = value;
			Notify(nameof(Alter));
		}
	}

	//Benachrichtigungsmechanismus von INotifyPropertyChanged
	//Das PropertyChanged Event wird von der GUI automatisch angebunden

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string propertyName) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

	public override string ToString()
	{
		return $"{Name} {Alter}";
	}
}
