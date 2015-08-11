using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    class TestMethods
    {
        public void Draw(int number)
        {
            Console.WriteLine(number);
        }

        public void Draw(string str)
        {
            Console.WriteLine(str);
        }       
    }

    class MethodOverloading
    {
       
        static void Main(string[] args)
        {
            TestMethods test = new TestMethods();
            string str = "This is a test";
            int number = 12;
            test.Draw(number);
            test.Draw(str);
        }
    }
}
