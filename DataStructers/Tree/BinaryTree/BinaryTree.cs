using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructers.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
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

        public void ClearList() => list.Clear();


    }

}

