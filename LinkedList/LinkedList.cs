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

            public Node(object data)
            {
                this.Data = data;
                this.Next = null;
            }

            public Node(object data, Node prevNode)
            {
                this.Data = data;
                prevNode.Next = this;
            }

            public object Data { get; set; }

            public Node Next { get; set; }
           
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

        public int Count
        {
            get { return count; }
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
                throw new ArgumentOutOfRangeException("Out of range");
            Node newNode = new Node(item);
            if (index == 0)
            {
                if (count == 0)
                {
                    this.Add(item);
                    return;
                }
                else
                {
                    newNode.Next = head;
                    head = newNode;
                }
            }
            else if (index == count)
            {
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                Node current = head;
                Node prev = null;
                for (int i = 0; i < index; i++)
                {
                    prev = current;
                    current = current.Next;
                }
                prev.Next = newNode;
                newNode.Next = current;
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Out of range");
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
            else
            {
                Node current = head;
                Node prev = null;
                for (int i = 0; i < index; i++)
                {
                    prev = current;
                    current = current.Next;
                }
                if (index == count - 1)
                {
                    prev.Next = current.Next;
                    tail = prev;
                }
                else
                {
                    prev.Next = current.Next;
                }
            }
            count--;
        }
        

        public int IndexOf(object item)
        {
            Node current = head;
            for(int i=0; i < count;i++)
            {
                if(current.Data.Equals(item))
                {
                    return i;       
                }
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(object item)
        {
            return IndexOf(item) != -1;
        }

        public void ChangeElementData(object elementToChange, object newData)
        {
            Node current = head;
            while(current!=null)
            {
                if(current.Data.Equals(elementToChange))
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
            while(currentIndex < index)
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
            while(currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }
            return current.Data;
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
            test.InsertAt(0, 1);
            test.InsertAt(1, 3);
            test.Add(5);
            test.InsertAt(1, 6);
            test.Print();
        }
    }
}
