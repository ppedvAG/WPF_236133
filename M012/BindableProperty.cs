using System.ComponentModel;

namespace M012;

public class BindableProperty<T> : INotifyPropertyChanged
{
	private T _value;

	public T Value
	{
		get => _value;
		set
		{
			_value = value;
			Notify(nameof(Value));
		}
	}

    public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string propertyName) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
