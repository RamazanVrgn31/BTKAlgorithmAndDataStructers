using System;
using DataStructers.Tree.BinarySearchTree;
using DataStructers.Tree.BinaryTree;

namespace DataTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            var BST = new BST<int>(new int[] { 60,40,70,20,45,65,85,3 });

            var bt = new BinaryTree<int>();

            Console.WriteLine($"Maximum Derinlik= {BinaryTree<int>.MaxDepth(BST.Root)}");
            

            //bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));

            //Console.WriteLine();
            //BST.Remove(BST.Root,40);
            //bt.ClearList();

            //bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));


            //var findKey = BST.Find(BST.Root, 45);
            //if (findKey!=null)  
            //    Console.WriteLine($"Sayı= {findKey} Soldaki Değer= {findKey.Left} Sağdaki Değer= {findKey.Right} "  );


            //Console.WriteLine($"Ağaçataki Minimum Değer= {BST.FindMin(BST.Root)}" );
            //Console.WriteLine($"Ağaçataki Maximum Değer= {BST.FindMax(BST.Root)}" );


            //Buranın dönüşü List<Node<T>> olarak gelecek.Bunu istersek ForEach ile donenbiliriz.

            //bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
            //bt.PostOrder(BST.Root).ForEach(node => Console.Write(node + " "));


            //Console.WriteLine();

            //bt.LevelOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));

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
