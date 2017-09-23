using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{

    class A
    {
        public virtual void F()
        {
            Console.WriteLine("A.F");
        }
    }
    abstract class B : A
    {
        public abstract override void F();
    }
    class C : B
    {
        public override void F()
        {
            Console.WriteLine("C.F");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            C test = new C();
            test.F();        
        }
    }
}
