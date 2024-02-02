using System.Windows.Input;

namespace M012;

public class ExitCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	public bool CanExecute(object? parameter)
	{
		return false;
	}

	//Hier wird der Parameter aus der GUI empfangen
	public void Execute(object? parameter)
	{
		int x = parameter != null ? (int) parameter : 0;
		Environment.Exit(x);
	}
}
