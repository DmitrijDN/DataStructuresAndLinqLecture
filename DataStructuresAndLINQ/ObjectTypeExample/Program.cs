using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTypeExample
{

    public class Person: Object
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
                Skills = new List<string>()
                {
                    "C#",
                    "JS",
                    "HTML",
                    "CSS",
                    "NodeJS"
                },
                AverageMark = 4.73
            };

            Console.WriteLine(FormOutput(person, GetVariableName(() => person)));
            Console.WriteLine(FormOutput(person.Name, GetVariableName(() => person.Name)));
            Console.WriteLine(FormOutput(person.Age, GetVariableName(() => person.Age)));
            Console.WriteLine(FormOutput(person.AverageMark, GetVariableName(() => person.AverageMark)));
            Console.WriteLine(FormOutput(person.Skills, GetVariableName(() => person.Skills)));

            Console.WriteLine("\n\n\n");

            object testVariable = person;
            Console.WriteLine(FormOutput(testVariable, GetVariableName(() => testVariable)));

            testVariable = person.Name;
            Console.WriteLine(FormOutput(testVariable, GetVariableName(() => testVariable)));

            testVariable = person.Age;
            Console.WriteLine(FormOutput(testVariable, GetVariableName(() => testVariable)));

            testVariable = person.AverageMark;
            Console.WriteLine(FormOutput(testVariable, GetVariableName(() => testVariable)));

            testVariable = person.Skills;
            Console.WriteLine(FormOutput(testVariable, GetVariableName(() => testVariable)));

            Console.ReadLine();
        }

        static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression) expr.Body;

            return body.Member.Name;
        }

        static string FormOutput<T>(T variable, string variableName)
        {
            return "Variable \"" + variableName + "\"" + " type is " + variable.GetType() + " and value is: " + variable;
        }
    }
}
