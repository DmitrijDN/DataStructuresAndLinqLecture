using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    public class Boy:Parent
    {
        
    }

    public class Girl: Parent
    {
        
    }

    public class Parent
    {
        
    }

    public class Child: Parent
    {
        
    }

    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public double Mark { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //OfTypeExample();
            //BitSqlSyntax();
            //LetExample();
            //OrderByExample();
            SelectManyExample();

            Console.ReadLine();
        }

        public static void OfTypeExample()
        {
            IEnumerable<Parent> family = new Parent[]
            {
                new Boy(),
                new Boy(),
                new Girl(),
                new Parent(),
                new Parent()
            };

            var query = family.OfType<Boy>();
            query.ToArray();

            //query = family.Cast<Boy>();
            //query.ToArray();

            Console.WriteLine(query);
        }

        public static void BitSqlSyntax()
        {
            var data = new List<string>
            {
                "Dima",
                "Bogdan",
                "Sanya",
                "Nikita",
                "Sergei",
                "Denis"
            };

            var query = (from item in data
                where item[0] == 'D'
                select item).ToList();

            query.ForEach(Console.WriteLine);

            //Console.WriteLine(query);
        }

        public static void OrderByExample()
        {
            var data = new List<string>
            {
                "Dima",
                "Bogdan",
                "Sanyochek",
                "Nikita",
                "Sergei",
                "Denis"
            };

            var query =  data.OrderBy(x => x[0]).ThenBy(y => y.Length).ToList();

            query.ForEach(Console.WriteLine);

            //Console.WriteLine(query);
        }

        public static void LetExample()
        {
            var newGroup = new List<Student>
            {
                new Student
                {
                    Name = "Dima",
                    Group = "BSA 15",
                    Mark = 5
                },
                new Student
                {
                    Name = "Sanya",
                    Group = "BSA 15",
                    Mark = 4.8
                },
                new Student
                {
                    Name = "Ivan",
                    Group = "BSA 14",
                    Mark = 3
                }
            };

            var query = from item in newGroup
                let cond = item.Mark - 2
                where cond > 2
                select new Academist
                {
                    Name = item.Name,
                    isEnter = true
                };


            Console.Write(query.FirstOrDefault().Name);
        }

        public static void SelectManyExample()
        {
            var schedule = new List<Schedule>
            {
                   new Schedule
                   {
                       roomNumber = 403,
                       Subjects = new List<Subject>
                       {
                           new Subject
                           {
                               Name = "Math",
                               Teachers = new List<Teacher>
                               {
                                   new Teacher {Name = "Ivanov"},
                                   new Teacher {Name = "Petrov"}
                               }
                           },
                           new Subject
                           {
                               Name = "History",
                               Teachers = new List<Teacher>
                               {
                                   new Teacher{Name = "Smirnov"}
                               }
                           }
                       }
                   }
            };


            var historySchedule = schedule.SelectMany(item => item.Subjects,
                (item, subject) => new {item, subject  }).Where(p => p.subject.Name == "History").ToList();

            historySchedule.ForEach(item =>
            {
                Console.WriteLine(item.item.roomNumber);
            });
        }
    }

    public class Schedule
    {
        public int roomNumber { get; set; }
        public List<Subject> Subjects { get; set; }
    }

    public class Subject
    {
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
    }


    public class Academist
    {
        public string Name { get; set; }
        public bool isEnter { get; set; }
    }
}