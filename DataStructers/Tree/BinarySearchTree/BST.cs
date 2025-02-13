using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DataStructers.Tree.BinaryTree;

namespace DataStructers.Tree.BinarySearchTree
{
    //IEnumarable ile koleksiyonun gezilebilir olmasını sağlamak için implemente ediyoruz.
    public class BST<T> : IEnumerable<T>
    //Ağaca veri eklemek istediğimizde bunu karşılaştırarak ekleyeceğimiz için T'yi Compare edebileceğimiz veri tipleri ile sınırladık.
     where T: IComparable
    {

        public Node<T> Root { get; set; }
        public BST()
        {
            
        }
        public BST(IEnumerable<T> collections)
        {
            foreach (var item in collections)
            {
                Add(item);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumarate<T>(Root);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            if (value==null)
                throw new ArgumentNullException();

           var newNode = new Node<T>(value);

           if (Root==null)
           {
               Root= newNode;
           }
           else
           {
               //dolaşım için kullanacağımız değişken bu olacak

                var current = Root;


                //Ağaç yapısında bir aile yapısı kurduğumuzdan parent düğümünü kullanacaz

                Node<T> parent;


                //karşılaştırmalarımızı yapacaz buna göre sağ veya sol tarafa ilerleyip null bulduğumuz yere değeri ekleyecez
                //Karşılaştırmayı Compare To ile yapacaz ve bu bize 0-1-(-1) değerlerini dönecek.

                while (true)
                {
                    parent = current;
                    
                    //sol alt ağaç
                    if (value.CompareTo(current.Value)<0)
                    {
                       current =current.Left;

                        if (current==null)
                        {
                            parent.Left= newNode;
                            break;
                        }
                    }
                    //sağ alt ağaç
                    else
                    {
                        current = current.Right;

                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
           }

        }

        public Node<T> FindMin(Node<T> root)
        {
            var current = root;
            while (!(current.Left == null))
                current = current.Left;
            return current;
            
        }

        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (!(current.Right == null))
                current = current.Right;
            return current;

        }

        public Node<T> Find(Node<T> root, T key)
        {
            var current = root;
            while (key.CompareTo(current.Value)!=0)
            {
                if (key.CompareTo(current.Value) < 0)
                    current = current.Left;
                else
                    current=current.Right;
                if (current == null)
                    return default(Node<T>);
            }
            return current;
        }

        public Node<T> Remove(Node<T> root, T key)
        {
            if (root==null)
            {
                return root;//throw new ArgumentNullException("Hata Mesajımız");
            }

            if (key.CompareTo(root.Value)<0)
            {
                root.Left = Remove(root.Left, key);
            }
            else if (key.CompareTo(root.Value)>0)
            {
                root.Right = Remove(root.Right, key);
            }

            else
            {
                //Silme işlemini uygulayabiliriz
                //Tek çocuk veya çocuksuz olma durumu
                if (root.Left==null)
                {
                    return root.Right;
                }
                else if (root.Right==null)
                {
                    return root.Left;
                }
                

                //İki çocuk olma durumu
                root.Value = FindMin(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);
            }
            return root;
        }

    }
}
