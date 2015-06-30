using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValueAndReferenceType
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Skills { get; set; }
        public double AverageMark { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Beseda Dmitriy",
                Age = 23,
                AverageMark = 4.73,
                Skills = new List<string>()
                {
                    "C#",
                    "JS",
                    "HTML",
                    "CSS",
                    "NodeJS"
                }
            };

            var anotherPerson = person;

            Console.WriteLine("person.AverageMark {0}", person.AverageMark);

            anotherPerson.AverageMark = 5;

            Console.WriteLine("person.AverageMark {0}", person.AverageMark);

            var randomNumber = 777;

            Console.WriteLine("\n\nNumber before ChangeValueType {0}", randomNumber);
            ChangeValueType(randomNumber);
            Console.WriteLine("Number after ChangeValueType {0}", randomNumber);

            Console.WriteLine("\n\nNumber before ChangeReferenceType {0}", randomNumber);
            ChangeReferenceType(ref randomNumber);
            Console.WriteLine("Number after ChangeReferenceType {0}", randomNumber);

            var someString = "Hello World";
            Console.WriteLine("\n\nsomeString to upper: " + someString.ToUpper());
            Console.WriteLine("someString:" + someString);
            

            Console.ReadLine();
        }

        static void ChangeValueType(int number)
        {
            number++;
        }

        static void ChangeReferenceType(ref int number)
        {
            number++;
        }
    }
}
