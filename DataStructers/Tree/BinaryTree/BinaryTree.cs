using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStructers.Queue;

namespace DataStructers.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public  Node<T> Root { get; set; }
        public List<Node<T>> list { get; private set; }

        public BinaryTree()
        {
            list = new List<Node<T>>();
        }

        public List<Node<T>> InOrder(Node<T> root)
        {
            if (!(root == null))
            {

                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var stack = new DataStructers.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done= false;

            while (!done)
            {
                if (currentNode!=null)
                {
                      stack.Push(currentNode);
                      currentNode = currentNode.Left;
                    
                }
                else
                {
                    if (stack.Count==0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode=stack.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }

                }
            }

            return list;

        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root == null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }

            return list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var stack = new DataStructers.Stack.Stack<Node<T>>();
            if (root == null)
                throw new Exception("This tree is empty.");

            stack.Push(root);

            while (!(stack.Count == 0))
            {
                var temp = stack.Pop();
                list.Add(temp);
                if (temp.Right != null)
                    stack.Push(temp.Right);
                if (temp.Left != null)
                    stack.Push(temp.Left);
            }

            return list;

        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root==null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> PostOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var stack = new DataStructers.Stack.Stack<Node<T>>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                list.Add(node);

                if (node.Left != null)
                     stack.Push(node.Left);

                if (node.Right !=null)
                    stack.Push(node.Right);
            }

            list.Reverse();
            return list;

        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var queue = new DataStructers.Queue.Queue<Node<T>>();
            queue.EnQueue(root);

            while (queue.Count != 0)
            {
                var temp = queue.DeQueue();
                list.Add(temp);

                if (temp.Left != null)
                    queue.EnQueue(temp.Left);

                if (temp.Right != null)
                    queue.EnQueue(temp.Right);
            }

            return list;

        }
        //Kendi algoritmamız
        public Node<T> DeepestNode(Node<T> root)
        {
            Node<T> temp = null;
            if (root == null) throw new Exception("Empty Tree!");
            var queue = new DataStructers.Queue.Queue<Node<T>>();

            queue.EnQueue(root);


            while (queue.Count>0)
            {
                temp= queue.DeQueue();
                if (temp.Left!=null)
                    queue.EnQueue(temp.Left);
                if (temp.Right != null)
                    queue.EnQueue(temp.Right);
            }
            return temp;
        }
        //LevelOrder dolaşmayla kurulan algoritma
        public Node<T> DeepestNode()
        {
            var list = LevelOrderNonRecursiveTraversal(Root);
            return list[list.Count - 1];
        }
        public static int NumberOfLeafs(Node<T> root)
        {
            //Kendi algoritmamız
            int count = 0;
            if (root == null) return count;
            var queue = new DataStructers.Queue.Queue<Node<T>>();
            queue.EnQueue(root);
            while (queue.Count > 0)
            {
                var temp = queue.DeQueue();
                if (temp.Left == null && temp.Right == null)
                    count++;
                if (temp.Left != null)
                    queue.EnQueue(temp.Left);
                if (temp.Right != null)
                    queue.EnQueue(temp.Right);
            }

            return count;

            //LevelOrder dolaşmayla kurulan algoritma
            //return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
            //    .Where(x => x.Left == null && x.Right == null).ToList().Count();
        }
        public static int MaxDepth(Node<T> root)
        {
            if (root==null)
                return 0;
            int leftDepth = MaxDepth(root.Left);
            int rightDepth = MaxDepth(root.Right);

            return (leftDepth>rightDepth) ? leftDepth+1 : rightDepth+1;
        }

        public static int NumberOfFullNodes(Node<T> root)
        {
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
                .Where(node => node.Left!=null&&node.Right!=null)
                .ToList()
                .Count;
        }
        public static int NumberOfHalfNodes(Node<T> root)
        {
            return new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root)
                .Where(node => (node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
                .ToList()
                .Count;
        }

        public void PrintPaths(Node<T> root)
        {
            var path = new T[256];
            PrintPaths(root, path, 0);
        }

        private void PathArray(T[] path, int len)
        {
            for (int i = 0; i < len; i++)
            {
                Console.Write($"{path[i]} ");
            }
            Console.WriteLine();
        }

        private void PrintPaths(Node<T> root, T[] path, int pathLen)
        {
            if (root == null) return;

            path[pathLen] = root.Value;
            pathLen++;

            if (root.Left==null&&root.Right==null)//Yaprak mı?
            {
                PathArray(path,pathLen);
            }
            else
            {
                PrintPaths(root.Left,path,pathLen);
                PrintPaths(root.Right,path,pathLen);
            }

        } 



        public void ClearList() => list.Clear();


    }

}

