using System.Collections.ObjectModel;

namespace M015;

public class SortWrapper<T>
{
	public BindableProperty<ObservableCollection<T>> CollectionToSort { get; set; } = new();

	public SortWrapper() => CollectionToSort.Value = new ObservableCollection<T>();

	public void Order<TDataType>(params Func<T, TDataType>[] d)
	{
		if (d.Length == 1)
			CollectionToSort.Value = new ObservableCollection<T>(CollectionToSort.Value.OrderBy(d[0]));
		else
		{
			IOrderedEnumerable<T> firstSort = CollectionToSort.Value.OrderBy(d[0]);
			foreach (Func<T, TDataType> item in d.Skip(1))
				firstSort = firstSort.OrderBy(item);
			CollectionToSort.Value = new ObservableCollection<T>(firstSort);
		}
	}

	public void OrderDescending<TDataType>(params Func<T, TDataType>[] d)
	{
		if (d.Length == 1)
			CollectionToSort.Value = new ObservableCollection<T>(CollectionToSort.Value.OrderByDescending(d[0]));
		else
		{
			IOrderedEnumerable<T> firstSort = CollectionToSort.Value.OrderByDescending(d[0]);
			foreach (Func<T, TDataType> item in d.Skip(1))
				firstSort = firstSort.OrderByDescending(item);
			CollectionToSort.Value = new ObservableCollection<T>(firstSort);
		}
	}

	public void Where(Func<T, bool> predicate)
	{
		CollectionToSort.Value = new ObservableCollection<T>(CollectionToSort.Value.Where(predicate));
	}
}
