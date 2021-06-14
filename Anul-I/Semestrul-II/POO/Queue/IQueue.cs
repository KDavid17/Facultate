namespace Queue
{
    public interface IQueue<T>
    {
        void Dequeue();
        void Enqueue(T item);
        void ShowQueue();
    }
}