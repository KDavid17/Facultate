using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueChained<T> : IQueue<T>
    {
        private static int limit = 5;
        private int leftIndex = 0, rightIndex = 0;
        private readonly T[] listQueue = new T[limit];

        public QueueChained()
        {

        }

        public void Dequeue()
        {
            if (!listQueue[leftIndex].Equals(default(T)))
            {
                listQueue[leftIndex] = default(T);

                leftIndex++;

                if (leftIndex == limit)
                {
                    leftIndex = 0;
                }

                if (leftIndex == rightIndex)
                {
                    leftIndex = 0;
                    rightIndex = 0;
                }
            }
            else
            {
                Console.WriteLine("The queue is empty!");
            }
        }

        public void Enqueue(T item)
        {
            if ((rightIndex == leftIndex && listQueue[leftIndex].Equals(default(T))) || (rightIndex != leftIndex && rightIndex < limit))
            {
                listQueue[rightIndex] = item;

                rightIndex++;

                if (rightIndex == limit)
                {
                    rightIndex = 0;
                }
            }
            else
            {
                Console.WriteLine("The queue is full!");
            }
        }

        public void ShowQueue()
        {
            if (leftIndex == rightIndex && listQueue[leftIndex].Equals(default(T)))
            {
                Console.Write("The queue is empty!");
            }
            else if (leftIndex >= rightIndex)
            {
                for (int i = leftIndex; i < limit; i++)
                {
                    if (!listQueue[i].Equals(default(T)))
                    {
                         Console.Write(listQueue[i] + " ");
                    }
                }
                
                for (int i = 0; i < rightIndex; i++)
                {
                    if (!listQueue[i].Equals(default(T)))
                    {
                        Console.Write(listQueue[i] + " ");
                    }
                }
            }
            else
            {
                for (int i = leftIndex; i < rightIndex; i++)
                {
                    if (!listQueue[i].Equals(default(T)))
                    {
                        Console.Write(listQueue[i] + " ");
                    }
                }
            }

            Console.WriteLine();
        }

        public T[] GetQueue()
        {
            return listQueue;
        }
    }
}
