using System;
using System.Collections;
using System.Collections.Generic;
using DataStructers.Tree.BinaryTree;

namespace DataStructers.Tree.BinarySearchTree
{
    internal class BSTEnumarate<T> : IEnumerator<T> where T : IComparable
    {
        private List<Node<T>> list;
        private int indexer = -1;

        public BSTEnumarate(Node<T> root)
        {
            list = new BinaryTree<T>().LevelOrderNonRecursiveTraversal(root);
        }
        public T Current => list[indexer].Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            list = null;
        }

        public bool MoveNext()
        {
            indexer++;

            return indexer < list.Count ? true : false;
        }

        public void Reset()
        {
            indexer = -1;
        }
    }
}