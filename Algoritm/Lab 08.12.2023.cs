using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtraEmp emp = new ExtraEmp("", 0, 0, 0);
            string[] mas1 = { "C1", "C2", "B4" };
            MainEmp emp1 = new MainEmp("Bob", 40, 10, mas1);
            string[] mas2 = { "A1", "C10", "B5", "R1" };
            MainEmp emp2 = new MainEmp("Tony", 28, 1, mas2);
            ExtraEmp emp3 = new ExtraEmp("Donald", 24, 2, 25000);
            ExtraEmp emp4 = new ExtraEmp("Zuck", 20, 1, 25000);
            ExtraEmp emp5 = new ExtraEmp("Paul", 50, 16, 27000);
            MainEmp[] masm = { emp1, emp2 };
            ExtraEmp[] mase = { emp3, emp4, emp5 };
            foreach (var ma in masm) { ma.KolCred(ma); }
            emp.KolEarn(mase); // Не совсем понимаю как адекватно вызывать этот метод и можно ли так делать, но можно в начале создавать "нулевой" экземпляр класса и вызывать через него
        }
    }
    class Employee
    {
        public string name { get; set; }
        public int age { get; set; }
        public int experience { get; set; } // Нам передали что поля какие-то, поэтому я сделал такие поля, наверно это непринципиально
        public Employee(string name, int age, int experience)
        {
            this.name = name;
            this.age = age;
            this.experience = experience;
        }
        public int CountEl(List<int> mas, int elem)
        {
            int count = 0;
            foreach (var ma in mas) if (ma == elem) count++;
            return count;
        }
    }
    class MainEmp : Employee
    {
        string[] credits { get; set; }
        public MainEmp(string name, int age, int experience, string[] credits) : base(name, age, experience)
        {
            this.credits = credits;
        }
        public void KolCred(MainEmp worker)
        {
            Console.WriteLine($"Работник {worker.name} выдал {worker.credits.Length} кредитов(-а)");
        }
    }
    class ExtraEmp : Employee
    {
        int earn { get; set; }
        public ExtraEmp(string name, int age, int experience, int earn) : base(name, age, experience)
        {
            this.earn = earn;
        }
        public void KolEarn(ExtraEmp[] workers)
        {
            var lst1 = new List<int>();
            var lst2 = new List<int>();
            foreach (ExtraEmp worker in workers)
            {
                if (!lst1.Contains(worker.earn))
                {
                    lst1.Add(worker.earn);
                }
                lst2.Add(worker.earn);
            }
            foreach (int earn in lst1) Console.WriteLine($"Зарплата: {earn}; Количество зарплат: {CountEl(lst2, earn)}");
        }
    }
}
