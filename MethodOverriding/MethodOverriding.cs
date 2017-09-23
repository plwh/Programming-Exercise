using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverride
{
    public class BC
    {
        public virtual string Display()
        {
            return "Hello";
        }
    }

    public class DC : BC 
    {
        public override string Display()
        {
            return base.Display() + " World!";
        }
    }

    class Test
    {
        static void Main()
        {
            BC b;
            b = new BC();
            Console.WriteLine(b.Display());
            b = new DC();
            Console.WriteLine(b.Display());      
        }
    }
}
