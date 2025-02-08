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
            throw new NotImplementedException();
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


    }
}
