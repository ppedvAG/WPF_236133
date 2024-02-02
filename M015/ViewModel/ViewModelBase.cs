using System.ComponentModel;

namespace M015.ViewModel;

/// <summary>
/// Diese Klasse stellt die Implementation von INotifyPropertyChanged für alle ViewModels bereit
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify(string propertyName) =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
