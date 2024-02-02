using M015.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace M015.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
	public NorthwindContext DB { get; set; } = new(); //Ermöglicht DB Zugriff

	public ObservableCollection<Customer> customers { get; set; }

	public ObservableCollection<KundenUmsatz> ku { get; set; }

	public CustomCommand LoadCustomersCommand { get; set; }

	public CustomCommand LoadKundenUmsatzCommand { get; set; }

	public CustomCommand ScrollCommand { get; set; }

	public BindableProperty<int> ProgressValue { get; set; } = new();

	public BindableProperty<int> ProgressMaximum { get; set; } = new();

	public MainWindowViewModel()
	{
		//NuGet:
		//- EFCore
		//- DB Treiber
		//- EFCore.Design
		//- EFCore.Tools

		//Extension: EF Core Power Tools

		//efcore(nuget) und ef core power tools(vs extension) installieren
		//rechtsklick aufs projekt -> reverse engineer
		//db verbindung auswählen / hinzufügen
		//tabellen / views auswählen
		//dbcontext und model klassen erzeugen lassen
		//objekt von der context klasse erstellen und die dbsets per linq ansprechen

		customers = new ObservableCollection<Customer>();
		ku = new();

		LoadCustomersCommand = new(LoadCustomers);
		LoadKundenUmsatzCommand = new(LoadKundenUmsatz);

		//IQueryable<Customer> customers = db.Customers.Where(e => e.Country == "UK"); //Hier wird nur das SQL-Statement vorbereitet
		//var customers = db.Customers.Where(e => e.Country == "UK").ToListAsync(); //Hier werden tatsächlich die Daten geholt

		//Enumerable.Range(0, 1_000_000_000); //1ms
		//Enumerable.Range(0, 1_000_000_000).ToList(); //1.5s, hier werden alle Daten erzeugt

		//DG.ItemsSource = await customers; //Hier muss die Liste enumeriert werden um die Rows zu zeichnen
	}

	private void LoadCustomers(object o)
	{
		foreach (Customer c in DB.Customers)
			customers.Add(c);
	}

	private async void LoadKundenUmsatz(object o)
	{
		//foreach (KundenUmsatz k in DB.KundenUmsatzs) //Dauert -> UI Freeze
		//	ku.Add(k);

		//Async und Await
		//Aufgabe starten -> Zwischenschritte (UI Updates) -> Auf Aufgabe warten
		//Daten laden -> User mitteilen -> Auf Daten warten

		//Einen Datensatz laden -> User mitteilen -> Auf einen Datensatz warten

		//Wenn eine Async Methode gestartet wird, läuft diese im Hintergrund

		//Task<List<KundenUmsatz>> dbTask = DB.KundenUmsatzs.ToListAsync(); //Diese Aufgabe läuft parallel
		////Zwischenschritte
		//List<KundenUmsatz> kunden = await dbTask; //Hier auf Ergebnis warten

		//foreach (KundenUmsatz k in kunden) //Dauert -> UI Freeze
		//	ku.Add(k);

		//Datensatz für Datensatz laden
		//1. Count für das Maximum der ProgressBar
		ProgressValue.Value = 0;
		ProgressMaximum.Value = await DB.KundenUmsatzs.CountAsync();

		IAsyncEnumerable<KundenUmsatz> kundenAsync = DB.KundenUmsatzs.Take(50000).AsAsyncEnumerable(); //Asynchrone Anleitung
		await foreach (KundenUmsatz k in kundenAsync) //await foreach
		{
			ku.Add(k);
			ProgressValue.Value++;
		}
	}
}
