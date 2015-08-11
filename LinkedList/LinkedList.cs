using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList
    {
        private class Node
        {
            private object data;
            private Node next;

            public Node(object data)
            {
                this.data = data;
                this.next = null;
            }

            public Node(object data, Node prevNode)
            {
                this.data = data;
                prevNode.next = this;
            }

            public object Data
            {
                get { return this.data; }
                set { this.data = value; }
            }

            public Node Next
            {
                get { return this.next; }
                set { this.next = value; }
            }
        }
        private Node head;
        private Node tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(object item)
        {
            if (head == null)
            {
                head = new Node(item);
                tail = head;
            }
            else
            {
                Node newNode = new Node(item, tail);
                tail = newNode;
            }
            count++;
        }

        public void InsertAt(object item, int index)
        {
            count++;
            if (index >= count || index < 0)
                throw new ArgumentOutOfRangeException("Index is out of range");
            Node newNode = new Node(item);
            int currentIndex = 0;
            Node current = head;
            Node prev = null;
            while (currentIndex < index)
            {
                prev = current;
                current = current.Next;
                currentIndex++;
            }
            if (index == 0)
            {
                var temp = head;
                head = newNode;
                head.Next = temp;
            }
            else if (index == count - 1)
            {
                prev.Next = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = prev.Next;
                prev.Next = newNode;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index is out of range");   
            }
            int currentIndex = 0;
            Node current = head;
            Node prev = null;
            while (currentIndex < index)
            {
                prev = current;
                current = current.Next;
                currentIndex++;
            }
            count--;
            if (count == 0)
            {
                head = null;
            }
            else if (prev == null)
            {
                head = current.Next;
            }
            else 
            {
                prev.Next = current.Next;
            }
            if(object.ReferenceEquals(this.tail, current))
            {
                this.tail = prev;
            }          
        }

        public void Print()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }
    class Program
    {
        static void Main()
        {
            LinkedList test = new LinkedList();
            test.Add("Hello");
            test.Add("C#");
            test.Add("World");
            test.InsertAt("!",3);
            test.RemoveAt(1);
            test.Print();
        }
    }
}
