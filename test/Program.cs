using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Object2> objects = new List<Object2>();
            objects.Add(new Object2("1"));
            objects.Add(new Object2("2"));
            objects.Add(new Object2("3"));
            objects.Add(new Object2("4"));
            Object1 ob1 = new Object1();
            ob1.object2 = objects;
            Object1 ob2 = new Object1();
            ob2.object2 = objects;
            Object1 ob3 = new Object1();
            ob3.object2 = objects;


            objects.Add(new Object2("5"));
            objects.Add(new Object2("6"));
            ob2.object2 = new List<Object2>();
            objects.Add(new Object2("7"));
            ob3.object2.Clear();
            objects.Add(new Object2("8"));
        }
    }
}
