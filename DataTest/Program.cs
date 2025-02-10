using System;
using DataStructers.Tree.BinarySearchTree;
using DataStructers.Tree.BinaryTree;

namespace DataTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

            var bt = new BinaryTree<int>();
            //Buranın dönüşü List<Node<T>> olarak gelecek.Bunu istersek ForEach ile donenbiliriz.

            //bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
            bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));
           

            Console.WriteLine();

            bt.LevelOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));

            //bt.PostOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));
            //bt.PreOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));


            //bt.ClearList();


            //Console.WriteLine();
            //bt.PreOrder(BST.Root).ForEach(node => Console.Write(node + " "));
            //bt.ClearList();
            //bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.ReadKey();
        }
    }
}
