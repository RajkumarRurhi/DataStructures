using System;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine("--------- Peek and print stack items ----------");
            Console.WriteLine(stack.Peek());

            Console.WriteLine("--------- Pop and print stack items ----------");
            while(stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }

            Console.WriteLine($"\n Stack Length : {stack.Count}");

            Console.ReadLine();
        }
    }
}
