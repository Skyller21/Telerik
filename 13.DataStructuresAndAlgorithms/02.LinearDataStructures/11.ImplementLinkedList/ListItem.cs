namespace _11.ImplementLinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
        }
        public T Value { get; private set; }

        public ListItem<T> NextItem { get; set; }
    }
}
