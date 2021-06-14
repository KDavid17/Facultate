using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            // The limit for both queues is 5 (it can be changed to suit the task).

            QueueCircular<string> myQueue1 = new QueueCircular<string>();

            QueueChained<int> myQueue2 = new QueueChained<int>();
        }
    }
}
