using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class Queue
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

        public Queue()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Enqueue(object item)
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

        public object Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty");
            }
            Node current = head;
            head = head.Next;
            count--;
            return current.Data;
        }

        public void PrintQueue()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }
    }

    class Queue
    {
        static void Main()
        {
            Queue test = new Queue();
            test.Enqueue(2);
            test.Enqueue(3);
            test.Enqueue(4);
            test.Dequeue();
            test.PrintQueue();
            Console.WriteLine("*****************");
            Queue<int> test1 = new Queue<int>();
            test1.Enqueue(2);
            test1.Enqueue(3);
            test1.Enqueue(4);
            test1.Dequeue();
            foreach (int i in test1)
            {
                Console.WriteLine(i);
            }
        }
    }
}
