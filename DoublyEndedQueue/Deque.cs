using System;
using System.Collections.Generic;
using System.Text;
using DoublyLinkList;

namespace DoublyEndedQueue
{
    internal class Deque<T>
    {
        readonly DoublyLinkList<T> store = new DoublyLinkList<T>();

        public void EnqueueHead(T item)
        {
            store.AddHead(item);
        }

        public void EnqueueTail(T item)
        {
            store.AddTail(item);
        }

        public T DequeueHead()
        {
            T item = PeekHead();
            store.RemoveHead();

            return item;
        }

        public T DequeueTail()
        {
            T item = PeekTail();
            store.RemoveTail();

            return item;
        }

        public T PeekHead()
        {
            if (store.Head == null)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T item = store.Head.NodeValue;

            return item;
        }

        public T PeekTail()
        {
            if (store.Tail == null)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            T item = store.Tail.NodeValue;

            return item;
        }

        public int Count => store.Count;
    }
}
