using System;

namespace BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BST<int> bst = new BST<int>();
            //bst.Insert(20);
            //bst.Insert(10);
            //bst.Insert(40);
            //bst.Insert(5);
            //bst.Insert(15);
            //bst.Insert(30);
            //bst.Insert(50);
            //bst.Insert(2);
            //bst.Insert(8);
            //bst.Insert(11);
            //bst.Insert(18);
            //bst.Insert(25);
            //bst.Insert(35);
            //bst.Insert(45);
            //bst.Insert(55);

            ////PreOrderTraversal is used for copying the same tree.
            //BST<int> bst2 = new BST<int>();
            //bst.PreOrderTraversal((value) => bst2.Insert(value));

            ////InOrderTraversal is used to print node values in sorted order.
            //bst.InOrderTraversal((value) => Console.WriteLine(value));

            ////PostOrderTraversal is used to remove nodes from leaf.
            //bst.PostOrderTraversal((value) => Console.WriteLine(value));

            //Console.WriteLine($"Does tree contains 5 : {bst.Contains(5)}");
            //Console.WriteLine($"Does tree contains 85 : {bst.Contains(85)}");

            //Console.WriteLine($"Removed 5 : {bst.Remove(5)}");
            //Console.WriteLine($"Removed 10 : {bst.Remove(10)}");
            //Console.WriteLine($"Removed 12 : {bst.Remove(12)}");
            //Console.WriteLine($"Removed 12 : {bst.Remove(10)}");

            AVLTree<int> avlTree = new AVLTree<int>();
            for(int i = 0; i < 10; i++)
            {
                avlTree.Insert(i + 1);
            }
            avlTree.InOrderTraversal(value => Console.Write(value + " "));

            Console.WriteLine("\n--------------------------------------------");

            AVLTree<int> avlTree2 = new AVLTree<int>();
            for (int i = 9; i >= 0; i--)
            {
                avlTree2.Insert(i + 1);
            }
            avlTree2.InOrderTraversal(value => Console.Write(value + " "));

            Console.WriteLine("\n--------------------------------------------");

            AVLTree<int> avlTree3 = new AVLTree<int>();
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                int tmpRandom = r.Next(1, 1000);
                avlTree3.Insert(tmpRandom);
            }
            
            avlTree3.InOrderTraversal(value => Console.Write(value + " "));

            Console.ReadLine();
        }
    }
}
