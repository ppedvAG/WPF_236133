using System.Windows.Input;

namespace M012;

public class CustomCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	//Action und Func: Typen die Methodenzeiger halten können

	private Action<object> execute;

	private Func<object, bool> canExecute = (o) => true; //Anonyme Methode, diese Methode ist eine Kurzform von unten

	//Optionaler Parameter: Wenn ein Parameter gegeben wird, wird dieser Parameter übernommen, sonst wird der Wert hinter = genommen
	public CustomCommand(Action<object> execute, Func<object, bool> canExecute = null)
	{
		if (canExecute != null)
			this.canExecute = canExecute;

		this.execute = execute;
	}

	public bool CanExecute(object? parameter) => canExecute(parameter);

	public void Execute(object? parameter) => execute(parameter);
}
