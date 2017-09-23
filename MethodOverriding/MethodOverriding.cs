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
            return base.Display() + " Angel";
        }
    }

    class Test
    {
        static void Main()
        {
            BC b;
            b = new BC();
            string str = b.Display();
            b = new DC();
            string str1 = b.Display();
            Console.WriteLine(str);
            Console.WriteLine(str1);
        }
    }
}
