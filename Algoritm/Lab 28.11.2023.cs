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
            int[] year1 = {2004, 2008, 2012, 2016, 2020};
            string[] people1 = {"ТАМ", "ФЛУ", "ЙОУ", "ЯФХ"};
            Car car1 = new Car("BMW", 2000, year1, people1, "red");

            int[] year2 = {2023};
            string[] people2 = {"РВУ"};
            Car car2 = new Car("AUDI", 2023, year2, people2, "blue");

            int[] year3 = {1990, 2000, 2010, 2020};
            string[] people3 = { "ЛОП", "ЙЛМ", "АВФ", "ОНЦ" };
            Car car3 = new Car("ВАЗ", 1987, year3, people3, "red");

            int[] year4 = {2023};
            string[] people4 = {"ПАР"};
            Car car4 = new Car("BMW", 2023, year4, people4, "green");

            int[] year5 = {2015, 2020};
            string[] people5 = {"ГЙЦ", "ВФЯ"};
            Car car5 = new Car("Lexus", 2015, year5, people5, "purple");

            Car[] cars = {car1, car2, car3, car4, car5};

            Console.Write("Наименование: ");
            string name = Console.ReadLine();
            
            foreach(Car car in cars)
            {
                car.name_kriteriy(name);
            }

            Console.WriteLine();
            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());
            foreach (Car car in cars)
            {
                car.year_kriteriy(year);
            }
            Console.WriteLine();
            Console.Write("Год осмотра: ");
            int osmotr = int.Parse(Console.ReadLine());
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Car {0}: ", i + 1);
                cars[i].osmotr_kriteriy(osmotr);
            }
        }
    }

    class Car
    {
        public string name;
        public int year;
        public int[] osmotr;
        public string[] fio;
        public string color;

        public Car(string name, int year, int[] osmotr, string[] fio, string color)
        {
            this.name = name;
            this.year = year;
            this.osmotr = osmotr;
            this.fio = fio;
            this.color = color;
        }

        public void Data()
        {
            Console.WriteLine("Наименование: " + name);
            Console.WriteLine("Год выпуска: " + year);
            Console.Write("Годы тех осмотра: ");
            foreach (int god in osmotr) Console.Write(god + " ");
            Console.WriteLine();
            Console.Write("Владельцы: ");
            foreach (string FIO in fio) Console.Write(FIO + " ");
            Console.WriteLine();
            Console.WriteLine("Цвет: " + color);
            Console.WriteLine();
        }

        public void name_kriteriy(string name)
        {
                if (this.name == name)
                    Data();
        }

        public void year_kriteriy(int year)
        {
            if (this.year == year)
                Data();
        }

        public void osmotr_kriteriy(int year)
        {
            if (osmotr.Contains(year))
                Console.WriteLine("Прошёл осмотр");
            else Console.WriteLine("Не прошёл осмотр");
        }

        
    }
}
