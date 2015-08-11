using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Felidae
    {
        private bool male;

        public Felidae() : this(true) { }

        public Felidae(bool male)
        {
            this.male = male;
        }

        public bool Male
        {
            get
            {
                return male;
            }
            set
            {
                this.male = value;
            }
        }
    }
    public class Lion : Felidae
    {
        private int weight;

        public Lion(bool male, int weight)
            : base(male)
        {
            this.weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            set { this.weight = value; }
        }

        public override string ToString()
        {
            return String.Format("Is lion male:{0}",base.Male ? "Yes":"No") + 
                ("\nLion weight:" + this.Weight);
        }
        // ...
    
    }
    public class AfricanLion : Lion
    {
        // ...

        // If we comment the next line with ":base(male, weight)"
        // the class will not compile. Try it.
        public AfricanLion(bool male, int weight)
            : base(male, weight)
        { }

        public override string ToString()
        {
            return string.Format(
                    "(AfricanLion, male: {0}, weight: {1})",
                    this.Male, this.Weight);
        }

        // ...
    }

    class Inheritance
    {
        static void Main(string[] args)
        {
            Lion leo = new AfricanLion(true,50); 
            Console.WriteLine(leo);
        }
    }
}
