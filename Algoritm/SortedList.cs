using System.Collections;

SortedList sortedList = new SortedList();
sortedList.Add(1, "Первая фраза");
sortedList.Add(3, "Третья фраза");
sortedList.Add(2, "Вторая фраза");
PrintSortedList(sortedList);
Console.WriteLine("1)Add\n2)IndexOfKey\n3)IndexOfValue\n4)GetKey\n5)GetByIndex");
string choice = Console.ReadLine();
switch (choice)
{
    case "1":
        Add(sortedList);
        break;
    case "2":
        IndexOfKey(sortedList);
        break;
    case "3":
        IndexOfValue(sortedList);
        break;
    case "4":
        GetKey(sortedList);
        break;
    case "5":
        GetByIndex(sortedList);
        break;
}
        
    static void PrintSortedList(SortedList List)
{
    for (int i = 0; i < List.Count; i++)
    {
        Console.WriteLine($"{List.GetKey(i)}\t{List.GetByIndex(i)}");
    }
}

static void Add(SortedList List)
{
    Console.Write("Введите ключ: ");
    int key = int.Parse(Console.ReadLine());
    if (List.GetKeyList().Contains(key)) Console.WriteLine("Такой ключ уже есть");
    else
    {
        Console.Write("Введите значение: ");
        string value = Console.ReadLine();
        List.Add(key, value);
        PrintSortedList(List);
    }
}

static void IndexOfKey(SortedList List)
{
    Console.Write("Введите ключ: ");
    int key = int.Parse(Console.ReadLine());
    int index = List.IndexOfKey(key);
    Console.WriteLine(index >= 0 ? ("Индекс ключа: " + index) : "Такого ключа нет");
}

static void IndexOfValue(SortedList List)
{
    Console.Write("Введите значение: ");
    string value = Console.ReadLine();
    int index = List.IndexOfValue(value);
    Console.WriteLine(index >= 0 ? ("Индекс значения: " + index) : "Такого значения нет");
}

static void GetKey(SortedList List)
{
    Console.Write("Введите индекс: ");
    int index = int.Parse(Console.ReadLine());
    if (index >= List.Count) Console.WriteLine("Индекс слишком большой");
    else Console.WriteLine("Ключ: " + List.GetKey(index));
}

static void GetByIndex(SortedList List)
{
    Console.Write("Введите индекс: ");
    int index = int.Parse(Console.ReadLine());
    if (index >= List.Count) Console.WriteLine("Индекс слишком большой");
    else Console.WriteLine("Значение: " + List.GetByIndex(index));
}