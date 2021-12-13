using DoublyLinkList;
using System;
using System.Collections.Generic;
using System.Text;

namespace Queue
{
    internal class Queue<T>
    {
        readonly DoublyLinkList<T> store = new DoublyLinkList<T>();

        public void Enqueue(T item)
        {
            store.AddTail(item);
        }

        public T Dequeue()
        {
            T item = PeekHead();
            store.RemoveHead();
            return item;
        }

        public T PeekTail()
        {
            T item = store.Tail.NodeValue;
            return item;
        }

        public T PeekHead()
        {
            T item = store.Head.NodeValue;
            return item;
        }

        public int Count => store.Count;
    }
}
