using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkList
{
    internal class DoublyLinkList<T> :ICollection<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public bool IsReadOnly { get { return false; } }

        public void Add(T item)
        {
            AddTail(item);
        }

        public Node<T> Find(T item)
        {
            Node<T> node = Head;
            while(node != null)
            {
                if(node.NodeValue.Equals(item))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }

        public void AddHead(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Count == 0)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                Head.Prevoius = node;
                node.Next = Head;
                Head = node;
            }
            Count++;
        }

        public void AddTail(T value)
        {
            if(Count == 0)
            {
                AddHead(value);
            }
            else
            {
                Node<T> node = new Node<T>(value);
                Tail.Next = node;
                node.Prevoius = Tail;
                Tail = node;
                Count++;
            }
            
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            return (Find(item) == null) ? false : true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = Head;
            while (node != null)
            {
                yield return node.NodeValue;
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumeratorReverse()
        {
            Node<T> node = Tail;
            while(node != null)
            {
                yield return node.NodeValue;
                node = node.Prevoius;
            }
        }

        public bool Remove(T item)
        {
            Node<T> node = Find(item);
            if(node == null)
            {
                return false;
            }

            Node<T> previous = node.Prevoius;
            Node<T> next = node.Next;

            if(previous == null)
            {
                Head = next;
                Head.Prevoius = null;
            }
            else
            {
                previous.Next = next;
            }

            if(next == null)
            {
                Tail = previous;
                Tail.Next = null;
            }
            else
            {
                next.Prevoius = previous;
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
