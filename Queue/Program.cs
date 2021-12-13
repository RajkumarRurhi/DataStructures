using System;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            for(int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine("------------ Print Queue -----------");
            while(queue.Count > 0)
            {
                Console.Write($"{queue.Dequeue()} ");
            }
            Console.WriteLine($"\n Queue Length : {queue.Count}");

            Console.ReadLine();
        }
    }
}
