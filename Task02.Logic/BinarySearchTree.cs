using System;
using System.Collections.Generic;

namespace Task02.Logic
{
    public class BinarySearchTree<T>
    {
        /// <summary>
        /// Node of our custom tree
        /// </summary>
        private class Node<T>
        {
            public T Value { get; set; }
            public Node<T> left, right;

            public Node(T value)
            {
                Value = value;
            }
        }

        
        private Node<T> root;
        private int count;

        /// <summary>
        /// criteria for build tree
        /// </summary>
        private IComparer<T> comparer; 
        
        public bool IsEmpty => root == null;

        /// <summary>
        /// constructor, use default compare criteria of type, or external comparer;
        /// </summary>
        /// <param name="comparer">external comparer</param>
        /// <exception cref="ArgumentException">if no default comparer and external comparer is null</exception>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            this.comparer = comparer;
            root = null;
            count = 0;
            Type[] interfaces = typeof (T).GetInterfaces();
            if (comparer == null)
            {
                foreach (var intfc in interfaces)
                {
                    if (intfc != typeof (IComparable) && (intfc != typeof (IComparable<T>))) continue;
                    this.comparer = Comparer<T>.Default;
                    return;
                }
                throw new ArgumentException("Binary search tree cant work with this type");
            }
        }

        public BinarySearchTree(IEnumerable<T> collection, Comparison<T> comparison ):this(collection,new ComparerComparisionAdapter<T>(comparison)) { } 

        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer = null) : this(comparer)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        } 
        
        /// <summary>
        /// method of adding element to the our tree
        /// </summary>
        /// <param name="elem">element of T type</param>
        public void Add(T elem)
        {
            Node<T> x = root, y = null;
            while (x != null)
            {
                int cmp = comparer.Compare(elem,x.Value);
                if (cmp == 0)
                {
                    x.Value = elem;
                    return;
                }
                else
                {
                    y = x;
                    if (cmp < 0)
                    {
                        x = x.left;
                    }
                    else
                    {
                        x = x.right;
                    }
                }
            }

            Node<T> newNode = new Node<T>(elem);
            if (y == null)
            {
                root = newNode;
            }
            else
            {
                if (comparer.Compare(elem,y.Value) < 0)
                {
                    y.left = newNode;
                }
                else
                {
                    y.right = newNode;
                }
            }
        }

        /// <summary>
        /// method contains for our tree
        /// </summary>
        /// <param name="elem">element which we want test for contain</param>
        /// <returns>true or false</returns>
        public bool Contains(T elem)
        {
            Node<T> x = root;
            while (x != null)
            {
                int cmp = comparer.Compare(elem,x.Value);
                if (cmp == 0)
                {
                    return true;
                }
                if (cmp < 0)
                {
                    x = x.left;
                }
                else
                {
                    x = x.right;
                }
            }
            return false;
        }

        /// <summary>
        /// method for remove element from tree
        /// </summary>
        /// <param name="elem">element which we want remove</param>
        /// <exception cref="ArgumentException">when no such element in tree</exception>
        public void Remove(T elem)
        {
            Node<T> x = root, y = null;
            while (x != null)
            {
                int cmp = comparer.Compare(elem,x.Value);
                if (cmp == 0)
                {
                    break;
                }
                else
                {
                    y = x;
                    if (cmp < 0)
                    {
                        x = x.left;
                    }
                    else
                    {
                        x = x.right;
                    }
                }
            }
            if (x == null)
            {
                return;
            }
            if (x.right == null)
            {
                if (y == null)
                {
                    root = x.left;
                }
                else
                {
                    if (x == y.left)
                    {
                        y.left = x.left;
                    }
                    else
                    {
                        y.right = x.left;
                    }
                }
            }
            else
            {
                Node<T> leftMost = x.right;
                y = null;
                while (leftMost.left != null)
                {
                    y = leftMost;
                    leftMost = leftMost.left;
                }
                if (y != null)
                {
                    y.left = leftMost.right;
                }
                else
                {
                    x.right = leftMost.right;
                }
                x.Value = leftMost.Value;
            }
            throw new ArgumentException("no such element in tree");
        }


        public IEnumerable<T> InOrderEnumerator()
        {
            return InOrderEnumerator(root);
        }

        public IEnumerable<T> PreOrderEnumerator()
        {
            return PreOrderEnumerator(root);
        }

        public IEnumerable<T> PostOderEnumerator()
        {
            return PostOrderEnumerator(root);
        }

        private IEnumerable<T> InOrderEnumerator(Node<T> x)
        {
            if (x != null)
            {
                foreach (var item in InOrderEnumerator(x.left))
                {
                    yield return item;
                }
                yield return x.Value;
                foreach (var item in InOrderEnumerator(x.right))
                {
                    yield return item;
                };
            }
        }

        private IEnumerable<T> PreOrderEnumerator(Node<T> x)
        {
            if (x != null)
            {
                yield return x.Value;
                foreach (var item in PreOrderEnumerator(x.left))
                {
                    yield return item;
                }
                foreach (var item in PreOrderEnumerator(x.right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> PostOrderEnumerator(Node<T> x)
        {
            if (x != null)
            {
                foreach (var item in PostOrderEnumerator(x.left))
                {
                    yield return item;
                }
                foreach (var item in PostOrderEnumerator(x.right))
                {
                    yield return item;
                }
                yield return x.Value;
            }
        }
    } 
}
