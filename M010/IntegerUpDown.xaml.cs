using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace M010;

[ContentProperty("Counter")] //Hier kann festgelegt werden, wo ein Wert zwischen den XML Tags <>...</> abgelegt wird
public partial class IntegerUpDown : UserControl
{
	public IntegerUpDown() => InitializeComponent();

	//propdp + Tab + Tab
	//Normales .NET Property mit GetValue und SetValue um das DP anzusprechen
	//Dazu wird ein DependencyProperty generiert, welches für die Bindung an die UI verantwortlich ist

	public int Counter
	{
		get => (int) GetValue(IntegerUpDown.CounterProperty);
		set => SetValue(IntegerUpDown.CounterProperty, value);
	}

	public static readonly DependencyProperty CounterProperty =
		DependencyProperty.Register
		(
			"Counter", //Name des DP
			typeof(int), //Typ
			typeof(IntegerUpDown), //Typ des Besitzers
			new PropertyMetadata(0) //Standardwert
		);

	public int TextFontSize
	{
		get { return (int) GetValue(TextFontSizeProperty); }
		set { SetValue(TextFontSizeProperty, value); }
	}

	public static readonly DependencyProperty TextFontSizeProperty =
		DependencyProperty.Register("TextFontSize", typeof(int), typeof(IntegerUpDown), new PropertyMetadata(20));

	//Events weitergeben (DP für Events)
	//Hier muss das Event als die Hintergrundvariable definiert werden mit add und remove
	//add und remove = get und set
	//Statt Get-/SetValue wird hier Add-/RemoveHandler verwendet
	public event RoutedEventHandler ButtonUpClicked
	{
		add => AddHandler(ButtonUpClickedProperty, value);
		remove => RemoveHandler(ButtonUpClickedProperty, value);
	}

	/// <summary>
	/// RoutingStrategy
	/// Tunneling: Event geht von oben nach unten (KeyDown)
	/// Bubbling: Event geht von unten nach oben (Button Click)
	/// Direct: Event umgeht den Baum komplett
	/// </summary>
	public static readonly RoutedEvent ButtonUpClickedProperty =
		EventManager.RegisterRoutedEvent
		(
			"ButtonUpClicked",
			RoutingStrategy.Direct,
			typeof(RoutedEventHandler),
			typeof(IntegerUpDown)
		);

	public event RoutedEventHandler ButtonDownClicked
	{
		add => AddHandler(ButtonDownClickedProperty, value);
		remove => RemoveHandler(ButtonDownClickedProperty, value);
	}

	public static readonly RoutedEvent ButtonDownClickedProperty =
		EventManager.RegisterRoutedEvent
		(
			"ButtonDownClicked",
			RoutingStrategy.Direct,
			typeof(RoutedEventHandler),
			typeof(IntegerUpDown)
		);


	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Counter++;
	}

	private void Button_Click_1(object sender, RoutedEventArgs e)
	{
		Counter--;
	}
}
