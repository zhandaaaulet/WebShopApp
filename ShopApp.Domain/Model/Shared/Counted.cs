namespace ShopApp.Domain.Model.Shared
{
    public class Counted<T>
    {
        public T Item { get; }
        public int Count { get; }

        public Counted(T item, int count)
        {
            Item = item;
            Count = count;
        }

        public static Counted<T> Of(T item, int count)
        {
            return new Counted<T>(item, count);
        }
    }
}
