using System;
using System.Collections.Generic;
using System.Text;
using DoublyLinkList;

namespace Stack
{
    internal class Stack<T>
    {
        readonly DoublyLinkList<T> store = new DoublyLinkList<T>();

        public void Push(T item)
        {
            store.AddHead(item);
        }

        public T Pop()
        {
            T item = Peek();
            store.RemoveHead();
            return item;
        }

        public T Peek()
        {
            return store.Head.NodeValue;
        }

        public int Count => store.Count;
    }
}
