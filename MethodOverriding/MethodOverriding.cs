using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverride
{
    public class BC
    {
        public virtual void Display()
        {
            Console.WriteLine("BC Display");
        }
    }

    public class DC : BC
    {
        public override void Display()
        {
            Console.WriteLine("DC Display");
        }
    }

    class Test
    {
        static void Main()
        {
            BC b;
            b = new BC();
            b.Display();
            b = new DC();
            b.Display();
        }
        
    }
}
