using System.ComponentModel;

namespace M008;

public class Person : INotifyPropertyChanged, IDataErrorInfo
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
			if (value < 0 || value > 100)
				throw new ArgumentException("Das Alter muss zwischen 0 und 100 liegen!");

			alter = value;
			Notify(nameof(Alter));
		}
	}

	private string adresse;

	public string Adresse
	{
		get => adresse;
		set
		{
			adresse = value;
			Notify(nameof(adresse));
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




	/// <summary>
	/// Der Indexer definiert, das ein Objekt mit [] angesprochen werden kann
	/// Unumgänglich für Listentypen (List, Array, Dictionary, ...)
	/// Ist ein Property mit Get/Set und dabei wird ein Wert über die eckigen Klammern übergeben
	/// </summary>
	public string this[string propertyName] //columnName ist der Name des zu validierenden Properties
	{
		get
		{
			if (propertyName == nameof(Adresse))
			{
				if (!Adresse.All(char.IsLetter))
					return "Der Name darf nur aus Buchstaben bestehen!"; //Durch return werden die Fehlermeldungen zurückgegeben

				if (Adresse.Length < 3 || Adresse.Length > 15)
					return "Der Name muss zwischen 3 und 15 Zeichen haben!";
			}

			return null; //Return null bedeutet keine Fehler (Validierung erfolgreich)
		}
	}

	//Wird nicht benötigt
	public string Error => throw new NotImplementedException();
}
