using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Note that each lambda expression has no parameters.
            LazyValue<int> lazyOne = new LazyValue<int>(() => ExpensiveOne());
            LazyValue<long> lazyTwo = new LazyValue<long>(() => ExpensiveTwo("apple"));

            Console.WriteLine("LazyValue objects have been created.");

            // Get the values of the LazyValue objects.
            Console.WriteLine(lazyOne.Value);
            Console.WriteLine(lazyTwo.Value);

            #region
            IList<Person> Persons = new List<Person>() { new Person { ID = 1, Name = "A", Code = "1;2;3;4;5;6;7;" }, new Person { ID = 2, Name = "B", Code = "0;1;2;3;4;5;6;7;" }, new Person { ID = 3, Name = "C", Code = "-1;0;1;2;3;4;5;6;7;" }, new Person { ID = 4, Name = "D", Code = "-1;0;1;2;3;4;5;6;7;" } };
            MyValue<Person> myValue = new MyValue<Person>();
            var codeA = myValue.Getter((ps) => ps.Select((p) => p.Code).Distinct(), Persons);
            Console.WriteLine(myValue.Getter((cs) =>
            {
                var result = "";
                foreach (var c in cs)
                {
                    result += c;
                }
                return result;
            }, codeA));
            var codeS = myValue.Getter((cs) =>
            {
                var result = "";
                foreach (var c in cs)
                {
                    result += c;
                }
                return result;
            }, codeA);
            foreach (var c in codeS.Split(';'))
            {
                Console.Write("[{0}] ", c);
            } Console.WriteLine();
            foreach (var c in codeS.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.Write("[{0}] ", c);
            } Console.WriteLine();
            codeS = myValue.NewGetter((ps) => ps.Select((p) => p.Code).Distinct(), Persons);
            Console.WriteLine(codeS);
            #endregion

            Console.ReadKey(true);
        }

        static int ExpensiveOne()
        {
            Console.WriteLine("\nExpensiveOne() is executing.");
            return 1;
        }

        static long ExpensiveTwo(string input)
        {
            Console.WriteLine("\nExpensiveTwo() is executing.");
            return (long)input.Length;
        }
    }

    class MyValue<T>
    {
        private Func<IList<T>, IEnumerable<string>> GetObject;
        public string[] Getter(Func<IList<T>, IEnumerable<string>> func, IList<T> ts)
        {
            this.GetObject = func;
            return this.GetObject(ts).ToArray();
        }

        private Func<string[], string> GetString;
        public string Getter(Func<string[], string> func, string[] codes)
        {
            //this.GetString = new Func<string[], string>(DoGetter);
            this.GetString = func;
            return this.GetString(codes);
        }

        public string NewGetter(Func<IList<T>, IEnumerable<string>> func, IList<T> ts)
        {
            this.GetObject = func;
            return string.Join("", this.GetObject(ts).ToArray());
        }

        private string DoGetter(string[] codes)
        {
            var result = "";
            foreach (var c in codes)
            {
                result += c;
            }
            return result;
        }
    }

    class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    class LazyValue<T> where T : struct
    {
        private Nullable<T> val;
        private Func<T> getValue;

        public LazyValue() { }

        // Constructor.
        public LazyValue(Func<T> func)
        {
            val = null;
            getValue = func;
        }

        public T Value
        {
            get
            {
                if (val == null)
                    // Execute the delegate.
                    val = getValue();
                return (T)val;
            }
        }
    }
    /* The example produces the following output:

        LazyValue objects have been created.

        ExpensiveOne() is executing.
        1

        ExpensiveTwo() is executing.
        5
    */
}

//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//        }
//    }
//}