using System.Collections.ObjectModel;

namespace WpfGame
{
    class ObservableQueue<T> : ObservableCollection<T>
    {
        public void Enqueue(T item)
        {
            Add(item);
        }

        public T Dequeue()
        {
            var item = this[0];
            RemoveItem(0);
            return item;
        }
    }
}
