using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueCircular<T> : IQueue<T>
    {
        private static int limit = 5;
        private int lastIndex = 0;
        private readonly List<T> listQueue = new List<T>();

        public QueueCircular()
        {

        }

        public void Dequeue()
        {
            if (lastIndex > 0)
            {
                listQueue.RemoveAt(0);

                lastIndex--;
            }
            else
            {
                Console.WriteLine("The queue is empty!");
            }
        }

        public void Enqueue(T item)
        {
            if (lastIndex < limit)
            {
                listQueue.Add(item);

                lastIndex++;
            }
            else
            {
                Console.WriteLine("The queue is full!");
            }
        }

        public void ShowQueue()
        {
            if (lastIndex > 0)
            {
                foreach (T item in listQueue)
                {
                    Console.Write(item + " ");
                }
                
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The queue is empty!");
            }
        }

        public List<T> GetQueue()
        {
            return listQueue;
        }
    }
}
