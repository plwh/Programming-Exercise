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
            Node newNode = new Node(item); // syzdavame elementa, kojto shte vmykvame
            int currentIndex = 0;
            Node current = head; 
            Node prev = null; // tazi promenliva pazi predishniq element. Principno moje da se maxne ottuk(kakto i dolu v while-a) i da se zameni s current.Prev navsqkude kydeto se sreshta
                              // po-dolu. Tova moje da se napravi samo pri dvusvyzaniq spisuk zashtoto pri ednosvyrzaniq nqmame Prev, a samo Next
            while (currentIndex < index)
            {
                prev = current; // primerno ako imame spisyk s elementi 1 2 3 i iskame da vmyknem element na poziciq 1(mejdu 1 i 2) prev shte e raven na 1
                current = current.Next; // current shte e raven na 2
                currentIndex++; // currentIndex shte e raven na 1
            }
            if (index == 0) // ako poziciqta na koqto iskame da dobavim element e 0 (t.e predi vsichki elementi)
            {
                if (count == 0) // proverqvame dali spisyka e prazen, ako da dobavqme nov element izpolzvajki metoda napisan po-gore(Add) i s return prekratqvame izpylnenieto na InsertAt
                {
                    this.Add(item);
                    return;
                }
                else // ako spisyka ne e bil prazen, a poziiciqta na koqto iskame da dobavim element e 0(t.e. predi vsichki elementi) vlizame tuk
                {
                    /*  newNode = 4, head = 1
                 *     head.Prev      |             (1)                 (3)     head  |                (4)
                 *         |          |              |                   |       |    |                 |
                 *   null <--  1      |      null <-------- newNode <--------   1     |  null <----- newNode <------- 1
                 *             |      |                         4    -------->        |                 4     ------->
                 *           head     |                                  |            |
                 *                    |                                 (2)           |
                 */
                    newNode.Prev = head.Prev; // (1)
                    newNode.Next = head;      // (2)
                    head.Prev = newNode;      // (3)
                    head = newNode;           // (4)
                }
            }
            else if (index == count) // ako poziciqta na koqto iskame da dobavim element e ravna na broq na elementite(t.e sled vsichki elementi) vlizame tuk 
            {   /*  newNode = 4, tail = 3
                 *     tail            |       tail newNode.Prev  |                tail
                 *       |             |         |     |          |                 |
                 *       3 --> null    |         3 <---- newNode  |        3 <-- newNode --> null 
                 *         |           |            ---->   4     |           -->    4
                 *       tail.Next     |              |           |
                 *                     |          tail.Next       |
                 */
                newNode.Prev = tail; 
                tail.Next = newNode; 
                tail = newNode; 
            }
            else // ako poziciqta e mejdu elementite v spisyka(t.e. nito v nachaloto nito v kraq) vlizame tuk
            {
                /*  newNode = 4, prev = 1, current = 2
                 *     current.Prev      |               (1)               (2)    
                 *         |             |                |                 |
                 *   prev <-- current    |      prev  <-------- newNode <--------  current
                 *     1  -->    2       |       1    -------->    4    -------->     2
                 *         |             |                |                 |
                 *       prev.Next       |               (4)               (3) 
                 */
                newNode.Prev = current.Prev; // (1)
                current.Prev = newNode;      // (2)
                newNode.Next = prev.Next;    // (3) newNode.Next = current.Prev.Next \___ pravqt sushtoto
                prev.Next = newNode;         // (4) current.Prev.Next = newNode      /
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
            if (index == 0) // ako poziciqta na koqto iskame da premaxmen element e 0 (t.e 1viq element)
            {
                if (count == 1) // ako broq na elementite e raven na 1(toest sled premahvane na elementa na nuleva poziciq spisyka stava prazen)
                {
                    // pravim glavata i opashkata null
                    head = null;
                    tail = null;
                }
                else // ako ne vlizame tuk
                {
                    // premestvame glavata na sledvashtiq element i pravim Prev pointera mu da sochi kym null
                    head = current.Next;
                    head.Prev = null;
                }
            }
            else if (index == count - 1) // ako poziciqta e v kraq na spisuka(t.e. ako imame 2 elementa, 2riq element se namira na indeks 1, koeto e count-1) vlizame tyk
            {
                /*  current = 2, prev = 3, tail = 2
                *             tail      |     tail = prev                          
                *               |       |        |                          
                *   prev <-- current    |      prev  <-----current-------->  null 
                *     3  -->    2       |       3   \         2             /    
                *         |             |            \_____________________/                    
                *         |             |                      |      
                *       prev.Next       |             prev.Next = current.Next            
                */
                prev.Next = current.Next; // prev.Next = null - pravi sushtoto
                tail = prev;                       
            }
            else // ako poziciqta e mejdu elementite v spisyka(t.e. nito v nachaloto nito v kraq) vlizame tuk
            {
                /*  prev = 2, current = 3, current.Next = 4
                *      current.Prev     |              current.Next.Prev = prev;                                     
                *         |             |           ___________|_____________ 
                *         |             |          /                         \
                *   prev <-- current    |      prev  <-----current       current.Next
                *     2  -->    3       |       2  \         3     -------->  4 
                *         |             |           \________________________/                    
                *         |             |                      |      
                *       prev.Next       |           prev.Next = current.Next            
                */
                prev.Next = current.Next;
                current.Next.Prev = prev;
            }
            count--;
        }

        /* - Alternativna versiq na metoda Remove napisan po-dolu, izpolzvaiki metoda RemoveAt, napisan po-gore
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

        public void Remove(object item) /*Metod za premahvane na obekt po st-st. Povecheto neshta sa vzaimstvani ot metoda RemoveAt, zatova spored men zakomentiraniq metod Remove 
            po-gore e po-udachniq variant*/
        {
            Node current = head;
            Node prev = null;
            int itemIndex = 0; 
            while (!current.Data.Equals(item)) // Neshtata v while-a se izpylnqvat dokato stoinostta na segashniq element e razlichna ot tazi na elementa kojto iskame da premahnem 
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
                    head = current.Next;
                    head.Prev = null;
                }
            }
            else if (itemIndex == count-1)
            {
                prev.Next = current.Next;
                tail = prev;
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

