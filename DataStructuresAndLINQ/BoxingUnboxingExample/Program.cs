using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = DateTime.Now;
            for (var i = 0; i < 10000000; i++)
            {
                WithBoxing();
            }
            var end = DateTime.Now;
            var duration = end - start;
            Console.WriteLine("Time With boxing: {0}", duration.Milliseconds);

            start = DateTime.Now;
            for (var i = 0; i < 10000000; i++)
            {
                WithoutBoxing();
            }
            end = DateTime.Now;
            duration = end - start;
            Console.WriteLine("Time without unboxing: {0}", duration.Milliseconds);

            Console.ReadLine();

        }

        public static void WithBoxing()
        {
            var a = 1;
            object some = a;
        }

        public static void WithoutBoxing()
        {
            var a = 5;
            object some = a;
        }
    }
}
