using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractMethod
{
    public abstract class Animal
    {
        public void PrintInfo()
        {
            Console.WriteLine("I am a {0}.", this.GetType().Name);
            Console.WriteLine(GetTypicalSound());
        }
        protected abstract String GetTypicalSound();
    }

    public class Lion : Animal
    {
        protected override string GetTypicalSound()
        {
            return "Roar!";
        }
    }
    
    public class Cat : Animal
    {
        protected override string GetTypicalSound()
        {
            return "Miaow!";
        }
    }

    class AbstractMethod
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion();
            lion.PrintInfo();
            Cat cat = new Cat();
            cat.PrintInfo();
        }
    }
}
