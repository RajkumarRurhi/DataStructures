using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkList
{
    internal class Node<T>
    {
        public Node(T value)
        {
            NodeValue = value;
        }

        public Node<T> Prevoius { get; set; }
        public Node<T> Next { get; set; }

        public T NodeValue;
    }
}
