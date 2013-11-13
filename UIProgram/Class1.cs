using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProgram
{
    public class Tree
    {
        public static Tree Default
        {
            get { return new Tree(); }
        }

        public Tree()
        {
            this.Name = "GreenTree";
        }

        public void GrowUp()
        {
            Console.WriteLine("Growing");
        }

        public void Drink()
        {
            Console.WriteLine("I need some water");
        }

        public void SayHi()
        {
            Console.WriteLine("~Hi,{0}", this.Name);
        }

        public void SayHi<T>(T t) where T : Tree
        {
            Console.WriteLine("~Hi,{0}", t.Name);
        }

        public void SayHi<P, X>(P p, X x)
            where P : BigTree
            where X : Tree
        {
            Console.WriteLine("~Hi,{0} & {1}", p.Name, x.Name);
        }

        public string Name { get; set; }
        public List<Tree> Trees = new List<Tree>();
        public Tree this[int i]
        {
            get { return this.Trees[i]; }
            set { this.Trees[i] = value; }
        }
    }

    public class BigTree : Tree
    {
        public int ID { get; set; }
        public new string Name { get; set; }
    }
}
