using System;

namespace DoublyEndedQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>();

            for(int i=0; i< 10; i++)
            {
                if(i%2 > 0)
                {
                    deque.EnqueueHead(i);
                }
                else
                {
                    deque.EnqueueTail(i);
                }
            }

            Console.WriteLine("--------- Print Deque -------------");

            bool flip = true;            
            while(deque.Count > 0)
            {
                if (flip)
                {
                    Console.Write($"{deque.DequeueHead()} ");
                }
                else
                {
                    Console.Write($"{deque.DequeueTail()} ");
                }
            }


            Console.ReadLine();
        }
    }
}
