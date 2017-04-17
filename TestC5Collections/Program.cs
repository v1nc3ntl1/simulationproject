using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestC5Collections
{
    using System.Threading;
    using C5;

    class Program
    {
        static void Main(string[] args)
        {
            TestCircularQueue();
        }

        private static void TestCircularQueue()
        {
            var publishQueue = new CircularQueue<PublishItem>();

            for (var i = 1; i <= 10; i++)
            {
                var item = new PublishItem()
                {
                    ItemId = i.ToString(),
                    ItemName = string.Format("Item{0}", i.ToString()),
                    PublishTime = TimeSpan.FromSeconds(new Random().Next(0, 10))
                };
                publishQueue.Enqueue(item);
                Console.WriteLine("Enqueuing item: {0}", item.ItemName);
            }

            Console.WriteLine("-----------------------------------------------------------------");

            var publishJob = new PublishJob();
            do
            {
                var item = publishQueue.Dequeue();
                Console.WriteLine("Dequeuing item: {0}", item.ItemName);
                publishJob.Publish(item);
            }
            while (!publishQueue.IsEmpty);

            Console.ReadLine();
        }
    }

    public class PublishJob
    {
        public void Publish(PublishItem item)
        {
            Console.WriteLine("Publishing item: {0}", item.ItemName);
            var timer = new Timer(delegate(object state)
            {
                var current = (state as PublishItem);
                if (current != null)
                {
                    Console.WriteLine("Published item: {0}", current.ItemName);
                }
            }, item, item.PublishTime, TimeSpan.FromMilliseconds(-1));
        }
    }

    public class PublishItem
    {
        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public TimeSpan PublishTime { get; set; }
    }
}
