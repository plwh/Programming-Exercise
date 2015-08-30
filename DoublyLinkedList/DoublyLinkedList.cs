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

            public override string ToString()
            {
                return this.Data.ToString();
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

        public void InsertAt(int index, object item)
        {
            if (index < 0 || index > count)
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
                if (count == 0)
                {
                    this.Add(item);
                    return;
                }
                else
                {
                    newNode.Prev = head.Prev;
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
            }
            else if (index == count)
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Prev = current.Prev;
                current.Prev = newNode;
                newNode.Next = prev.Next;
                prev.Next = newNode;
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException("Index is out of range");
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
                if (count == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                }
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

        /*
        public void Remove(object item)
        {
            int currentIndex = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    this.RemoveAt(currentIndex);
                    return;
                }
                current = current.Next;
                currentIndex++;
            }
            throw new ArgumentException("There is no such item.");
        }
        */

        public void Remove(object item)
        {
            Node current = head;
            Node prev = null;
            int itemIndex = 0;
            while (!current.Data.Equals(item))
            {
                prev = current;
                current = current.Next;
                itemIndex++;
            }
            if (itemIndex == 0)
            {
                if (count == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                }
            }
            else if (itemIndex == count-1)
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
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public void ChangeElementData(object elementToChange, object newData)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(elementToChange))
                {
                    current.Data = newData;
                    break;
                }
                current = current.Next;
            }
        }

        public void ChangeDataAtIndex(int index, object newData)
        {
            Node current = head;
            int currentIndex = 0;
            while (currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            current.Data = newData;
        }

        public object GetElementData(int index)
        {
            Node current = head;
            int currentIndex = 0;
            while (currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            return current.Data;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList test = new DoublyLinkedList();
            test.InsertAt(0, 1);
            test.InsertAt(1, 2);
            test.Add(3);
            Console.WriteLine("List elements:");
            test.Print();
            test.RemoveAt(0);
            Console.WriteLine("List elements after removing element at index 0:");
            test.Print();
            test.InsertAt(2, 4);
            Console.WriteLine("List elements after inserting an element at index 2(after the last element):");
            test.Print();
            Console.WriteLine("List elements after changing element data at index 1 with '5':");
            test.ChangeDataAtIndex(1, 5);
            test.Print();
            Console.WriteLine("List elements after changing element with value '2' to '3':");
            test.ChangeElementData(2, 3);
            test.Print();                 
            Console.WriteLine("List elements after removing element with value '5'");
            test.Remove(4);
            test.Print();
            object element = test.GetElementData(1);
            Console.WriteLine("Value of element at index 1:" + element);
            Console.WriteLine("Index of element with value 3:{0}", test.IndexOf(3));
            Console.WriteLine("List contains element with value = '5': {0}", (test.Contains(5)) ? "Yes" : "No");
            Console.WriteLine("Is list empty? - {0}", (test.IsEmpty) ? "Yes" : "No");
        }
    }
}

