using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenricsAndCollections
{
    internal class QueueExample
    {
        ///FIFO
        ///
        /*
         ✔ Works like a queue in a ticket counter (First item added is the first to be removed).
         ✔ Used in task scheduling, processing requests.
        */

        public QueueExample()
        {
            Queue<string> queues = new Queue<string>();

            queues.Enqueue("Task 1");
            queues.Enqueue("Task 2");
            queues.Enqueue("Task 3");
            queues.Enqueue("Task 4");

            queues.Reverse();
            Console.WriteLine("Dequeue " + queues.Dequeue());
            Console.WriteLine("Peek " + queues.Peek());//

        }


    }
}
