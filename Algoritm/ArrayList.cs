using System.Collections;

Console.Write("Сколько чисел добавить: ");
int length = int.Parse(Console.ReadLine());
ArrayList array = new ArrayList();
Console.WriteLine("Перечислите элементы ArrayList:");
for (int i = 0; i < length; i++)
    array.Add(int.Parse(Console.ReadLine()));
Console.WriteLine("\n1)Count\n2)BinSearch\n3)Copy\n4)IndexOf\n5)Insert\n6)Reverse\n7)Sort\n8)Add");
string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Количество элементов: " + array.Count);
        break;
    case "2":
        BinSearch(array);
        break;
    case "3":
        Copy(array);
        break;
    case "4":
        IndexOf(array);
        break;
    case "5":
        Insert(array);
        break;
    case "6":
        array.Reverse();
        PrintArray(array);
        break;
    case "7":
        array.Sort();
        PrintArray(array);
        break;
    case "8":
        Add(array);
        break;
}

    static void PrintArray(ArrayList array)
{
    foreach (int i in array) Console.Write(i + " ");
}

static void BinSearch(ArrayList array)
{
    array.Sort();
    Console.Write("Введите элемент: ");
    int value = int.Parse(Console.ReadLine());
    int index = array.BinarySearch(value);
    Console.WriteLine(index >= 0 ? "Индекс элемента в отсортированном массиве: " + index : "Число не найдено");
}

static void Copy(ArrayList array)
{
    Console.WriteLine("Заполните ArrayList, который копируем");
    Console.Write("Количество элементов: ");
    int length = int.Parse(Console.ReadLine());
    if (length > array.Count)
    {
        Console.WriteLine("Длина ArrayList, в который копируем должна быть не меньше длины второго ArrayList");
        return;
    }

    ArrayList array2 = new ArrayList();
    Console.WriteLine("Перечислите элементы:");
    for (int i = 0; i < length; i++)
        array2.Add(int.Parse(Console.ReadLine()));
    Array _array = ArrayListToArray(array);
    array2.CopyTo(_array);
    foreach (int i in _array) Console.Write(i + " ");
}

static void Insert(ArrayList array)
{
    Console.Write("Введите индекс: ");
    int index = int.Parse(Console.ReadLine());
    Console.Write("Введите значение: ");
    int value = int.Parse(Console.ReadLine());
    array.Insert(index, value);
    Console.WriteLine("Изменённый ArrayList: ");
    PrintArray(array);
}

static void IndexOf(ArrayList array)
{
    Console.Write("Какое число найти: ");
    int value = int.Parse(Console.ReadLine());
    int result = array.IndexOf(value);
    Console.WriteLine(result >= 0 ? ("Индекс элемента: " + result) : "Элемент не найден");
}

static void Add(ArrayList array)
{
    Console.Write("Введите значение: ");
    int value = int.Parse(Console.ReadLine());
    array.Add(value);
    Console.WriteLine("Изменённый ArrayList: ");
    PrintArray(array);
}

static Array ArrayListToArray(ArrayList array)
{
    Array array2 = Array.CreateInstance(typeof(Int32), array.Count);
    for (int i = 0; i < array.Count; i++)
        array2.SetValue(array[i], i);
    return array2;
}