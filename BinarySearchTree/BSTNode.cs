using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    internal class BSTNode<T>
    {
        private readonly T value;

        public BSTNode(T value)
        {
            this.value = value;
        }

        //public int BalanceFactor
        //{
        //    get
        //    {
        //        //if (LeftNode != null && RightNode != null)
        //        //{
        //        //    return LeftNode.BalanceFactor + RightNode.BalanceFactor;
        //        //}
        //        //else if (LeftNode != null && RightNode == null)
        //        //{
        //        //    return LeftNode.BalanceFactor + 1;
        //        //}
        //        //else if (LeftNode == null && RightNode != null)
        //        //{
        //        //    return (RightNode.BalanceFactor - 1);
        //        //}

        //        if(LeftNode != null)
        //        {

        //        }

        //        return 0;
        //    }
        //}


        public T Value { get { return value; } }

        public BSTNode<T> LeftNode { get; set; }
        public BSTNode<T> RightNode { get; set; }
    }
}
