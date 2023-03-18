using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkList
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            this.Next = null;
            this.Data = t;
        }
    }
    public class GenericList<T>
    {
        private Node<T> tail;
        private Node<T> head;
        public GenericList() 
        {
            tail = head = null;
        }
        public Node<T> Head
        {
            get => head;
        }
        public void Add(T t) 
        {
            Node<T> n =new Node<T>(t);
            if (tail == null) 
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void ForEach(Action<T> action) 
        {
            for (Node<T> node = head; node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }
    public class main
    {
        static void Main(string[] args)
        {
            GenericList<int> intlist = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                intlist.Add(i);
            }
            Console.Write("Elements in list is: ");
            intlist.ForEach(s => Console.Write(s + " "));
            Console.WriteLine();

            Console.Write("Maximum of list is: ");
            int max = intlist.Head.Data;
            intlist.ForEach(s => { if (s >= max) max = s; });
            Console.WriteLine(max);

            Console.Write("Minimum of list is: ");
            int min = intlist.Head.Data;
            intlist.ForEach(s => { if (s <= min) min = s; });
            Console.WriteLine(min);

            Console.Write("Summary of list is: ");
            int sum = 0;
            intlist.ForEach(s=>sum += s);
            Console.WriteLine(sum);
        }
    }
}