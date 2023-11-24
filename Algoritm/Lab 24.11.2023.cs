using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student("Gogl", "00", 2001);
            Student b = new Student("Bulb", "01", 2002);
            Student c = new Student("Urog", "10", 2003);
            Student d = new Student("Ivan", "11", 2002);
            Student e = new Student("Glag", "00", 2001);
            Student[] mas = { a, b, c, d, e };
            string p = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            Console.WriteLine("Выборка по группе: ");
            for (int i = 0; i < 5; i++) mas[i].KriteriyGroup(p);  
            Console.WriteLine("Выборка по году рождения: ");
            for (int i = 0; i < 5; i++) mas[i].KriteriyYear(r);
        }
    }
    class Student
    {
        string FIO, group;
        int year;
        public Student(string FIO, string group, int year)
        {
            this.FIO = FIO;
            this.group = group;
            this.year = year;
        }

        public string Name
        {
            get {return FIO;} 
            set {FIO = value;}
        }

        public int Year
        {
            get {return year;} 
            set {year = value;}
        }

        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        public void PrintData()
        {
            Console.WriteLine("ФИО: {0} \nГод рождения: {1} \nГруппа: {2}", Name, Year, Group);
            Console.WriteLine();
        }

        public void KriteriyGroup(string group)
        {
            if (Group == group)
                PrintData();
        }

        public void KriteriyYear(int year)
        {
            if (Year == year)
                PrintData();
        }
    }
}
