using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridView2.Model
{
    public class Group<TKey, TItem> : IComparable<Group<TKey, TItem>>
        where TKey : IComparable
    {
        public TKey Key { get; set; }
        public ObservableCollection<TItem> Items { get; set; }
        public int CompareTo(Group<TKey, TItem> other)
        {
            return this.Key.CompareTo(other.Key);
        }
    }

    // http://codereview.stackexchange.com/questions/37208/sort-observablecollection-after-added-new-item
    public static class IListExtension
    {
        public static void AddSorted<T>(this IList<T> list, T item, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;

            int i = 0;
            while (i < list.Count && comparer.Compare(list[i], item) < 0)
                i++;

            list.Insert(i, item);
        }
    }

    public static class ObservableCollectionExtension
    {
        public static void AddSorted<T>(this ObservableCollection<T> list, T item, IComparer<T> comparer = null)
        {
            if (comparer == null)
                comparer = Comparer<T>.Default;

            int i = 0;
            while (i < list.Count && comparer.Compare(list[i], item) < 0)
                i++;

            list.Insert(i, item);
        }
    }
}
