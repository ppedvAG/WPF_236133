using System.Collections.ObjectModel;

namespace M001;

internal class SortWrapper<T>
{
	public ObservableCollection<T> Sort { get; set; } = new();

	public void Order<TDataType>(Func<T, TDataType> d)
	{
		Sort = new ObservableCollection<T>(Sort.OrderBy(d));
	}
}
