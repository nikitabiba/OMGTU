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
        public static float GetValue(Ceh ex, string name)
        {
            if (name == ex.name) return ex.value;
            else return 0;
        }
        public static float GetIntense(Ceh ex, string name, int year)
        {
            if (name == ex.name && ex.year == year) return ex.value / 365; else return 0;
        }
        static void Main(string[] args)
        {
            Ceh a = new Ceh("ceh1", 2005, 100);
            Ceh b = new Ceh("ceh1", 2006, 50);
            Ceh c = new Ceh("ceh1", 2007, 200);
            Ceh d = new Ceh("ceh2", 2000, 125);
            Ceh e = new Ceh("ceh2", 2005, 125);
            Ceh f = new Ceh("ceh3", 2020, 300);
            Ceh g = new Ceh("ceh3", 2021, 302);
            Ceh h = new Ceh("ceh4", 2023, 1);
            Ceh[] mas = { a, b, c, d, e, f, g, h };
            List<int> masg = new List<int>();
            List<string> masn = new List<string>();
            foreach(Ceh x in mas) if (!masg.Contains(x.year)) masg.Add(x.year);
            foreach (Ceh x in mas) if (!masn.Contains(x.name)) masn.Add(x.name);
            masg.Sort();
            masn.Sort();
            Console.Write("        ");
            foreach(int x in masg) Console.Write(x + "    ");
            Console.WriteLine("Итог");
            float itog = 0;
            bool flag = false;
            foreach (string x in masn)
            {
                Console.Write(x + "    ");
                foreach (int y in masg)
                {
                    foreach (Ceh z in mas) if (z.name == x && z.year == y)
                            {
                                Console.Write("{0, 4}    ", Math.Round(GetIntense(z, x, y), 2));
                                flag = true;
                            itog += GetValue(z, x);
                            }
                    if (!flag) Console.Write("{0, 4}    ", 0);
                    flag = false;
                }
                Console.WriteLine(itog);
                itog = 0;
            }
        }
    }
    class Ceh
    {
        public string name;
        public int year;
        public float value;

        public Ceh(string name, int year, float value)
        {
            this.name = name;
            this.year = year;
            this.value = value;
        }
    }
    
}
