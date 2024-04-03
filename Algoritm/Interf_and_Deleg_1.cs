Menu menu = new Menu();
menu.Start();


delegate void BinOperation(int a, int b);
delegate void UnOperation(int a);


interface IOperatable
{
    void Plus(int a, int b) => Console.WriteLine(a + b);
    void Minus(int a, int b) => Console.WriteLine(a - b);
    void Umn(int a, int b) => Console.WriteLine(a * b);
    void Del(int a, int b)
    {
        if (b == 0) Console.WriteLine("Деление на ноль невозможно");
        else Console.WriteLine(a / b);
    }
    void Kor(int a)
    {
        if (a < 0) Console.WriteLine("Корень из отрицательного числа не существует");
        else Console.WriteLine(Math.Sqrt(a));
    }
    void Cos(int a) => Console.WriteLine(Math.Cos(a));
    void Sin(int a) => Console.WriteLine(Math.Sin(a));
}


class Menu : IOperatable
{
    string choice { get; set; }
    public Menu(string choice = "0") => this.choice = choice;
    static void BinAction(int a, int b) { }
    static void UnAction(int a) { }
    public void Start()
    {
        Console.WriteLine("Выберите операцию: \n1. Сложение \n2. Разница \n3. Произведение \n4. Деление \n5. Корень \n6. Косинус \n7. Синус");
        Menu menu = new Menu(Console.ReadLine());
        if (menu.choice == "1" || menu.choice == "2" || menu.choice == "3" || menu.choice == "4")
        {
            BinOperation op = BinAction;
            switch (menu.choice)
            {
                case "1":
                    op = ((IOperatable)menu).Plus;
                    break;
                case "2":
                    op = ((IOperatable)menu).Minus;
                    break;
                case "3":
                    op = ((IOperatable)menu).Umn;
                    break;
                case "4":
                    op = ((IOperatable)menu).Del;
                    break;
            }
            Console.WriteLine("Введите два числа и результат будет на новой строке: ");
            op(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
        }
        else if (menu.choice == "5" || menu.choice == "6" || menu.choice == "7")
        {
            UnOperation op = UnAction;
            switch (menu.choice)
            {
                case "5":
                    op = ((IOperatable)menu).Kor;
                    break;
                case "6":
                    op = ((IOperatable)menu).Cos;
                    break;
                case "7":
                    op = ((IOperatable)menu).Sin;
                    break;
            }
            Console.WriteLine("Введите одно число и результат будет на новой строке: ");
            op(int.Parse(Console.ReadLine()));
        }
        else Console.WriteLine("Неверный формат выбора операции");
    }
}

