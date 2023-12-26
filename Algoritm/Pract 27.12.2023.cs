using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet a = new Planet("p1", 10);
            Planet b = new Planet("p2", 5);
            Planet c = new Planet("p3", 5);
            Planet d = new Planet("p4", 1500);
            Planet e = new Planet("p5", 0);
            Planet[] mas = { a, b, c, d, e };
            List<int> masv = new List<int>();
            List<string> masn = new List<string>();
            foreach (Planet x in mas) if (!masv.Contains(x.value)) masv.Add(x.value);
            masv.Sort();
            for (int i = (masv.Count - 1); i >= 0; i--)
            {
                foreach (Planet x in mas) if (x.value == masv[i]) Console.WriteLine(x.name + ": " + x.value);
            }
        }
    }
    class Planet
    {
        public string name;
        public int value;

        public Planet(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
    }
    
}
