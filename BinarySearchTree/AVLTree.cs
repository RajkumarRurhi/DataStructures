using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    internal class AVLTree<T> where T : IComparable
    {
        BSTNode<T> rootNode;

        public void Insert(T value)
        {
            if (rootNode == null)
            {
                rootNode = new BSTNode<T>(value);
                return;
            }

            BSTNode<T> node = new BSTNode<T>(value);
            Insert(rootNode, node);

            BalanceTree2(rootNode);
        }

        public BSTNode<T> RootNode { get { return rootNode; } }

        private void Insert(BSTNode<T> currentNode, BSTNode<T> node)
        {
            if (node.Value.CompareTo(currentNode.Value) < 0)
            {
                if (currentNode.LeftNode == null)
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
            if (node != null)
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
            if (node != null)
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
            if (node != null)
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
            if (node != null)
            {
                if (item.CompareTo(node.Value) < 0)
                {
                    return Contains(item, node.LeftNode);
                }
                else if (item.CompareTo(node.Value) == 0)
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
            bool result = Remove(item, rootNode, null);
            BalanceTree(RootNode);
            return result;
        }

        private bool Remove(T item, BSTNode<T> node, BSTNode<T> parentNode)
        {
            if (node != null)
            {
                if (item.CompareTo(node.Value) < 0)
                {
                    return Remove(item, node.LeftNode, node);
                }
                else if (item.CompareTo(node.Value) == 0)
                {
                    //If this is a leaf node
                    if (node.LeftNode == null && node.RightNode == null)
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
                    else if (node.LeftNode != null && node.RightNode != null)
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
                        if (node.LeftNode != null)
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
            if (node.LeftNode != null)
            {
                return FindMinOfRightChild(node.LeftNode, node);
            }
            else
            {
                parentNode.LeftNode = null;
                return node;
            }
        }
        
        private void BalanceTree2(BSTNode<T> node, BSTNode<T> parentNode = null)
        {
            if(node.LeftNode != null)
            {
                int leftNodeBalanceFactor = BalanceFactor(node.LeftNode);
                if (leftNodeBalanceFactor < -1 || leftNodeBalanceFactor > 1)
                {
                    BalanceTree2(node.LeftNode, node);
                    //leftNodeBalanceFactor = BalanceFactor(node.LeftNode);
                }
            }

            if (node.RightNode != null)
            {
                int rightNodeBalanceFactor = BalanceFactor(node.RightNode);
                if (rightNodeBalanceFactor < -1 || rightNodeBalanceFactor > 1)
                {
                    BalanceTree2(node.RightNode, node);
                    //rightNodeBalanceFactor = BalanceFactor(node.RightNode);
                }
            }

            int balanceFactor = BalanceFactor(node);

            if (balanceFactor > 1)
            {
                int leftBalanceFactor = BalanceFactor(node.LeftNode);

                // if tree's left node is right heavy
                if (leftBalanceFactor <= -1)
                {
                    RightLeftRotate(node, parentNode);
                }
                else
                {
                    RightRotate(node, parentNode);
                }
            }
            // If tree is right heavy
            else if (balanceFactor < -1)
            {
                int rightBalanceFactor = BalanceFactor(node.RightNode);

                // if tree's right node is left heavy
                if (rightBalanceFactor >= 1)
                {
                    LeftRightRotate(node, parentNode);
                }
                else
                {
                    LeftRotate(node, parentNode);
                }
            }
        }
        private void BalanceTree(BSTNode<T> node, BSTNode<T> parentNode = null)
        {
            int balanceFactor = BalanceFactor(node);

            // If tree is left heavy            
            if (balanceFactor > 1)
            {
                int leftBalanceFactor = BalanceFactor(node.LeftNode);
                if (leftBalanceFactor < -1 || leftBalanceFactor > 1)
                {
                    BalanceTree(node.LeftNode, node);
                }

                // if tree's left node is right heavy
                if (leftBalanceFactor < -1)
                {
                    RightLeftRotate(node, parentNode);
                }
                else
                {
                    RightRotate(node, parentNode);
                }
            }
            // If tree is right heavy
            else if (balanceFactor < -1)
            {
                int rightBalanceFactor = BalanceFactor(node.RightNode);
                if(rightBalanceFactor < -1 || rightBalanceFactor > 1)
                {
                    BalanceTree(node.RightNode, node);
                }

                // if tree's right node is left heavy
                if (rightBalanceFactor > 1)
                {
                    LeftRightRotate(node, parentNode);
                }
                else
                {
                    LeftRotate(node, parentNode);
                }
            }
        }

        private int BalanceFactor(BSTNode<T> node)
        {
            int leftHeight = 0;
            if (node.LeftNode != null)
            {
                leftHeight = SubTreeHeight(node.LeftNode) + 1;
            }

            int rightHeight = 0;
            if (node.RightNode != null)
            {
                rightHeight = SubTreeHeight(node.RightNode) + 1;
            }

            return leftHeight - rightHeight;
        }

        private int SubTreeHeight(BSTNode<T> node)
        {
            if(node.LeftNode == null && node.RightNode == null)
            {
                return 0;
            }

            int leftHeight = node.LeftNode != null ? SubTreeHeight(node.LeftNode) + 1 : 0;
            int rightHeight = node.RightNode != null ? SubTreeHeight(node.RightNode) + 1 : 0;

            int height = (leftHeight > rightHeight) ? leftHeight : rightHeight;

            return height;
        }

        private void LeftRotate(BSTNode<T> oldRootNode, BSTNode<T> parentNode)
        {
            BSTNode<T> newRootNode = oldRootNode.RightNode;

            ReplaceRootNode(oldRootNode, parentNode, newRootNode);

            oldRootNode.RightNode = newRootNode.LeftNode;
            newRootNode.LeftNode = oldRootNode;
        }

        private void RightRotate(BSTNode<T> oldRootNode, BSTNode<T> parentNode)
        {
            BSTNode<T> newRootNode = oldRootNode.LeftNode;

            ReplaceRootNode(oldRootNode, parentNode, newRootNode);

            oldRootNode.LeftNode = newRootNode.RightNode;
            newRootNode.RightNode = oldRootNode;
        }

        private void LeftRightRotate(BSTNode<T> oldRootNode, BSTNode<T> parentNode)
        {
            if(oldRootNode.RightNode != null)
            {
                RightRotate(oldRootNode.RightNode, oldRootNode);
            }
            LeftRotate(oldRootNode, parentNode);
        }

        private void RightLeftRotate(BSTNode<T> oldRootNode, BSTNode<T> parentNode)
        {
            if(oldRootNode.LeftNode != null)
            {
                LeftRotate(oldRootNode.LeftNode, oldRootNode);
            }
            RightRotate(oldRootNode, parentNode);
        }

        private void ReplaceRootNode(BSTNode<T> oldRootNode, BSTNode<T> parentNode, BSTNode<T> newRootNode)
        {
            if(parentNode == null)
            {
                parentNode = newRootNode;
                rootNode = parentNode;
                return;
            }

            if (parentNode.Value.CompareTo(oldRootNode.Value) > 0)
            {
                parentNode.LeftNode = newRootNode;
            }
            else
            {
                parentNode.RightNode = newRootNode;
            }
        }
        
    }
}
