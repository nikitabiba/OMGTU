using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication25
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }

    class Menu
    {
        public void Show()
        {
            string choice;
            do
            {
                Console.WriteLine("1) Создать БД\n2) Добавить аудиторию в БД\n3) Изменить запись по номеру аудитории\n4) Выбрать по количеству мест\n5) Выбрать по наличию компьютеров\n6) Выбрать по наличию проектора\n7) Выбрать по этажу\n8) Посмотреть информацию об аудитории\n9) Выход");
                choice = Console.ReadLine();
                if (String.IsNullOrEmpty(Convert.ToString(choice)))
                    Console.WriteLine("Неверное значение\n");
                else
                {
                    switch (choice)
                    {
                        case "1":
                            Auditoriya.CreateDB();
                            break;
                        case "2":
                            Auditoriya.AddAudit();
                            break;
                        case "3":
                            Auditoriya.Edit();
                            break;
                        case "4":
                            Auditoriya.KolMest();
                            break;
                        case "5":
                            Auditoriya.AvailabilityOfComputer();
                            break;
                        case "6":
                            Auditoriya.AvailabilityOfProector();
                            break;
                        case "7":
                            Auditoriya.SelectionByFloor();
                            break;
                        case "8":
                            Auditoriya.PrintInf();
                            break;
                        case "9":
                            break;
                        default:
                            Console.WriteLine("Неверное значение\n");
                            break;
                    }
                }
            }
            while (choice != "9");

        }
    }

    class Auditoriya
    {
        public string nomer;
        public int mesta;
        public bool comp;
        public bool proector;

        static public List<Auditoriya> auditoriya;
        static public bool isCreated = false;

        public Auditoriya(string nomer, int mesta, bool comp, bool proector)
        {
            this.nomer = nomer;
            this.mesta = mesta;
            this.comp = comp;
            this.proector = proector;
        }

        // Редактирование аудитории
        static public void Edit()
        {
            if (isCreated)
            {
                Console.Write("Введите номер аудитории: ");
                string nomer = Console.ReadLine();
                if (ReturnAuditoriya(nomer) != null)
                {
                    Auditoriya aud = ReturnAuditoriya(nomer);
                    Console.WriteLine("Что изменить:\n1) Количество мест\n2) Наличие компьютеров\n3) Наличие проектора");
                    string choice = Console.ReadLine();
                    if (!String.IsNullOrEmpty(choice) && (choice == "1" || choice == "2" || choice == "3"))
                    {
                        if (choice == "1")
                        {
                            Console.Write("Введите новое значение: ");
                            string newMest = Console.ReadLine();
                            if (!String.IsNullOrEmpty(newMest) && CheckNumber(newMest))
                            {
                                aud.mesta = int.Parse(newMest);
                                Console.WriteLine("Изменения внесены\n");
                            }
                            else
                                Console.WriteLine("Неверное значение\n");
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Есть ли компьютеры? y/n: ");
                            string choiceComp = Console.ReadLine();
                            Console.WriteLine();
                            if (choiceComp == "y" || choiceComp == "n")
                            {
                                if (choiceComp == "y")
                                    aud.comp = true;
                                else
                                    aud.comp = false;
                                Console.WriteLine("Изменения внесены\n");
                            }
                            else
                                Console.WriteLine("Неверное значение\n");
                        }
                        else if (choice == "3")
                        {
                            Console.Write("Есть ли проектор? y/n: ");
                            string choiceProector = Console.ReadLine();
                            Console.WriteLine();
                            if (choiceProector == "y" || choiceProector == "n")
                            {
                                if (choiceProector == "y")
                                    aud.proector = true;
                                else
                                    aud.proector = false;
                                Console.WriteLine("Изменения внесены\n");
                            }
                            else
                                Console.WriteLine("Неверное значение\n");
                        }
                    }
                    else
                        Console.WriteLine("Невероное значение\n");
                }
                else Console.WriteLine("Аудитории с таким номером нет в базе данных\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        // Выборка по количеству мест
        static public void KolMest()
        {
            if (isCreated)
            {
                List<Auditoriya> a = new List<Auditoriya>();
                Console.Write("Введите количество мест: ");
                string m = Console.ReadLine();
                if (!String.IsNullOrEmpty(m) && CheckNumber(m))
                {
                    foreach (Auditoriya aud in auditoriya)
                        if (aud.mesta >= Convert.ToInt32(m))
                            a.Add(aud);
                    if (a.Count != 0)
                    {
                        Console.Write("Подходящие аудитории: ");
                        foreach (Auditoriya aud in a)
                            Console.Write(aud.nomer + " ");
                        Console.WriteLine("\n");
                    }
                    else
                        Console.WriteLine("Нет подходящих аудиторий\n");
                }
                else
                    Console.WriteLine("Неверное значение\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        // Выборка по наличию компьютеров
        static public void AvailabilityOfComputer()
        {
            if (isCreated)
            {
                List<Auditoriya> a = new List<Auditoriya>();
                foreach (Auditoriya aud in auditoriya)
                    if (aud.comp)
                        a.Add(aud);
                if (a.Count != 0)
                {
                    Console.Write("Подходящие аудитории: ");
                    foreach (Auditoriya aud in a)
                        Console.Write(aud.nomer + " ");
                    Console.WriteLine("\n");
                }
                else
                    Console.WriteLine("Нет подходящих аудиторий\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        // Выборка по наличию проектора
        static public void AvailabilityOfProector()
        {
            if (isCreated)
            {
                List<Auditoriya> a = new List<Auditoriya>();
                foreach (Auditoriya aud in auditoriya)
                    if (aud.proector)
                        a.Add(aud);
                if (a.Count != 0)
                {
                    Console.Write("Подходящие аудитории: ");
                    foreach (Auditoriya aud in a)
                        Console.Write(aud.nomer + " ");
                    Console.WriteLine("\n");
                }
                else
                    Console.WriteLine("Нет подходящих аудиторий\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        // Выборка по этажу
        static public void SelectionByFloor()
        {
            if (isCreated)
            {
                Console.Write("Введите этаж (1-7): ");
                string floor = Console.ReadLine();
                if (!String.IsNullOrEmpty(floor) && (new string[] { "1", "2", "3", "4", "5", "6", "7" }).Contains(floor))
                {
                    List<Auditoriya> a = new List<Auditoriya>();
                    foreach (Auditoriya aud in auditoriya)
                        if (aud.nomer[0] == Convert.ToChar(floor))
                            a.Add(aud);
                    if (a.Count != 0)
                    {
                        Console.Write("Подходящие аудитории: ");
                        foreach (Auditoriya aud in a)
                            Console.Write(aud.nomer + " ");
                        Console.WriteLine("\n");
                    }
                    else
                        Console.WriteLine("Нет подходящих аудиторий\n");
                }
                else
                    Console.WriteLine("Неверый этаж\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        // Создание базы данных
        static public void CreateDB()
        {
            if (!isCreated)
            {
                auditoriya = new List<Auditoriya>();
                isCreated = true;
                Console.WriteLine("База данных создана\n");
            }
            else
                Console.WriteLine("База данных уже создана\n");
        }

        // Добавление аудитории
        static public void AddAudit()
        {
            if (isCreated)
            {
                Console.Write("Введите номер аудитории: ");
                string nomer = Console.ReadLine();
                if (!String.IsNullOrEmpty(nomer) && IsCorrectNomer(nomer) && nomer[0] != '0')
                {
                    if (ReturnAuditoriya(nomer) == null)
                    {
                        Console.Write("Введите количество мест: ");
                        string mesta = Console.ReadLine();
                        if (!String.IsNullOrEmpty(mesta) && CheckNumber(mesta))
                        {
                            bool comp = false;
                            Console.Write("Имеются ли компьютеры y/n: ");
                            string a = Console.ReadLine();
                            if (a == "y" || a == "n")
                            {
                                if (a == "y")
                                    comp = true;
                                else if (a == "n")
                                    comp = false;
                                bool proector = false;
                                Console.Write("Имеется ли проектор? y/n: ");
                                string b = Console.ReadLine();
                                if (b == "y" || b == "n")
                                {
                                    if (b == "y")
                                        proector = true;
                                    else if (b == "n")
                                        proector = false;
                                    Auditoriya newAud = new Auditoriya(nomer, Convert.ToInt32(mesta), comp, proector);
                                    auditoriya.Add(newAud);
                                    Console.WriteLine("Аудитория добавлена\n");
                                }
                                else
                                    Console.WriteLine("Неверное значение\n");

                            }
                            else
                                Console.WriteLine("Неверное значение\n");

                        }
                        else
                            Console.WriteLine("Неверное значение\n");
                    }
                    else
                        Console.WriteLine("Аудитория с таким номером уже есть\n");
                }
                else
                    Console.WriteLine("Неверное значение\n");
            }
            else
                Console.WriteLine("База данных ещё не создана\n");
        }

        static public void PrintInf()
        {
            if (isCreated)
            {
                Console.Write("Введите номер аудитории: ");
                string nomer = Console.ReadLine();
                if (!String.IsNullOrEmpty(nomer) && IsCorrectNomer(nomer))
                {
                    if (ReturnAuditoriya(nomer) != null)
                    {
                        Auditoriya aud = ReturnAuditoriya(nomer);
                        Console.WriteLine($"Номер аудитории: {aud.nomer}");
                        Console.WriteLine($"Количество мест: {aud.mesta}");
                        Console.WriteLine($"Наличие компьютеров: {(aud.comp ? "Есть" : "Нет")}");
                        Console.WriteLine($"Наличие проектора: {(aud.proector ? "Есть" : "Нет")}\n");
                    }
                    else Console.WriteLine("Аудитории с таким номером нет\n");
                }
                else
                    Console.WriteLine("Неверное значение\n");
            }
            else Console.WriteLine("База данных ещё не создана\n");
        }

        // Проверка номера аудитории
        static public bool IsCorrectNomer(string nomer)
        {
            string[] first = { "0", "1", "2", "3", "4", "5", "6", "7" };
            if (nomer.Length == 3 && first.Contains(Convert.ToString(nomer[0])) && CheckNumber(nomer) && !(nomer[1] == '0' && nomer[2] == '0'))
                return true;
            else
                return false;
        }

        // Проверка числа
        static public bool CheckNumber(string number)
        {
            string[] correct = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            foreach (char c in number)
                if (!correct.Contains(Convert.ToString(c)))
                    return false;
            return true;
        }

        // Возвращает аудиторию по номеру
        static public Auditoriya ReturnAuditoriya(string nomer)
        {
            foreach (Auditoriya aud in auditoriya)
                if (aud.nomer == nomer)
                    return aud;
            return null;
        }
    }
}