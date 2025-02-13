using System;
using DataStructers.Tree.BinarySearchTree;
using DataStructers.Tree.BinaryTree;

namespace DataTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //DeepestNodeTest();
            //MaxDepthTest();
            //FindTest();
            //RemoveTest(22);
            //TraversalsTest();
            //MinMaxNodeTest();
            //NumberOfLeafTest();
            //NumberOfFullAndHalfNodesTest();
            //PrintPathsTest();
            GetEnumarateTest();


            Console.ReadKey();
        }

        private static void GetEnumarateTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });

            foreach (var item in BST)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintPathsTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            //BST.Remove(BST.Root, 3);

            new BinaryTree<int>().PrintPaths(BST.Root);
        }

        private static void NumberOfFullAndHalfNodesTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            BST.Remove(BST.Root, 3);
            BST.Remove(BST.Root, 37);

            Console.WriteLine($"Number of full nodes  : {BinaryTree<int>.NumberOfFullNodes(BST.Root)}");
            Console.WriteLine($"Number of half nodes  : {BinaryTree<int>.NumberOfHalfNodes(BST.Root)}");
        }

        private static void NumberOfLeafTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            BST.Remove(BST.Root, 22);

            Console.WriteLine($"Düğümdeki yaprak sayısı= {BinaryTree<int>.NumberOfLeafs(BST.Root)}");
        }

        private static void MinMaxNodeTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            Console.WriteLine($"Ağaçataki Minimum Değer= {BST.FindMin(BST.Root)}");
            Console.WriteLine($"Ağaçataki Maximum Değer= {BST.FindMax(BST.Root)}");
        }

        private static void TraversalsTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            var bt = new BinaryTree<int>();
            Console.Write("İnOrder= ");
            bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
            bt.ClearList();
            Console.WriteLine();
            Console.Write("PreOrder= ");

            bt.PreOrder(BST.Root).ForEach(node => Console.Write( node + " "));
            bt.ClearList();
            Console.WriteLine();
            Console.Write("PostOrder= ");

            bt.PostOrder(BST.Root).ForEach(node => Console.Write(  node + " "));
            bt.ClearList();
            Console.WriteLine();
            Console.Write("LevelOrder= ");

            bt.LevelOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(  node + " "));
            bt.ClearList();
            Console.WriteLine();
            Console.Write("PostOrderNonRecursive= ");

            bt.PostOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write( node + " "));
            bt.ClearList();
            Console.WriteLine();
            Console.Write("PreOrderNonRecursive= ");

            bt.PreOrderNonRecursiveTraversal(BST.Root).ForEach(node => Console.Write(node + " "));
        }

        private static void RemoveTest(int key)
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            var bt = new BinaryTree<int>();

            bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));

            Console.WriteLine();
            BST.Remove(BST.Root,key);
            bt.ClearList();

            bt.InOrder(BST.Root).ForEach(node => Console.Write(node + " "));
        }

        private static void FindTest()
        {
            var BST = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            var findKey = BST.Find(BST.Root, 45);
            if (findKey != null)
                Console.WriteLine($"Sayı= {findKey} Soldaki Değer= {findKey.Left} Sağdaki Değer= {findKey.Right} ");
        }

        private static void MaxDepthTest()
        {
            var BST = new BST<int>(new int[] { 60,40,70,20,45,65,85,3 });

            Console.WriteLine($"Maximum Derinlik= {BinaryTree<int>.MaxDepth(BST.Root)}");
        }

        private static void DeepestNodeTest()
        {
            var bt = new BinaryTree<char>();
            bt.Root = new Node<char> ('F');
            bt.Root.Left = new Node<char> ('A');
            bt.Root.Right = new Node<char> ('T');
            bt.Root.Left.Left = new Node<char> ('D');
            bt.Root.Right.Right = new Node<char>('C');


            var liste = bt.LevelOrderNonRecursiveTraversal(bt.Root);
            foreach (var node in liste)
            {
                Console.Write($"{node,-3}" );
            }
            Console.WriteLine();


            Console.WriteLine($"En Derin Düğüm =  { bt.DeepestNode(bt.Root)}");
            Console.WriteLine($"En Derin Düğüm =  { bt.DeepestNode()}");
            Console.WriteLine($"Max. Derinlik  =  { BinaryTree<char>.MaxDepth(bt.Root) }");
        }
    }
}
