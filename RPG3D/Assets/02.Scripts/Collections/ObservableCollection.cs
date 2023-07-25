using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace RPG.Collections
{
    public class ObservableCollection<T> : INotifyCollectionChanged<T>, IEnumerable<T>
    {
        public T this[int index]
        {
            get => _items[index];
            set => Change(index, value);
        }

        public int Count => _items.Count;

        public event Action<int, T> onItemChanged;
        public event Action<int, T> onItemAdded;
        public event Action<int, T> onItemRemoved;
        public event Action onCollectionChanged;

        private List<T> _items = new List<T>();

        public ObservableCollection() { }
        public ObservableCollection(IEnumerable<T> copy)
        {
            _items = new List<T>(copy);
        }

        public void Change(int index, T item)
        {
            _items[index] = item;
            onItemChanged?.Invoke(index, item);
            onCollectionChanged?.Invoke();
        }

        public void Swap(int index1, int index2)
        {
            if (index1 >= Count || index1 < 0 || index2 >= Count || index2 < 0)
                throw new IndexOutOfRangeException();

            T item2 = _items[index2];
            Change(index2, _items[index1]);
            Change(index1, item2);
        }

        public void Add(T item)
        {
            _items.Add(item);
            onItemAdded?.Invoke(_items.Count - 1, item);
            onCollectionChanged?.Invoke();
        }

        public bool Remove(T item)
        {
            int index = _items.IndexOf(item);
            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            T tmp = _items[index];
            _items.RemoveAt(index);
            onItemRemoved?.Invoke(index, tmp);
            onCollectionChanged?.Invoke();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
