using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auditoriya> DB = new List<Auditoriya>();
            char cho;
            while (true)
            {
                Console.WriteLine("1) Создать БД\n 2) Добавить аудиторию в БД\n3) Изменить запись по номеру аудитории\n4) Выбрать по количеству мест\n5) Выбрать по наличию компьютеров\n6) Выбрать по наличию проектора\n7) Выбрать по этажу\n8) Выход");
                cho = Convert.ToChar(Console.ReadLine());
                Menu(cho)
            }
        }
    }

    class Menu
    {
        char cho;
        public Menu(char cho)
        {
            this.cho = cho;
        }
            
        public void Cho(cho)
        {

        }
        
    
    }

    class Auditoriya
    {
        public string nomer;
        public int mesta;
        public bool comp;
        public bool proector;

        static bool isCreated = false;

        static void CreateDB()
        {
            isCreated = true;
        }

        public Auditoriya(string nomer, int mesta, bool comp, bool proector)
        {
            this.nomer = nomer;
            this.mesta = mesta;
            this.comp = comp;
            this.proector = proector;
        }

        public void Edit()
        {
            Console.WriteLine("Что изменить:\n1) Количество мест\n2) Наличие компьютеров\n3) Наличие проектора");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1 || choice == 2 || choice == 3)
            {
                if (choice == 1)
                {
                    Console.Write("Введите новое значение: ");
                    mesta = int.Parse(Console.ReadLine());
                }
                else if (choice == 2)
                {
                    Console.Write("1) Компьютеры есть\n2) Компьютеров нет");
                    int choiceComp = int.Parse(Console.ReadLine());
                    if (choiceComp == 1 || choiceComp == 2)
                    {
                        if (choiceComp == 1)
                            comp = true;
                        else
                            comp = false;
                    }
                    else
                        Console.WriteLine("Неверное значение");
                }
                else if (choice == 3)
                {
                    Console.Write("1) Проектор есть\n2) Проектора нет");
                    int choiceProector = int.Parse(Console.ReadLine());
                    if (choiceProector == 1 || choiceProector == 2)
                    {
                        if (choiceProector == 1)
                            proector = true;
                        else
                            proector = false;
                    }
                    else
                        Console.WriteLine("Неверное значение");
                }
            }
            else
                Console.WriteLine("Невероное значение");
        }

        public bool Kolmest(int kol)
        {
            if (kol <= mesta) return true;
            return false;
        }
        public bool Floor(string floor)
        {
            if (floor == Convert.ToString(nomer[0])) return true;
            return false;
        }
    }
}
