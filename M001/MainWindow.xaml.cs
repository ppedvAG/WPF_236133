using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace M001;

public partial class MainWindow : Window
{
	public BindableProperty<DayOfWeek> wochentag { get; set; } = new();

	public MainWindow()
	{
		InitializeComponent();
	}

	//ColorPicker als UserControl
	//ColorPicker in das MainWindow einbinden
	//Per Button anzeigen (vorher Collapsed)
	//Color binden an die Person
	//Farbe wieder laden, wenn der ColorPicker nochmal geöffnet wird
	//ComboBox Auswahl zu ColorPicker Color

}