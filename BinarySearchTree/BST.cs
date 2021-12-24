using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    internal class BST<T> where T : IComparable
    {
        BSTNode<T> rootNode;

        public void Insert(T value)
        {
            if(rootNode == null)
            {
                rootNode = new BSTNode<T>(value);
                return;
            }

            BSTNode<T> node = new BSTNode<T>(value);
            Insert(rootNode, node);
        }

        public BSTNode<T> RootNode { get { return rootNode; } }

        private void Insert(BSTNode<T> currentNode, BSTNode<T> node)
        {
            if(node.Value.CompareTo(currentNode.Value) < 0)
            {
                if(currentNode.LeftNode == null)
                {
                    currentNode.LeftNode = node;
                    return;
                }
                Insert(currentNode.LeftNode, node);
            }
            else
            {
                if (currentNode.RightNode == null)
                {
                    currentNode.RightNode = node;
                    return;
                }
                Insert(currentNode.RightNode, node);
            }
        }

        public void PreOrderTraversal(Action<T> action)
        {
            PreOrderTraversal(action, rootNode);
        }

        private void PreOrderTraversal(Action<T> action, BSTNode<T> node)
        {
            if(node != null)
            {
                action(node.Value);
                PreOrderTraversal(action, node.LeftNode);
                PreOrderTraversal(action, node.RightNode);
            }
        }

        public void InOrderTraversal(Action<T> action)
        {
            InOrderTraversal(action, rootNode);
        }

        private void InOrderTraversal(Action<T> action, BSTNode<T> node)
        {
            if(node != null)
            {
                InOrderTraversal(action, node.LeftNode);
                action(node.Value);
                InOrderTraversal(action, node.RightNode);
            }
        }

        public void PostOrderTraversal(Action<T> action)
        {
            PostOrderTraversal(action, rootNode);
        }

        private void PostOrderTraversal(Action<T> action, BSTNode<T> node)
        {
            if(node != null)
            {
                PostOrderTraversal(action, node.LeftNode);
                PostOrderTraversal(action, node.RightNode);
                action(node.Value);
            }
        }

        public bool Contains(T item)
        {
            return Contains(item, rootNode);
        }

        private bool Contains(T item, BSTNode<T> node)
        {
            if(node != null)
            {
                if(item.CompareTo(node.Value) < 0)
                {
                    return Contains(item, node.LeftNode);
                }
                else if(item.CompareTo(node.Value) == 0)
                {
                    return true;
                }
                else
                {
                    return Contains(item, node.RightNode);
                }
            }
            else
            {
                return false;
            }
        }

        public bool Remove(T item)
        {
            return Remove(item, rootNode, null);
        }

        private bool Remove(T item, BSTNode<T> node, BSTNode<T> parentNode)
        {
            if(node != null)
            {
                if (item.CompareTo(node.Value) < 0)
                {
                    return Remove(item, node.LeftNode, node);
                }
                else if (item.CompareTo(node.Value) == 0)
                {
                    //If this is a leaf node
                    if(node.LeftNode == null && node.RightNode == null)
                    {
                        if (parentNode.LeftNode.Value.Equals(node.Value))
                        {
                            parentNode.LeftNode = null;
                        }
                        else
                        {
                            parentNode.RightNode = null;
                        }
                        
                    }
                    //If this node is having two child nodes
                    else if(node.LeftNode != null && node.RightNode != null)
                    {
                        BSTNode<T> minInRightNode = FindMinOfRightChild(node.RightNode, node);
                        minInRightNode.LeftNode = node.LeftNode;
                        minInRightNode.RightNode = node.RightNode;

                        if (parentNode.LeftNode.Value.Equals(node.Value))
                        {
                            parentNode.LeftNode = minInRightNode;
                        }
                        else
                        {
                            parentNode.RightNode = minInRightNode;
                        }
                    }
                    //If this node is having one child
                    else
                    {
                        BSTNode<T> childNode;
                        if(node.LeftNode != null)
                        {
                            childNode = node.LeftNode;
                            node.LeftNode = null;
                        }
                        else
                        {
                            childNode = node.RightNode;
                            node.RightNode = null;
                        }

                        if (parentNode.LeftNode.Value.Equals(node.Value))
                        {
                            parentNode.LeftNode = childNode;
                        }
                        else
                        {
                            parentNode.RightNode = childNode;
                        }
                    }

                    return true;
                }
                else
                {
                    return Remove(item, node.RightNode, node);
                }
            }
            else
            {
                return false;
            }
        }

        private BSTNode<T> FindMinOfRightChild(BSTNode<T> node, BSTNode<T> parentNode)
        {
            if(node.LeftNode != null)
            {
                return FindMinOfRightChild(node.LeftNode, node);
            }
            else
            {
                parentNode.LeftNode = null;
                return node;
            }
        }
    }
}
