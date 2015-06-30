using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTypes
{

    public class Parent
    {
        private int someVariable;
    }

    public class Child : Parent
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            //int b = a;
            int b = 20;
            //a = b;

            Child child = new Child();
            Parent parent = new Parent();
            parent = child;
            //child = parent;
            Child[] childArr = new Child[10];
            Parent[] parentArr = new Parent[10];
            parentArr = childArr;


            int[] ints = new int[] {1, 5, 3, 5, 6};
            double[] doubles;
            //doubles = (double[]) ints;
            doubles = new double[ints.Length];
            Array.Copy(ints, doubles, ints.Length);


        }
    }
}
