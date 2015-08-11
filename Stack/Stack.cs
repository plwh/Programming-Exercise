using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Stack
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

        private Node top;
        private int count;

        public Stack()
        {
            this.top = null;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Push(object item)
        {
            Node newNode = new Node(item);
            if (top == null)
            {
                top = newNode;
            }
            else
            {
                var temp = top;
                top = newNode;
                top.Next = temp;
            }
            count++;
        }

        public object Pop()
        {
            if (count == 0)
                throw new Exception("Stack is empty");
            Node current = top;
            top = top.Next;
            count--;
            return current.Data;
        }

        public object Peek()
        {
            return top.Data;
        }

        public bool Contains(object item)
        {
            Node current = top;
            for (int i = 0; i < count; i++)
            {
                if (current.Data.Equals(item))
                    return true;

                current = current.Next;
            }
            return false;
        }

        public void PrintStack()
        {
            Node current = top;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public void Clear()
        {
            this.top = null;
            this.count = 0;
        }
    }

    class Program
    {

        static void Main()
        {
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Console.WriteLine(stack.Count+ " " + stack.Contains(1));
            stack.PrintStack();
            Console.WriteLine("Top element:"+stack.Peek());
            Console.WriteLine("**************************");
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Pop();
            Console.WriteLine(stack1.Count + " " + stack1.Contains(1));
            foreach (int i in stack1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Top element:"+stack1.Peek());
       
        }
    }
}
