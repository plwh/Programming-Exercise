using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    public class DoublyLinkedList
    {
        private class Node
        {
            private object data;
            private Node next;
            private Node prev;

            public Node(object data)
            {
                this.data = data;
                this.next = null;
                this.prev = null;
            }

            public Node(object data, Node prevNode)
            {
                this.data = data;
                this.prev = prevNode;
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

            public Node Prev
            {
                get { return this.prev; }
                set { this.prev = value; }
            }
        }
        private Node head;
        private Node tail;
        private int count;

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public bool IsEmpty
        {
            get { return count == 0; }
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
                throw new ArgumentOutOfRangeException("Index is out of range!");
            Node newNode = new Node(item);
            int currIndex = 0;
            Node current = head;
            Node prev = null;
            while (currIndex < index)
            {
                prev = current;
                current = current.Next;
                currIndex++;
            }
            if (index == 0)
            {
                newNode.Prev = head.Prev;
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            else if (index == count - 1)
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = prev.Next;
                prev.Next = newNode;
                newNode.Prev = current.Prev;
                current.Prev = newNode;
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= count || index < 0)
                throw new ArgumentOutOfRangeException("Index is out of range!");
            int currIndex = 0;
            Node current = head;
            Node prev = null;
            while (currIndex < index)
            {
                prev = current;
                current = current.Next;
                currIndex++;
            }
            if (count == 0)
            {
                head = null;
            }
            else if (prev == null)
            {
                head = current.Next;
                head.Prev = null;
            }
            else if (index == count - 1)
            {
                prev.Next = current.Next;
                tail = prev;
                current = null;
            }
            else
            {
                prev.Next = current.Next;
                current.Next.Prev = prev;
            }
            count--;
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

        public int IndexOf(object item)
        {
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                    return i;

                current = current.Next;
            }
            return -1;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList test = new DoublyLinkedList();
            test.Add("Hello");
            test.Add("World");
            test.InsertAt("C#", 1);
            test.RemoveAt(1);
            test.Print();
        }
    }
}

