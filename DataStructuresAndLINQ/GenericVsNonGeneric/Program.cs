using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericVsNonGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            var genericList = new List<int>();
            var nonGenericList = new ArrayList();

            for (var i = 0; i < 10000000; i++)
            {
                genericList.Add(1);
                nonGenericList.Add(1);
            }

            var start = DateTime.Now;
            double result = genericList.Sum();
            var end = DateTime.Now;
            var duration = end - start;
            Console.WriteLine("Generic result: {0}\n generic time:{1}", result, duration.Milliseconds);

            result = 0;
            start = DateTime.Now;
            result = nonGenericList.Cast<int>().Sum();
            end = DateTime.Now;
            duration = end - start;
            Console.WriteLine("Generic result: {0}\n nongeneric time:{1}", result, duration.Milliseconds);

            Console.ReadLine();
        }
    }
}
