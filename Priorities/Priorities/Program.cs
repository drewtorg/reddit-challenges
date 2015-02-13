using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priorities
{
    class Program
    {
        static void Main(string[] args)
        {
            DualPriorityQueue<double, int> queue = new DualPriorityQueue<double, int>();
            queue.Enqueue("Hyperion Hypodermic Needle", 1.99, 3);
            queue.Enqueue("SuperSaver Syringe", .89, 7);
            queue.Enqueue("InjectXpress Platinum Plated Needle", 2.49, 2);

            //test that the Enqueues
            Console.WriteLine(queue.ToString());

            //test the Dequeues
            Console.WriteLine(queue.DequeueA());
            Console.WriteLine(queue.DequeueB());

            //test the final result
            Console.WriteLine(queue.ToString());
        }
    }
}
