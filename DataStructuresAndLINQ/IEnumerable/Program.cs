using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    class Program
    {
        private static int[] simpleCollection= new int[] {5,3,6,7,8,5,3};
        static void Main(string[] args)
        {
            var i = 0;
            foreach (var item in simpleCollection)
            {
                Console.WriteLine("{0}: {1}", i++, item);
            }

            //ForEachImplementation();

            Console.ReadLine();
        }

        public static void ForEachImplementation()
        {
            var i = 0;
            IEnumerator enumerator = simpleCollection.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    object currentItem = enumerator.Current;
                    Console.WriteLine("{0}: {1}", i++, currentItem);
                }
            }
            finally
            {
                IDisposable e = enumerator as IDisposable;
                if (e != null)
                {
                    e.Dispose();
                }
            }
        }
    }
}
