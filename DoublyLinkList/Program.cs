using System;

namespace DoublyLinkList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkList<int> dllInt = new DoublyLinkList<int>();
            for (int i = 0; i < 10; i++)
            {
                dllInt.AddTail(i);
            }
            
            Console.WriteLine("------------ Printing values from doubly link list ----------------------");
            foreach (int i in dllInt)
            {
                Console.Write($"{i} ");
            }

            //Console.WriteLine("\n--------- Print values from doubly link list and remove from head ---------------");
            //while(dllInt.Count > 0)
            //{
            //    Console.Write($"{dllInt.Head.NodeValue} ");
            //    dllInt.RemoveHead();
            //}
            
            Console.WriteLine("\n--------- Print values from doubly link list and remove from tail ---------------");
            while (dllInt.Count > 0)
            {
                Console.Write($"{dllInt.Tail.NodeValue} ");
                dllInt.RemoveTail();
            }

            Console.WriteLine($"\n Item Count in doubly link list : {dllInt.Count}");

            Console.WriteLine("\n------------ Printing values in reverse order from link list ----------------------");
            var itr = dllInt.GetEnumeratorReverse();
            while (itr.MoveNext())
            {
                Console.WriteLine(itr.Current);
            }

            //Console.WriteLine("------------ Check if link list contains items ----------------------");
            //Console.WriteLine($"Does Linklist contains 7? {dllInt.Contains(7)}");
            //Console.WriteLine($"Does Linklist contains 12? {dllInt.Contains(12)}");

            //Console.WriteLine("------- Remove a node from center and print ----------------");
            //dllInt.Remove(5);
            //foreach (int i in dllInt)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("------- Remove a node from starting and print ----------------");
            //dllInt.Remove(0);
            //foreach (int i in dllInt)
            //{
            //    Console.WriteLine(i);
            //}

            //Console.WriteLine("------- Remove a node from end and print ----------------");
            //dllInt.Remove(9);
            //foreach (int i in dllInt)
            //{
            //    Console.WriteLine(i);
            //}

            Console.ReadLine();
        }
    }
}
